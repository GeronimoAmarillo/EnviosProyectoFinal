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
    public class BalancesController : Controller
    {
        private IControladorBalance controladorBalance;

        public BalancesController()
        {
            controladorBalance = FabricaServicio.GetControladorBalance();
        }

        [HttpGet("{mes, año}")]
        [Route("api/Balances/Balance")]
        public JsonResult Balance(string mes, int año)
        {
            return Json(controladorBalance.ConsultarBalanceMensual(mes, año), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{año}")]
        public JsonResult Balances(int año)
        {
            return Json(controladorBalance.ConsultarBalanceAnual(año), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{fechaDesde, fechaHasta}")]
        [Route("api/Balances/ObtenerBalanceAnual")]
        public JsonResult BalanceAnual(DateTime fechaDesde, DateTime fechaHasta)
        {
            return Json(controladorBalance.ObtenerBalanceAnual(fechaDesde, fechaHasta), new Newtonsoft.Json.JsonSerializerSettings());
        }


        [HttpGet("{fecha}")]
        [Route("api/Balances/BuscarRegistro")]
        public JsonResult Registro(DateTime fecha)
        {
            return Json(controladorBalance.ObtenerRegistro(fecha), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{fechaInicio, fechaFinal}")]
        [Route("api/Balances/BuscarRegistros")]
        public JsonResult Registro(DateTime fechaInicio, DateTime fechaFinal)
        {
            return Json(controladorBalance.ObtenerRegistros(fechaInicio, fechaFinal), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}