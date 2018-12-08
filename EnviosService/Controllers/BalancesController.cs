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
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorBalance.ConsultarBalanceMensual(mes, año), settings);
        }

        [HttpGet("{año}")]
        public JsonResult Balances(int año)
        {
            return Json(controladorBalance.ConsultarBalanceAnual(año), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{diaI, mesI, añoI, diaF, mesF, añoF}")]
        [Route("api/Balances/ObtenerBalanceAnual")]
        public JsonResult BalanceAnual(int diaI, int mesI, int añoI, int diaF, int mesF, int añoF)
        {
            DateTime fechaInicial = Convert.ToDateTime(diaI + "/" + mesI+ "/" + añoI);
            DateTime fechaFinal = Convert.ToDateTime(diaF + "/" + mesF + "/" + añoF);
            return Json(controladorBalance.ObtenerBalanceAnual(fechaInicial, fechaFinal), new Newtonsoft.Json.JsonSerializerSettings());
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