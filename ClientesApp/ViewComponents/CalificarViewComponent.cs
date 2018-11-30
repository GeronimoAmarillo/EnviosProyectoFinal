using EntidadesCompartidasCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.ViewComponents
{
    public class CalificarViewComponent : ViewComponent
    {
        public static string SESSION_CALIFICACIONES = "Calificaciones";

        public IViewComponentResult Invoke()
        {
            var calificaciones = HttpContext.Session.Get<List<Calificacion>>(SESSION_CALIFICACIONES);

            return View(calificaciones);
        }
    }
}
