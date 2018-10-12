using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;
using AdministradoresApp.Models;
using Microsoft.Extensions.Primitives;

namespace AdministradoresApp.Controllers
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
                

                if (usuarioLogueado != null && usuarioLogueado is Administrador)
                {
                    Administrador admin = (Administrador)usuarioLogueado;

                    HttpContext.Session.Set<Administrador>(LOG_USER, admin);

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
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(datadelForm.NuevaContrasenia) && !string.IsNullOrEmpty(datadelForm.NuevoNombreUsuario))
                    {
                        Administrador adminLogueado = HttpContext.Session.Get<Administrador>(LOG_USER);
                        if (adminLogueado.Contraseña == datadelForm.Contraseña)
                            adminLogueado.Contraseña = datadelForm.NuevaContrasenia;

                        IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();
                        if (await controladorUsuario.ModificarContraseña(adminLogueado))
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