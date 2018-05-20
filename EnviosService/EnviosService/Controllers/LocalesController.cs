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
    [Route("api/Locales")]
    public class LocalesController : Controller
    {
        private IControladorLocal controladorLocal;

        public LocalesController()
        {
            controladorLocal = FabricaServicio.GetControladorLocal();
        }


        [HttpGet("{nombre}")]
        public JsonResult Local(string nombre)
        {
            return Json(controladorLocal.BuscarLocal(nombre), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{nombre, direccion}")]
        public JsonResult ExisteLocal(string nombre, string direccion)
        {
            return Json(controladorLocal.ExisteLocal(nombre, direccion), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPut]
        [HttpPost]
        public JsonResult Local([FromBody] Locales item)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorLocal.AltaLocal(item), new Newtonsoft.Json.JsonSerializerSettings());
                case "PUT":
                    return Json(controladorLocal.ModificarLocal(item), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}