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
    [Route("api/Adelantos")]
    public class AdelantosController : Controller
    {
        private IControladorAdelanto controladorAdelanto;

        public AdelantosController()
        {
            controladorAdelanto = FabricaServicio.GetControladorAdelanto();
        }

        //GET /Api/Empleados

        [HttpGet("{cedula}")]
        public JsonResult Empleado(int cedula)
        {
            return Json(controladorAdelanto.BuscarEmpleado(cedula), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        public JsonResult Empleados()
        {
            return Json(controladorAdelanto.ListarEmpleados(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult Adelantos([FromBody] Adelanto item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorAdelanto.RealizarAdelanto(item));
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}