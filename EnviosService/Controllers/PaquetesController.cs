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
    [Route("api/Paquetes")]
    public class PaquetesController : Controller
    {

        private IControladorPaquete controladorPaquete;

        public PaquetesController()
        {
            controladorPaquete = FabricaServicio.GetControladorPaquete();
        }


        [HttpGet("{numReferencia}")]
        public JsonResult Paquete(int numReferencia)
        {
            return Json(controladorPaquete.BuscarPaquete(numReferencia), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{nombre}")]
        public JsonResult Local(string nombre)
        {
            return Json(controladorPaquete.BuscarLocal(nombre), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        public JsonResult Locales(string nombre)
        {
            return Json(controladorPaquete.ListarLocales(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{tipoLista, cedula}")]
        public JsonResult Paquetes(string tipo, int cedula)
        {
            switch (tipo)
            {
                case "E":
                    return Json(controladorPaquete.ListarPaquetesEnviadosXCliente(cedula), new Newtonsoft.Json.JsonSerializerSettings());
                case "R":
                    return Json(controladorPaquete.ListarPaquetesRecibidosXCliente(cedula), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
        
        [HttpPost]
        public JsonResult Reclamo([FromBody] string item)
        {
            return Json(controladorPaquete.RealizarReclamo(item));
        }
    }
}