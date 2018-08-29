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
                Cliente usuarioLogueado = (Cliente)HttpContext.Session.Get<Usuario>(LOG_USER);
                ClienteEmailNuevo usuario = new ClienteEmailNuevo();

                usuario.Contraseña = usuarioLogueado.Contraseña;
                usuario.Direccion = usuarioLogueado.Direccion;
                usuario.Email = usuarioLogueado.Email;
                usuario.EmailViejo = usuarioLogueado.Email;
                usuario.Id = usuarioLogueado.Id;
                usuario.IdUsuario = usuario.IdUsuario;
                usuario.Mensualidad = usuario.Mensualidad;
                usuario.Nombre = usuario.Nombre;
                usuario.NombreUsuario = usuario.NombreUsuario;
                usuario.Telefono = usuario.Telefono;
                usuario.RUT = usuario.RUT;
                usuario.Usuarios = usuario.Usuarios;

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
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Modificacion de Email de contacto.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public async Task<IActionResult> ModificarEmail([FromForm] ClienteEmailNuevo cliente)
        {
            try
            {
                IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

                Usuario usuarioLogueado = await controladorUsuario.ModificarEmail(cliente);

                string emailViejo = cliente.EmailViejo;

                if (usuarioLogueado != null && usuarioLogueado is Cliente)
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("geronimoamarillo29@gmail.com");
                    mail.To.Add(emailViejo);
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
                    string correoPropio = "geronimoamarillo29@gmail.com";
                    string contraseñaCorreo = "Geronacional4421";
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
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Loguearse.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
    }
}