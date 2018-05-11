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
    [Route("api/Valores")]
    public class ValoresController : Controller
    {
        private IControladorValores controladorValores;

        public ValoresController()
        {
            controladorValores = FabricaServicio.GetControladorValores();
        }

        [HttpGet]
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
        public JsonResult Gasto([FromBody] Gastos gasto)
        {
            return Json(controladorValores.RegistrarGasto(gasto), new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpPost]
        public JsonResult Ingreso([FromBody] Ingresos ingreso)
        {
            return Json(controladorValores.RegistrarIngreso(ingreso), new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpPost]
        public JsonResult Impuesto([FromBody] Impuestos impuesto)
        {
            return Json(controladorValores.RegistrarImpuesto(impuesto), new Newtonsoft.Json.JsonSerializerSettings());

        }


    }
}