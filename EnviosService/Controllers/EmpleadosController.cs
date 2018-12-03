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
        [HttpPost]
        [Route("api/Empleados/Alta")]
        public JsonResult Empleado([FromBody] Administrador item)
        {
            return Json(controladorEmpleado.AltaEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());
        }
        
        [HttpPost]
        [Route("api/Empleados/Modificar")]
        public JsonResult EmpleadoModifcar([FromBody] Administrador item)
        {         
            return Json(controladorEmpleado.ModificarEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());                  
        }
        [HttpPost]
        [Route("api/Empleados/ModificarCadete")]
        public JsonResult EmpleadoModifcarCadete([FromBody] Cadete item)
        {
            return Json(controladorEmpleado.ModificarEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());

        }
        [HttpPost]
        [Route("api/Empleados/AltaCadete")]
        public JsonResult EmpleadoCadete([FromBody] Cadete item)
        {          
                    return Json(controladorEmpleado.AltaEmpleado(item), new Newtonsoft.Json.JsonSerializerSettings());
               
        }
        [HttpPost]
        [Route("api/Empleados/EliminarEmpleado")]
        public JsonResult EliminarEmpleado([FromBody] Empleado empleado)
        {
            return Json(controladorEmpleado.BajaEmpleado(empleado.Ci), new Newtonsoft.Json.JsonSerializerSettings());            
        }
        [HttpGet]
        [Route("api/Empleados/Listar")]
        public JsonResult Locales()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorEmpleado.Listar(), settings);
        }
    }
}