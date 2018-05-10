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
    [Route("api/Palets")]
    public class PaletsController : Controller
    {
        private IControladorPalet controladorPalet;

        public PaletsController()
        {
            controladorPalet = FabricaServicio.GetControladorPalet();
        }

        [HttpGet]
        public JsonResult Clientes()
        {
            return Json(controladorPalet.ListarClientes(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{id}")]
        public JsonResult Galpon(int id)
        {
            return Json(controladorPalet.BuscarGalpon(id), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{id}")]
        public JsonResult Palet(int id)
        {
            return Json(controladorPalet.BuscarPalet(id), new Newtonsoft.Json.JsonSerializerSettings());
        }
        

        [HttpPost]
        [HttpDelete]
        public JsonResult Palet([FromBody] Palets item)
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