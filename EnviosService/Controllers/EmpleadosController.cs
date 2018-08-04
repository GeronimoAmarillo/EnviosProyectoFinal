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
    public class EmpleadosController : Controller
    {
        private IControladorEmpleado controladorEmpleado;

        public EmpleadosController()
        {
            controladorEmpleado = FabricaServicio.GetControladorEmpleado();
        }


        [HttpGet("{ci}")]
        [Route("api/Empleados/Empleado")]
        public JsonResult Empleado(int ci)
        {
            return Json(controladorEmpleado.BuscarEmpleado(ci), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{ci}")]
        [Route("api/Empleados/ExisteEmpleado")]
        public JsonResult ExisteEmpleado(int ci)
        {
            return Json(controladorEmpleado.ExisteEmpleado(ci), new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPut]
        [HttpPost]
        [Route("api/Empleados/Modificar")]
        [Route("api/Empleados/Alta")]
        public JsonResult Empleado([FromBody] Administrador item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorEmpleado.AltaEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());
                case "PUT":
                    return Json(controladorEmpleado.ModificarEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPut]
        [HttpPost]
        [Route("api/Empleados/ModificarCadete")]
        [Route("api/Empleados/AltaCadete")]
        public JsonResult EmpleadoCadete([FromBody] Cadete item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorEmpleado.AltaEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());
                case "PUT":
                    return Json(controladorEmpleado.ModificarEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpDelete]
        [Route("api/Empleados/EliminarEmpleado")]
        public JsonResult EliminarEmpleado([FromBody] Empleado item)
        {
           
                    return Json(controladorEmpleado.BajaEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());
            
        }
        [HttpGet]
        [Route("api/Empleados/Listar")]
        public JsonResult Locales()
        {

            return Json((controladorEmpleado.Listar()), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}