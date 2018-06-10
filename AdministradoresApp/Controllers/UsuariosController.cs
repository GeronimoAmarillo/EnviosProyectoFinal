using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;

namespace AdministradoresApp.Controllers
{
    public class UsuariosController : Controller
    {
        public static string LOG_USER = "UsuarioLogueado";
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            if (HttpContext.Session.Get<Usuario>(LOG_USER) != null)
            {
                HttpContext.Session.Set<Usuario>(LOG_USER, null);

                ViewData["Mensaje"] = "Usuario deslogueado exitosamente!.";
            }
            else
            {
                ViewData["Mensaje"] = "Accion Incorrecta: No existe un usuario previamente logueado!.";

            }

            return RedirectToAction("Login", "Usuarios");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Usuario usuario)
        {
            IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

            Usuario usuarioLogueado = await controladorUsuario.Login(usuario.NombreUsuario, usuario.Contraseña);

            if (usuarioLogueado != null)
            {
                HttpContext.Session.Set<Usuario>(LOG_USER, usuarioLogueado);

                ViewData["Mensaje"] = "Usuario logueado exitosamente!.";
            }
            else
            {
                HttpContext.Session.Set<Usuario>(LOG_USER, null);

                ViewData["Mensaje"] = "Usuario y/o contraseña invalidos.";
            }

            return RedirectToAction("Login");
        }

        

    }
}