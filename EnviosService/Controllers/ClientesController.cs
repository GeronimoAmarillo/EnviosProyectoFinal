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
    [Route("api/Clientes")]
    public class ClientesController : Controller
    {
        private IControladorCliente controladorCliente;

        public ClientesController()
        {
            controladorCliente = FabricaServicio.GetControladorCliente();
        }

        [HttpGet("{rut}")]
        public JsonResult Cliente(int rut)
        {
            return Json(controladorCliente.BuscarCliente(rut), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{rut}")]
        public JsonResult ExisteCliente(int rut)
        {
            return Json(controladorCliente.ExisteCliente(rut), new Newtonsoft.Json.JsonSerializerSettings());
        }

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