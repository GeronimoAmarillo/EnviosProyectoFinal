using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;
using EntidadesCompartidasCore;
using System.Net.Mail;

namespace ClientesApp.Controllers
{
    public class UsuariosController : Controller
    {
        public static string LOG_USER = "UsuarioLogueado";

        public static string SESSION_MENSAJE = "Mensaje";

        public IActionResult Login()
        {
            try
            {
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

                    string emailViejo = cliente.Email;

                    if (cliente != null && cliente is ClienteEmailNuevo)
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("enviosservice2018@gmail.com");
                        mail.To.Add(emailViejo);
                        mail.Subject = "Cambio de eMail de contacto - EnviosService";
                        mail.Body = "Hola " + cliente.Nombre + ", Hemos comenzado el proceso de actualizacion de email de contacto como solicitastes! \n " +
                            "para confirmar el remplazo de la siguiente direccion de correo: " + cliente.Email + ", en lugar de: " + emailViejo + " de click sobre el siguiente enlace de confirmación: \n" +
                            "http://localhost:56270/Usuarios/ConfirmarModificacion?rut=" + cliente.RUT +"&emailNuevo="+ cliente.Email;
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
                        ViewBag.Mensaje = "Se envio un correo de confirmación a " + emailViejo + " con los pasos a seguir para confirmar la actualización.";

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se envio un correo de confirmación a " + emailViejo + " con los pasos a seguir para confirmar la actualización.");
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

        [ValidateAntiForgeryToken]
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

        [ValidateAntiForgeryToken]
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
    }
}