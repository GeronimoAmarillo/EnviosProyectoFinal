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
    public class TurnosController : Controller
    {
        private IControladorTurno controladorTurno;

        public TurnosController()
        {
            controladorTurno = FabricaServicio.GetControladorTurno();
        }

        [Route("api/Turnos/Turnos")]
        [HttpGet]
        public JsonResult Turnos()
        {
            return Json(controladorTurno.ListarTurnos(), new Newtonsoft.Json.JsonSerializerSettings());
        }
        [Route("api/Turnos/Turno")]
        [HttpGet("{codigo}")]
        public JsonResult Turno(string codigo)
        {
            return Json(controladorTurno.BuscarTurno(codigo), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{dia, hora}")]
        [Route("api/Turnos/ExisteTurno")]
        public JsonResult ExisteTurno(string dia, string hora)
        {
            return Json(controladorTurno.ExisteTurno(dia,hora), new Newtonsoft.Json.JsonSerializerSettings());
        }
        [Route("api/Turnos/Eliminar")]
        [HttpPost]
        public JsonResult Modificar([FromBody] Turno item)
        {
            return Json(controladorTurno.EliminarTurno(item), new Newtonsoft.Json.JsonSerializerSettings());
        }
       
        [HttpPost]
        [Route("api/Turnos/Alta")]
        public JsonResult Turno([FromBody] Turno item)
        {         
                    return Json(controladorTurno.AltaTurno(item), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}