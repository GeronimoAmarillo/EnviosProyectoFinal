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
    [Route("api/Turnos")]
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

        [HttpPost]
        public JsonResult Turno([FromBody] string dia, [FromBody] string hora)
        {
            return Json(controladorTurno.ExisteTurno(dia, hora), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        [HttpPut]
        public JsonResult Turno([FromBody] Turno turno)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorTurno.AltaTurno(turno), new Newtonsoft.Json.JsonSerializerSettings());
                case "PUT":
                    return Json(controladorTurno.ModificarTurno(turno), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}