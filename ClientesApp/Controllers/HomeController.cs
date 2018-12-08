using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientesApp.Models;
using LogicaDeAppsCore;
using EntidadesCompartidasCore;
using System.Net.Mail;

namespace ClientesApp.Controllers
{
    public class HomeController : Controller
    {
        public static string SESSION_CALIFICACIONES = "Calificaciones";
        public static string SESSION_MENSAJE = "Mensaje";

        public async Task<ActionResult> Index()
        {

            try
            {
                IControladorCalificacion controladorCalificacion = FabricaApps.GetControladorCalificacion();

                List<Calificacion> calificaciones = await controladorCalificacion.ListarCalificaciones();
                List<Calificacion> calificacionesUI = new List<Calificacion>();
                if (calificaciones != null)
                {
                    if (calificaciones.Any())
                    {
                        List<Calificacion> calificacionesSeleccionadas = calificaciones.Where(x => x.Puntaje == 5 || x.Puntaje == 4).OrderByDescending(x => x.Puntaje).ToList();

                        

                        if (calificacionesSeleccionadas.Count >= 2)
                        {
                            if (calificacionesSeleccionadas.Count >= 3)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    calificacionesUI.Add(calificacionesSeleccionadas[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    calificacionesUI.Add(calificacionesSeleccionadas[i]);
                                }
                            }

                        }

                    }
                }

                return View(calificacionesUI);
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar las Calificaciones");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            if (TempData["Mensaje"] != null)
            {
                string mensaje = TempData["Mensaje"].ToString();
                TempData["Mensaje"] = mensaje;
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contactar([FromForm]string nombre, [FromForm] string email, [FromForm] string mensaje)
        {
            throw new NotImplementedException(); 
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
