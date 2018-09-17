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
    
    public class ReparacionesController : Controller
    {
        private IControladorReparacion controladorReparacion;

        public ReparacionesController()
        {
            controladorReparacion = FabricaServicio.GetControladorReparacion();
        }

        [Route("api/Reparaciones/Vehiculo")]
        [HttpGet("{matricula}")]
        public JsonResult Vehiculo(string matricula)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorReparacion.SeleccionarVehiculo(matricula), settings);
        }

        [Route("api/Reparaciones/Vehiculos")]
        [HttpGet]
        public JsonResult Vehiculos()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return Json(controladorReparacion.ListarVehiculos(), settings);
        }

        [Route("api/Reparaciones/Reparacion")]
        [HttpPost]
        public JsonResult Reparacion([FromBody] Reparacion item)
        {
            return Json(controladorReparacion.RegistrarReparacion(item), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}