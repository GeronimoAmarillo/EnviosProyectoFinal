using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;
using EntidadesCompartidasCore;
using System.Net.Mail;
using ClientesApp.Models;

namespace ClientesApp.Controllers
{
    public class UsuariosController : Controller
    {
        public static string LOG_USER = "UsuarioLogueado";

        public static string SESSION_MENSAJE = "Mensaje";
        public static string SESSION_CODIGO = "EmailParaCodigo";

        public IActionResult Login()
        {
            try
            {
                Usuario usuario = HttpContext.Session.Get<Usuario>(LOG_USER);

                if (usuario == null)
                {
                    ViewBag.Logueado = false;
                }
                else
                {
                    ViewBag.Logueado = true;
                }

                string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);
                HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                if (mensaje != null && mensaje != "")
                {
                    ViewBag.Message = mensaje;
                }

                return View();
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Logueo.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public IActionResult Logout()
        {
            try
            {
                if (HttpContext.Session.Get<Usuario>(LOG_USER) != null)
                {
                    HttpContext.Session.Set<Usuario>(LOG_USER, null);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario deslogueado exitosamente!.");
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Accion Incorrecta: No existe un usuario previamente logueado!.");
                }

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar desloguearse.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Usuario usuario)
        {
            try
            {
                IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

                Usuario usuarioLogueado = await controladorUsuario.Login(usuario.NombreUsuario, usuario.Contraseña);


                if (usuarioLogueado != null && usuarioLogueado is Cliente)
                {
                    Cliente cliente = (Cliente)usuarioLogueado;

                    HttpContext.Session.Set<Cliente>(LOG_USER, cliente);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario logueado exitosamente!.");
                }
                else
                {
                    HttpContext.Session.Set<Usuario>(LOG_USER, null);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario y/o contraseña invalidos.");

                    return RedirectToAction("Login", "Usuarios", new { area = "" });
                }

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Loguearse.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult ModificarEmail()
        {
            try
            {
                if (ComprobarLogin())
                {
                    Cliente usuarioLogueado = (Cliente)HttpContext.Session.Get<Usuario>(LOG_USER);
                    ClienteEmailNuevo usuario = new ClienteEmailNuevo();

                    usuario.Contraseña = usuarioLogueado.Contraseña;
                    usuario.Direccion = usuarioLogueado.Direccion;
                    usuario.Email = usuarioLogueado.Email;
                    usuario.EmailViejo = usuarioLogueado.Email;
                    usuario.Id = usuarioLogueado.Id;
                    usuario.IdUsuario = usuarioLogueado.IdUsuario;
                    usuario.Mensualidad = usuarioLogueado.Mensualidad;
                    usuario.Nombre = usuarioLogueado.Nombre;
                    usuario.NombreUsuario = usuarioLogueado.NombreUsuario;
                    usuario.Telefono = usuarioLogueado.Telefono;
                    usuario.RUT = usuarioLogueado.RUT;
                    usuario.Usuarios = usuarioLogueado.Usuarios;

                    if (usuarioLogueado != null)
                    {
                        string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                        if (mensaje != null && mensaje != "")
                        {
                            ViewBag.Message = mensaje;
                        }

                        return View(usuario);
                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay ningun usuario logueado.");

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay ningun Cliente logueado.");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                

            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Modificacion de Email de contacto.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> ModificarEmail([FromForm] ClienteEmailNuevo cliente)
        {
            try
            {
                if (ComprobarLogin())
                {

                    string emailViejo = cliente.EmailViejo;

                    Cliente clienteXemail = await FabricaApps.GetControladorCliente().BuscarClienteXEmail(cliente.EmailViejo);

                    bool exito = false;
                    bool codigoYaSeteado = false;

                    if (clienteXemail.CodigoModificarEmail != null)
                    {
                        exito = true;
                        codigoYaSeteado = true;
                    }
                    else
                    {
                        exito = await FabricaApps.GetControladorUsuario().SetearCodigoEmail(clienteXemail);
                    }

                    if (exito && !codigoYaSeteado)
                    {
                        if (cliente != null && cliente is ClienteEmailNuevo)
                        {
                            Cliente clienteXemailModificado = await FabricaApps.GetControladorCliente().BuscarClienteXEmail(cliente.Email);

                            MailMessage mail = new MailMessage();
                            mail.From = new MailAddress("enviosservice2018@gmail.com");
                            mail.To.Add(emailViejo);
                            mail.Subject = "Cambio de eMail de contacto - EnviosService";
                            mail.Body = "Hola " + cliente.Nombre + ", Hemos comenzado el proceso de actualizacion de email de contacto como solicitastes! \n " +
                                "para confirmar el remplazo de la siguiente direccion de correo: " + cliente.Email + ", en lugar de: " + emailViejo + " ingrese en siguiente codigo de confirmacion: " + clienteXemailModificado.CodigoModificarEmail;
                            mail.IsBodyHtml = true;
                            mail.Priority = MailPriority.Normal;

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 25;
                            smtp.EnableSsl = true;
                            smtp.UseDefaultCredentials = true;
                            string correoPropio = "enviosservice2018@gmail.com";
                            string contraseñaCorreo = "MatiasPabloGero";
                            smtp.Credentials = new System.Net.NetworkCredential(correoPropio, contraseñaCorreo);

                            smtp.Send(mail);

                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se envio un correo de confirmación a " + emailViejo + " con los pasos a seguir para confirmar la actualización.");
                            HttpContext.Session.Set<string>(SESSION_CODIGO, clienteXemailModificado.Email);

                            return RedirectToAction("IngresarCodigoEmail", "Usuarios", new { area = "" });
                        }
                        else if (exito && codigoYaSeteado)
                        {
                            ViewBag.Mensaje = "Previamente ya se envio un correo con el codigo para definir su nuevo email a " + emailViejo + ".";

                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se envio un correo con el codigo para definir su nuevo email a " + emailViejo + ".");
                            HttpContext.Session.Set<string>(SESSION_CODIGO, clienteXemail.Email);

                            return RedirectToAction("IngresarCodigoEmail", "Usuarios", new { area = "" });
                        }
                        else
                        {
                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "No se pudo generar el codigo de confirmacion para el usuario con email: " + emailViejo + ".");

                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                    }

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay ningun Cliente logueado.");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                
            }
            catch(Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Loguearse.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult IngresarCodigoEmail()
        {
            try
            {
                string email = HttpContext.Session.Get<string>(SESSION_CODIGO);

                HttpContext.Session.Set<string>(SESSION_CODIGO, null);

                ViewBag.Email = email;

                return View();
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> IngresarCodigoEmail([FromForm] string email, [FromForm] string codigo)
        {
            try
            {

                Cliente cliente = await FabricaApps.GetControladorCliente().BuscarClienteXEmail(email);

                if (cliente != null)
                {

                    if (await FabricaApps.GetControladorUsuario().VerificarCodigoEmail(codigo, email))
                    {

                        IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

                        bool exito = await controladorUsuario.SetearCodigoEmail(cliente);

                        if (exito)
                        {
                            return RedirectToAction("ConfirmarModificacion", "Usuarios", new { rut = cliente.RUT, emailNuevo = cliente.Email });
                        }
                        else
                        {

                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se produjo un error al verificar el codigo.");

                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                    }
                    else
                    {
                        ViewBag.Incorrecto = "Codigo Incorrecto.";

                        return View();
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "El email ingresado no es valido o no pertenece a ningun Cliente del sistema.");

                    return RedirectToAction("RecuperarContraseña", "Usuarios", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Definir la nueva contraseña.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult ConfirmarModificacion(long rut, string emailNuevo)
        {
            try
            {
                if (ComprobarLogin() && (HttpContext.Session.Get<Cliente>(LOG_USER)).RUT == rut)
                {

                    Cliente usuarioAModificar = (Cliente)HttpContext.Session.Get<Usuario>(LOG_USER);
                    ClienteEmailNuevo usuario = new ClienteEmailNuevo();

                    usuario.Contraseña = usuarioAModificar.Contraseña;
                    usuario.Direccion = usuarioAModificar.Direccion;
                    usuario.Email = emailNuevo;
                    usuario.EmailViejo = usuarioAModificar.Email;
                    usuario.Id = usuarioAModificar.Id;
                    usuario.IdUsuario = usuarioAModificar.IdUsuario;
                    usuario.Mensualidad = usuarioAModificar.Mensualidad;
                    usuario.Nombre = usuarioAModificar.Nombre;
                    usuario.NombreUsuario = usuarioAModificar.NombreUsuario;
                    usuario.Telefono = usuarioAModificar.Telefono;
                    usuario.RUT = usuarioAModificar.RUT;
                    usuario.Usuarios = usuarioAModificar.Usuarios;

                    if (usuarioAModificar != null)
                    {
                        string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                        if (mensaje != null && mensaje != "")
                        {
                            ViewBag.Message = mensaje;
                        }

                        return View(usuario);
                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay ningun usuario logueado.");

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay ningun Cliente logueado o el cliente logueado no tiene permiso.");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Modificacion de Email de contacto.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
        
        [HttpPost]
        public async Task<IActionResult> ConfirmarModificacion([FromForm] ClienteEmailNuevo cliente)
        {
            try
            {
                if (ComprobarLogin() && (HttpContext.Session.Get<Cliente>(LOG_USER)).RUT == cliente.RUT)
                {
                    IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

                    Usuario usuarioLogueado = await controladorUsuario.ModificarEmail(cliente);

                    string emailViejo = cliente.EmailViejo;

                    if (usuarioLogueado != null && usuarioLogueado is Cliente)
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("enviosservice2018@gmail.com");
                        mail.To.Add(cliente.Email);
                        mail.Subject = "Cambio de eMail de Contacto EnviosService";
                        mail.Body = "Hola " + usuarioLogueado.Nombre + ", Hemos modificado tu eMail de contacto como solicitastes! \n " +
                            "tu nuevo Email de contacto sera a partir de hoy: " + usuarioLogueado.Email;
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.Normal;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 25;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        string correoPropio = "enviosservice2018@gmail.com";
                        string contraseñaCorreo = "MatiasPabloGero";
                        smtp.Credentials = new System.Net.NetworkCredential(correoPropio, contraseñaCorreo);

                        smtp.Send(mail);
                        ViewBag.Mensaje = "Email modificado correctamente, se envio un correo a " + emailViejo + "con el nuevo mail de contacto";

                        Cliente clienteLogueado = (Cliente)usuarioLogueado;

                        HttpContext.Session.Set<Cliente>(LOG_USER, clienteLogueado);

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario modificado exitosamente!.");
                    }
                    else
                    {
                        HttpContext.Session.Set<Usuario>(LOG_USER, null);

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario y/o contraseña invalidos.");

                        return RedirectToAction("Login", "Usuarios", new { area = "" });
                    }

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay ningun Cliente logueado o el cliente logueado no tiene permiso.");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Loguearse.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult RecuperarContraseña()
        {
            try
            {
                return View();
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Recuperacion de contraseña.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> RecuperarContraseña([FromForm] string email)
        {
            try
            {
                if (await FabricaApps.GetControladorCliente().ExisteClienteXEmail(email))
                {
                    Cliente clienteXemailConCodigo = null;

                    Cliente clienteXemail = await FabricaApps.GetControladorCliente().BuscarClienteXEmail(email);

                    bool exito = false;
                    bool codigoYaSeteado = false;

                    if (clienteXemail.CodigoRecuperacionContraseña != null)
                    {
                        exito = true;
                        codigoYaSeteado = true;
                    }
                    else
                    {
                        exito = await FabricaApps.GetControladorUsuario().SetearCodigoContraseña(clienteXemail);
                    }

                    if (exito && !codigoYaSeteado)
                    {

                        clienteXemailConCodigo = await FabricaApps.GetControladorCliente().BuscarClienteXEmail(email);

                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("enviosservice2018@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Recuperación de contraseña - EnviosService";
                        mail.Body = "Hola, Hemos comenzado el proceso de recuperación de contraseña como solicitastes! \n " +
                            "para definir su nueva contraseña utilize el siguiente codigo: " + clienteXemailConCodigo.CodigoRecuperacionContraseña;
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.Normal;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 25;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        string correoPropio = "enviosservice2018@gmail.com";
                        string contraseñaCorreo = "MatiasPabloGero";
                        smtp.Credentials = new System.Net.NetworkCredential(correoPropio, contraseñaCorreo);

                        smtp.Send(mail);
                        ViewBag.Mensaje = "Se envio un correo con el codigo para definir su nueva contraseña a " + email + ".";

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se envio un correo con el codigo para definir su nueva contraseña a " + email + ".");
                        HttpContext.Session.Set<string>(SESSION_CODIGO, clienteXemailConCodigo.Email);

                        return RedirectToAction("IngresarCodigoContraseña", "Usuarios", new { area = "" });
                    }
                    else if (exito && codigoYaSeteado)
                    {
                        ViewBag.Mensaje = "Previamente ya se envio un correo con el codigo para definir su nueva contraseña a " + email + ".";

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se envio un correo con el codigo para definir su nueva contraseña a " + email + ".");
                        HttpContext.Session.Set<string>(SESSION_CODIGO, clienteXemail.Email);

                        return RedirectToAction("IngresarCodigoContraseña", "Usuarios", new { area = "" });
                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "No se pudo generar el codigo de confirmacion para el usuario con email: " + email + ".");

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "El email ingresado no es valido o no pertenece a ningun Cliente del sistema.");

                    return RedirectToAction("RecuperarContraseña", "Usuarios", new { area = "" });
                }

                
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Recuperar la contraseña.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult IngresarCodigoContraseña()
        {
            try
            {
                string email = HttpContext.Session.Get<string>(SESSION_CODIGO);

                HttpContext.Session.Set<string>(SESSION_CODIGO, null);

                ViewBag.Email = email;

                return View();
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> IngresarCodigoContraseña([FromForm] string email, [FromForm] string codigo)
        {
            try
            {

                Cliente cliente = await FabricaApps.GetControladorCliente().BuscarClienteXEmail(email);

                if (cliente != null)
                {

                    if (await FabricaApps.GetControladorUsuario().VerificarCodigoContraseña(codigo, email))
                    {
                        IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

                        bool exito = await controladorUsuario.SetearCodigoContraseña(cliente);

                        if (exito)
                        {
                            return RedirectToAction("DefinicionContraseña", "Usuarios", new { pEmail = email });
                        }
                        else
                        {

                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se produjo un error al verificar el codigo.");

                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                    }
                    else
                    {
                        ViewBag.Incorrecto = "Codigo Incorrecto.";

                        return View();
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "El email ingresado no es valido o no pertenece a ningun Cliente del sistema.");

                    return RedirectToAction("RecuperarContraseña", "Usuarios", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Definir la nueva contraseña.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult DefinicionContraseña(string pEmail)
        {
            try
            {
                ViewBag.Email = pEmail;
                return View();
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Recuperacion de contraseña.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> DefinicionContraseñaPost([FromForm] string email, [FromForm] string contraseña)
        {
            try
            {

                Cliente cliente = await FabricaApps.GetControladorCliente().BuscarClienteXEmail(email);

                if (cliente != null)
                {
                    cliente.Contraseña = contraseña;

                    IControladorCliente controladorUsuario = FabricaApps.GetControladorCliente();

                    bool exito = controladorUsuario.ModificarCliente(cliente);

                    if (exito)
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("enviosservice2018@gmail.com");
                        mail.To.Add(cliente.Email);
                        mail.Subject = "Cambio de eMail de Contacto EnviosService";
                        mail.Body = "Hola " + cliente.Nombre + ", Hemos modificado tu Contraseña de acceso como solicitastes! \n " +
                            "tu nueva Contraseña de ingreso sera a partir de hoy: " + contraseña;
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.Normal;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 25;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        string correoPropio = "enviosservice2018@gmail.com";
                        string contraseñaCorreo = "MatiasPabloGero";
                        smtp.Credentials = new System.Net.NetworkCredential(correoPropio, contraseñaCorreo);

                        smtp.Send(mail);
                        ViewBag.Mensaje = "Contraseña de acceso modificado correctamente, se envio un correo a " + email + "con la nueva contraseña de acceso.";

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario modificado exitosamente!.");

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else
                    {

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se produjo un error al recuperar su contraseña.");

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "El email ingresado no es valido o no pertenece a ningun Cliente del sistema.");

                    return RedirectToAction("RecuperarContraseña", "Usuarios", new { area = "" });
                }
                
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Definir la nueva contraseña.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public bool ComprobarLogin()
        {
            try
            {
                Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                if (cliente != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Error al comprobar el logueo.");
            }
        }

        [HttpGet]
        public ActionResult ModificarContrasenia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModificarContrasenia([FromForm] DTUsuario datadelForm)
        {
            try
            {
                if (ModelState.IsValid && (!string.IsNullOrEmpty(datadelForm.NuevaContrasenia) || !string.IsNullOrEmpty(datadelForm.NuevoNombreUsuario)))
                {

                    Cliente empLogueado = HttpContext.Session.Get<Cliente>(LOG_USER);
                    if (empLogueado.Contraseña == datadelForm.Contraseña && empLogueado.NombreUsuario == datadelForm.NombreUsuario)
                    {
                        empLogueado.Contraseña = string.IsNullOrEmpty(datadelForm.NuevaContrasenia) ? empLogueado.Contraseña : datadelForm.NuevaContrasenia;
                        empLogueado.NombreUsuario = string.IsNullOrEmpty(datadelForm.NuevoNombreUsuario) ? empLogueado.NombreUsuario : datadelForm.NuevoNombreUsuario;
                    }
                    IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();
                    if (await controladorUsuario.ModificarContraseña(empLogueado))
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Contraseña modificada exitosamente!.");
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar modificar la contraseña.");
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error o datos de contraseña invalidos.");
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar modificar la contraseña.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }


        }
    }
}