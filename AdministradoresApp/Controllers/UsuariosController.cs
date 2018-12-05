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
                descargarMensaje();

                return View();
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Logueo.");

                TempData["Mensaje"] = "Error al mostrar el formulario de Logueo.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }
        
        public IActionResult Logout()
        {
            try
            {
                if (HttpContext.Session.Get<Usuario>(LOG_USER) != null)
                {
                    HttpContext.Session.Set<Usuario>(LOG_USER, null);

                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario deslogueado exitosamente!.");

                    TempData["Mensaje"] = "Usuario deslogueado exitosamente!.";
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Accion Incorrecta: No existe un usuario previamente logueado!.");

                    TempData["Mensaje"] = "Accion Incorrecta: No existe un usuario previamente logueado!.";
                }

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar desloguearse.");

                TempData["Mensaje"] = "Error al intentar desloguearse.";

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

                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario logueado exitosamente!.");

                    TempData["Mensaje"] = "Usuario logueado exitosamente!.";
                }
                else
                {
                    HttpContext.Session.Set<Usuario>(LOG_USER, null);

                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Usuario y/o contraseña invalidos.");

                    TempData["Mensaje"] = "Usuario y/o contraseña invalidos.";

                    return RedirectToAction("Login", "Usuarios", new { area = "" });
                }

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar Loguearse.");

                TempData["Mensaje"] = "Error al intentar Loguearse.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }

        [HttpGet]
        public ActionResult ModificarContrasenia()
        {

            try
            {
                if (TempData["Mensaje"] != null)
                {
                    string mensaje = TempData["Mensaje"].ToString();
                    TempData["Mensaje"] = mensaje;
                }

                return View();
            }
            catch
            {
                TempData["Mensaje"] = "Error al intentar modificar la contraseña.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }


        [HttpPost]
        public async Task<IActionResult> ModificarContrasenia([FromForm] DTUsuario datadelForm)
        {
            try
            {
                if (ModelState.IsValid && (!string.IsNullOrEmpty(datadelForm.NuevaContrasenia) || !string.IsNullOrEmpty(datadelForm.NuevoNombreUsuario)))
                {

                    Administrador adminLogueado = HttpContext.Session.Get<Administrador>(LOG_USER);
                    if (adminLogueado.Contraseña == datadelForm.Contraseña && adminLogueado.NombreUsuario == datadelForm.NombreUsuario)
                    {
                        adminLogueado.Contraseña = string.IsNullOrEmpty(datadelForm.NuevaContrasenia) ? adminLogueado.Contraseña : datadelForm.NuevaContrasenia;
                        adminLogueado.NombreUsuario = string.IsNullOrEmpty(datadelForm.NuevoNombreUsuario) ? adminLogueado.NombreUsuario : datadelForm.NuevoNombreUsuario;
                    }
                    IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();
                    if (await controladorUsuario.ModificarContraseña(adminLogueado))
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Contraseña modificada exitosamente!.");

                        TempData["Mensaje"] = "Contraseña modificada exitosamente!.";

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar modificar la contraseña.");

                        TempData["Mensaje"] = "Error al intentar modificar la contraseña.";

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error o datos de contraseña invalidos.");

                    TempData["Mensaje"] = "Error o datos de contraseña invalidos.";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar modificar la contraseña.");

                TempData["Mensaje"] = "Error al intentar modificar la contraseña.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
            
        }

        public void cargarMensaje(string mensaje)
        {
            try
            {
                TempData["Mensaje"] = mensaje;
            }
            catch
            {
                throw new Exception("Error al cargar el mensaje.");
            }
        }

        public void descargarMensaje()
        {
            try
            {
                if (TempData["Mensaje"] != null)
                {
                    string mensaje = TempData["Mensaje"].ToString();
                    TempData["Mensaje"] = mensaje;
                }
            }
            catch
            {
                throw new Exception("Error al descargar el mensaje.");
            }
        }
    }
}