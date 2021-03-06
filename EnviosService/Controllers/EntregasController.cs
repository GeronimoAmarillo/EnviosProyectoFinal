﻿using System;
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
    
    public class EntregasController : Controller
    {
        private IControladorEntrega controladorEntrega;
        private IControladorEmpleado controladorEmpleado;

        public EntregasController()
        {
            controladorEntrega = FabricaServicio.GetControladorEntrega();
            controladorEmpleado = FabricaServicio.GetControladorEmpleado();
        }

        [Route("api/Entregas/Listar")]
        [HttpGet]
        public JsonResult Entregas(int ci)
        {
            return Json(controladorEntrega.ListarEntregas(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Entregas/Buscar")]
        [HttpGet]
        public JsonResult Buscar(int codigo)
        {
            return Json(controladorEntrega.BuscarEntrega(codigo), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Entregas/Asignar")]
        [HttpPost]
        public JsonResult Asignar([FromBody] Entrega item)
        {
            return Json(controladorEntrega.AsignarEntrega(item));
        }

        [Route("api/Entregas/Levantar")]
        [HttpPost]
        public JsonResult Levantar([FromBody] Entrega item)
        {
            return Json(controladorEntrega.LevantarEntrega(item));
        }

        [Route("api/Entregas/Entregar")]
        [HttpPost]
        public JsonResult Entregas([FromBody] Entrega item)
        {
            return Json(controladorEntrega.Entregar(item));
        }

        [HttpGet]
        [Route("api/Entregas/Locales")]
        public JsonResult Locales()
        {
            return Json(controladorEntrega.ListarLocales(), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        [Route("api/Entregas/Cadetes")]
        public JsonResult Cadetes()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json((controladorEmpleado.ListarCadetes()), settings);
        }

        [Route("api/Entregas/Clientes")]
        [HttpGet]
        public JsonResult Clientes()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return Json(controladorEntrega.ListarClientes(), settings);
        }
    }
}