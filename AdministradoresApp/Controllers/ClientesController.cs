using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;
using EntidadesCompartidasCore;

namespace AdministradoresApp.Controllers
{
    
    public class ClientesController : Controller
    {
        public static string SESSION_MENSAJE = "Mensaje";


        public IActionResult AltaCliente()
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
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Alta de Cliente.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> AltaCliente([FromForm] Cliente unCliente)
        {
            try
            {
                IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();
                bool exito = await controladorUsuario.AltaUsuario(unCliente);
                if (exito)
                {
                    ViewBag.Message = "Cliente agregado exitosamente";
                    return View("Index");
                }
                else
                {
                    ViewBag.Message = "Error al intentar dar de alta el cliente";
                    return View();
                }
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar dar de alta el cliente.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    }
}