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
            return Json(controladorReparacion.SeleccionarVehiculo(matricula), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Reparaciones/Vehiculos")]
        [HttpGet]
        public JsonResult Vehiculos()
        {
            return Json(controladorReparacion.ListarVehiculos(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Reparaciones/Reparacion")]
        [HttpPost]
        public JsonResult Reparacion([FromBody] Reparacion item)
        {
            return Json(controladorReparacion.RegistrarReparacion(item), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}