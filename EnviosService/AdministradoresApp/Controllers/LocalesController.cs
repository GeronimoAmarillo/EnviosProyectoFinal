using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidas;
using LogicaDeApps;
using AdministradoresApp.Models;

namespace EnviosService.Controllers
{
    [Produces("application/json")]
    [Route("api/Locales")]
    public class LocalesController : Controller
    {
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(DTLocal local)
        {
            return View();
        }
    }
}