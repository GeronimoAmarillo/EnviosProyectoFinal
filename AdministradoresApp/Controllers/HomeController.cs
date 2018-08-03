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
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

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
    }
}
