using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidas;
using LogicaDeServicio;

namespace EnviosService.Controllers
{
    [Produces("application/json")]
    [Route("api/Empleados")]
    public class EmpleadosController : Controller
    {
        private IControladorEmpleado controladorEmpleado;

        public EmpleadosController()
        {
            controladorEmpleado = FabricaServicio.GetControladorEmpleado();
        }


        [HttpGet("{ci}")]
        public JsonResult Empleado(int ci)
        {
            return Json(controladorEmpleado.BuscarEmpleado(ci), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{ci}")]
        public JsonResult ExisteEmpleado(int ci)
        {
            return Json(controladorEmpleado.ExisteEmpleado(ci), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPut]
        [HttpPost]
        [HttpDelete]
        public JsonResult Empleado([FromBody] Empleado item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorEmpleado.AltaEmpleado(item));
                case "PUT":
                    return Json(controladorEmpleado.ModificarEmpleado(item));
                case "DELETE":
                    return Json(controladorEmpleado.BajaEmpleado(item));
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}