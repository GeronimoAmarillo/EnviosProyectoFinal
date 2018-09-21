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
    
    public class MultasController : Controller
    {
        private IControladorMulta controladorMulta;

        public MultasController()
        {
            controladorMulta = FabricaServicio.GetControladorMulta();
        }


        [HttpGet]
        [Route("api/Multas/Vehiculos")]
        public JsonResult Vehiculos(int ci)
        {
            return Json(controladorMulta.ListarVehiculos(), new Newtonsoft.Json.JsonSerializerSettings());
        }
        
        [HttpPost]
        [Route("api/Multas/Alta")]
        public JsonResult Multas([FromBody] Multa item)
        {
            return Json(controladorMulta.RegistrarMulta(item), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}