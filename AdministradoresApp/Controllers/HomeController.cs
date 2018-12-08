using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdministradoresApp.Models;

namespace AdministradoresApp.Controllers
{
    public class HomeController : Controller
    {
        public static string SESSION_MENSAJE = "Mensaje";


        public IActionResult Index()
        {
            try
            {
                descargarMensaje();

                return View();
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
