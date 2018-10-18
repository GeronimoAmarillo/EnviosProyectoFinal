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
    
    public class AdelantosController : Controller
    {
        private IControladorAdelanto controladorAdelanto;

        public AdelantosController()
        {
            controladorAdelanto = FabricaServicio.GetControladorAdelanto();
        }

        //GET /Api/Empleados
        
        [HttpGet("{cedula}")]
        [Route("api/Adelantos/Empleado")]
        public JsonResult Empleado(int cedula)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorAdelanto.BuscarEmpleado(cedula), settings);
        }

        [HttpGet("{cedula}")]
        [Route("api/Adelantos/Empleado/Habilitado")]
        public JsonResult Verificar(int cedula)
        {
            return Json(controladorAdelanto.VerificarAdelantoSaldado(cedula), new Newtonsoft.Json.JsonSerializerSettings());
        }


        [HttpGet]
        [Route("api/Adelantos/Empleados")]
        public JsonResult Empleados()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorAdelanto.ListarEmpleados(), settings);
        }

        [HttpPost]
        [Route("api/Adelantos/Adelanto")]
        public JsonResult Adelanto([FromBody] Adelanto item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorAdelanto.RealizarAdelanto(item));
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        [Route("api/Adelantos/Adelantos")]
        public JsonResult Adelantos()
        {
            return Json(controladorAdelanto.ListarAdelantos(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{cedula}")]
        [Route("api/Adelantos/AdelantosEmpleado")]
        public JsonResult Adelantos(int cedula)
        {
            return Json(controladorAdelanto.ListarAdelantosXEmpleado(cedula), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}