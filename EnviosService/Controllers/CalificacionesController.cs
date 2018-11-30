using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidasCore;
using LogicaDeServicioCore;
using Newtonsoft.Json;

namespace EnviosService.Controllers
{
    [Produces("application/json")]
    
    public class CalificacionesController : Controller
    {
        private IControladorCalificacion controladorCalificacion;

        public CalificacionesController()
        {
            controladorCalificacion = FabricaServicio.GetControladorCalificacion();
        }
        [Route("api/Calificaciones/Calificar")]
        [HttpPost]
        public JsonResult Calificacion([FromBody] Calificacion cal)
        {
            return Json(controladorCalificacion.Calificar(cal));
        }

        [Route("api/Calificaciones/Listar")]
        [HttpGet]
        public JsonResult Calificaciones()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorCalificacion.ListarCalificaciones(), settings);
        }

    }
}