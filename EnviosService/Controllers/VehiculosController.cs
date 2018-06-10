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
    [Route("api/Vehiculos")]
    public class VehiculosController : Controller
    {
        private IControladorVehiculo controladorVehiculo;

        public VehiculosController()
        {
            controladorVehiculo = FabricaServicio.GetControladorVehiculo();
        }

        [HttpPost]
        [HttpPut]
        public JsonResult Vehiculo([FromBody] Vehiculo vehiculo)
        {
            switch (Request.Method.ToString())
            {
                case "PUT":
                    return Json(controladorVehiculo.ModificarVehiculo(vehiculo), new Newtonsoft.Json.JsonSerializerSettings());
                case "POST":
                    return Json(controladorVehiculo.AltaVehiculo(vehiculo), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPut]
        public JsonResult Vehiculo([FromBody] string matricula)
        {
             return Json(controladorVehiculo.ExisteVehiculo(matricula), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        public JsonResult Cadetes()
        {
            return Json(controladorVehiculo.ListarCadetesDisponibles(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{cedula}")]
        public JsonResult Cadete(int cedula)
        {
            return Json(controladorVehiculo.SeleccionarCadete(cedula), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}