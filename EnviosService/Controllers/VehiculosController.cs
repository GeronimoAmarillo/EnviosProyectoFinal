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
    
    public class VehiculosController : Controller
    {
        private IControladorVehiculo controladorVehiculo;

        public VehiculosController()
        {
            controladorVehiculo = FabricaServicio.GetControladorVehiculo();
        }

        
        [HttpPost]
        [HttpPut]
        [Route("api/Vehiculos/Auto")]
        public JsonResult Auto([FromBody] Automobil vehiculo)
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

        [HttpPost]
        [HttpPut]
        [Route("api/Vehiculos/Camion")]
        public JsonResult Camion([FromBody] Camion vehiculo)
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
        [HttpPost]
        [HttpPut]
        [Route("api/Vehiculos/Camioneta")]
        public JsonResult Camioneta([FromBody] Camioneta vehiculo)
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
        [HttpPost]
        [HttpPut]
        [Route("api/Vehiculos/Moto")]
        public JsonResult Moto([FromBody] Moto vehiculo)
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


        [HttpGet]
        [HttpGet("{matricula}")]
        [Route("api/Vehiculos/Existe")]
        public JsonResult Vehiculo(string matricula)
        {
             return Json(controladorVehiculo.ExisteVehiculo(matricula), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        [Route("api/Vehiculos/Cadetes")]
        public JsonResult Cadetes()
        {
            return Json(controladorVehiculo.ListarCadetesDisponibles(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        [Route("api/Vehiculos/Vehiculos")]
        public JsonResult Vehiculos()
        {
            return Json(controladorVehiculo.ListarVehiculos(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{cedula}")]
        [Route("api/Vehiculos/Cadete")]
        public JsonResult Cadete(int cedula)
        {
            return Json(controladorVehiculo.SeleccionarCadete(cedula), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}