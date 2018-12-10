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
    
    public class PaquetesController : Controller
    {
        private IControladorPaquete controladorPaquete;
        private IControladorEmpleado controladorEmpleado;

        public PaquetesController()
        {
            controladorPaquete = FabricaServicio.GetControladorPaquete();
            controladorEmpleado = FabricaServicio.GetControladorEmpleado();
        }


        [Route("api/Paquetes/Buscar")]
        [HttpGet("{numReferencia}")]
        public JsonResult Paquete(int numReferencia)
        {
            return Json(controladorPaquete.BuscarPaquete(numReferencia), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Paquetes/Localizar")]
        [HttpGet("{numReferencia, rut}")]
        public JsonResult Localizar(int numReferencia, int rut)
        {
            return Json(controladorEmpleado.ConsultarLocalizacion(numReferencia, rut), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Paquetes/BuscarIndividual")]
        [HttpGet("{numReferencia, cliente}")]
        public JsonResult PaqueteIndividual(int numReferencia, int cliente)
        {
            return Json(controladorPaquete.BuscarPaqueteIndividual(numReferencia, cliente), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{nombre}")]
        public JsonResult Local(string nombre)
        {
            return Json(controladorPaquete.BuscarLocal(nombre), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Paquetes/ListarEnviados")]
        [HttpGet("{rut}")]
        public JsonResult Enviados(int rut)
        {
            return Json(controladorPaquete.ListarPaquetesEnviadosXCliente(rut), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [Route("api/Paquetes/ListarRecibidos")]
        [HttpGet("{rut}")]
        public JsonResult Recibidos(int rut)
        {
            return Json(controladorPaquete.ListarPaquetesRecibidosXCliente(rut), new Newtonsoft.Json.JsonSerializerSettings());
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

        [Route("api/Paquetes/Reclamo")]
        [HttpPost]
        public JsonResult Reclamo([FromBody] EntidadesCompartidasCore.Reclamo item)
        {
            return Json(controladorPaquete.RealizarReclamo(item));
        }
        [Route("api/Paquetes/ListarReclamos")]
        [HttpGet]
        public JsonResult ListarReclamos()
        {
            return Json(controladorPaquete.ListarReclamos(), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}