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

        [HttpPut]
        [HttpPost]
        [Route("api/Turnos/Alta")]
        public JsonResult Turno([FromBody] Turno item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorTurno.AltaTurno(item), new Newtonsoft.Json.JsonSerializerSettings());
                case "PUT":
                    return Json(controladorTurno.ModificarTurno(item), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}