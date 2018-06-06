using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidasCore;
using LogicaDeServicioCore;
using PersistenciaCore;
using Microsoft.EntityFrameworkCore;

namespace EnviosService.Controllers
{
    [Produces("application/json")]
    public class LocalesController : Controller
    {
        private IControladorLocal controladorLocal;

        public LocalesController()
        {
            controladorLocal = FabricaServicio.GetControladorLocal();
        }

        [HttpGet]
        [Route("api/Locales/Locales")]
        public JsonResult Locales()
        {

            var optionsBuilder = new DbContextOptions<EnviosContext>();

            return Json(controladorLocal.ListarLocales(optionsBuilder), new Newtonsoft.Json.JsonSerializerSettings());
        }

        
        [HttpGet("{nombre}")]
        [Route("api/Locales/Local")]
        public JsonResult Local(string nombre)
        {
            return Json(controladorLocal.BuscarLocal(nombre), new Newtonsoft.Json.JsonSerializerSettings());
        }

        
        [HttpGet("{nombre, direccion}")]
        [Route("api/Locales/ExisteLocal")]
        public JsonResult ExisteLocal(string nombre, string direccion)
        {
            return Json(controladorLocal.ExisteLocal(nombre, direccion), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPut]
        [HttpPost]
        public JsonResult Local([FromBody] Local item)
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