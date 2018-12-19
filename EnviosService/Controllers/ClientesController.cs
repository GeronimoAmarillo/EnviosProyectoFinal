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
        public JsonResult Cliente(long rut)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return Json(controladorCliente.BuscarCliente(rut), settings);
        }

        [Route("api/Clientes/Clientes")]
        [HttpGet]
        public JsonResult Clientes()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return Json(controladorCliente.ListarClientes(), settings);
        }

        [Route("api/Clientes/BuscarXEmail")]
        [HttpGet("{email}")]
        public JsonResult ClienteXEmail(string email)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return Json(controladorCliente.BuscarClienteXEmail(email), settings);
        }

        [Route("api/Clientes/Existe")]
        [HttpGet("{rut}")]
        public JsonResult ExisteCliente(long rut)
        {
            return Json(controladorCliente.ExisteCliente(rut), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Clientes/ExisteXEmail")]
        [HttpGet("{email}")]
        public JsonResult ExisteClienteXEmail(string email)
        {
            return Json(controladorCliente.ExisteClienteXEmail(email), new Newtonsoft.Json.JsonSerializerSettings());
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