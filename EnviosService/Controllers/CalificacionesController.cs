using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidasCore;
using LogicaDeServicioCore;

namespace EnviosService.Controllers
{
    [Produces("application/json")]
    [Route("api/Calificaciones")]
    public class CalificacionesController : Controller
    {
        private IControladorCalificacion controladorCalificacion;

        public CalificacionesController()
        {
            controladorCalificacion = FabricaServicio.GetControladorCalificacion();
        }

        [HttpPost]
        public JsonResult Calificacion([FromBody] Calificacion cal)
        {
            return Json(controladorCalificacion.Calificar(cal.Puntaje, cal.Comentario, cal.RutCliente));
        }
        
    }
}