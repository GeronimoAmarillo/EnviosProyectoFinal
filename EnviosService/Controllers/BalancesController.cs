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
    [Route("api/Balances")]
    public class BalancesController : Controller
    {
        private IControladorBalance controladorBalance;

        public BalancesController()
        {
            controladorBalance = FabricaServicio.GetControladorBalance();
        }

        [HttpGet("{mes, año}")]
        public JsonResult Balance(string mes, int año)
        {
            return Json(controladorBalance.ConsultarBalanceMensual(mes, año), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{año}")]
        public JsonResult Balances(int año)
        {
            return Json(controladorBalance.ConsultarBalanceAnual(año), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}