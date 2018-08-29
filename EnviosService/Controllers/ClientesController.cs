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
    
    public class ClientesController : Controller
    {
        private IControladorCliente controladorCliente;

        public ClientesController()
        {
            controladorCliente = FabricaServicio.GetControladorCliente();
        }
        [Route("api/Clientes/Buscar")]
        [HttpGet("{rut}")]
        public JsonResult Cliente(int rut)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return Json(controladorCliente.BuscarCliente(rut), settings);
        }

        [Route("api/Clientes/Existe")]
        [HttpGet("{rut}")]
        public JsonResult ExisteCliente(int rut)
        {
            return Json(controladorCliente.ExisteCliente(rut), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Clientes/Alta")]
        [Route("api/Clientes/Modificar")]
        [Route("api/Clientes/Cliente")]
        [HttpPut]
        [HttpPost]
        public JsonResult Cliente([FromBody] Cliente cliente)
        {
            switch (Request.Method.ToString())
            {
                case "POST":
                    return Json(controladorCliente.AltaCliente(cliente), new Newtonsoft.Json.JsonSerializerSettings());
                case "PUT":
                    return Json(controladorCliente.ModificarCliente(cliente), new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json("Accion Http Desconocida", new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}