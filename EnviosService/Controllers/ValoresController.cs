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
    
    public class ValoresController : Controller
    {
        private IControladorValores controladorValores;

        public ValoresController()
        {
            controladorValores = FabricaServicio.GetControladorValores();
        }

        [HttpGet]
        [Route("api/Valores/Gastos")]
        public JsonResult Gastos()
        {
            return Json(controladorValores.ListarGastos(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        public JsonResult Ingresos()
        {
            return Json(controladorValores.ListarIngresos(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        [Route("api/Valores/Gasto")]
        public JsonResult Gasto([FromBody] Gasto gasto)
        {
            return Json(controladorValores.RegistrarGasto(gasto), new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpPost]
        public JsonResult Ingreso([FromBody] Ingreso ingreso)
        {
            return Json(controladorValores.RegistrarIngreso(ingreso), new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpPost]
        [Route("api/Valores/Impuesto")]
        public JsonResult Impuesto([FromBody] Impuesto impuesto)
        {
            return Json(controladorValores.RegistrarImpuesto(impuesto), new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpGet]
        [Route("api/Valores/Impuestos")]
        public JsonResult Impuestos()
        {
            return Json(controladorValores.ListarImpuestos(), new Newtonsoft.Json.JsonSerializerSettings());

        }


    }
}