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
    
    public class PaletsController : Controller
    {
        private IControladorPalet controladorPalet;

        public PaletsController()
        {
            controladorPalet = FabricaServicio.GetControladorPalet();
        }

        [Route("api/Palets/Clientes")]
        [HttpGet]
        public JsonResult Clientes()
        {
            return Json(controladorPalet.ListarClientes(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Palets/Galpon")]
        [HttpGet("{id}")]
        public JsonResult Galpon(int id)
        {
            return Json(controladorPalet.BuscarGalpon(id), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Palets/Buscar")]
        [HttpGet("{id}")]
        public JsonResult Palet(int id)
        {
            return Json(controladorPalet.BuscarPalet(id), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Palets/Palet")]
        [HttpPost]
        [HttpDelete]
        public JsonResult Palet([FromBody] Palet item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorPalet.AltaPalet(item), new Newtonsoft.Json.JsonSerializerSettings());
                case "DELETE":
                    return Json(controladorPalet.BajaPalet(item), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}