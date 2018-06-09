using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeApps;
using EntidadesCompartidas;

namespace ClientesApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        public static string LOG_USER = "UsuarioLogueado";

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] string usuario, [FromBody] string contraseña)
        {
            IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

            Usuario usuarioLogueado = await controladorUsuario.Login(usuario, contraseña);

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

            return View();
        }

        [HttpPost]
        public ActionResult Logout()
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

            return View();
        }
    }
}