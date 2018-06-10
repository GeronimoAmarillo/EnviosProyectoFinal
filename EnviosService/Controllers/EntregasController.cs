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
    [Route("api/Entregas")]
    public class EntregasController : Controller
    {
        private IControladorEntrega controladorEntrega;

        public EntregasController()
        {
            controladorEntrega = FabricaServicio.GetControladorEntrega();
        }


        [HttpGet]
        public JsonResult Entregas(int ci)
        {
            return Json(controladorEntrega.ListarEntregas(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult Entrega([FromBody] Entrega item)
        {
            return Json(controladorEntrega.AltaEntrega(item));
        }

        [HttpPost]
        public JsonResult Entregas([FromBody] List<Entrega> item)
        {
            return Json(controladorEntrega.Entregar(item));
        }
    }
}