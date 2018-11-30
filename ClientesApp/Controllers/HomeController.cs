using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientesApp.Models;
using LogicaDeAppsCore;
using EntidadesCompartidasCore;

namespace ClientesApp.Controllers
{
    public class HomeController : Controller
    {
        public static string SESSION_CALIFICACIONES = "Calificaciones";
        public static string SESSION_MENSAJE = "Mensaje";

        public async Task<ActionResult> Index()
        {

            //try
            //{
            //    IControladorCalificacion controladorCalificacion = FabricaApps.GetControladorCalificacion();

            //    List<Calificacion> calificaciones = await controladorCalificacion.ListarCalificaciones();

            //    HttpContext.Session.Set<List<Calificacion>>(SESSION_CALIFICACIONES, calificaciones);

            //    return View();
            //}
            //catch
            //{
            //    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar las Calificaciones");

            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}

            return View();
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
