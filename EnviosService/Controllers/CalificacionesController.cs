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
        public JsonResult Calificacion([FromBody] int puntaje , [FromBody] string comentario)
        {
            return Json(controladorCalificacion.Calificar(puntaje, comentario));
        }
    }
}