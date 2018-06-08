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
    public class UsuariosController : Controller
    {
        private IControladorUsuario controladorUsuario;

        //Comentario de prueba
        public UsuariosController()
        {
            controladorUsuario = FabricaServicio.GetControladorUsuario();
        }

        [HttpGet("{usuario, contrasenia}")]
        [Route("Api/Usuarios/Login")]
        public JsonResult Login(string usuario, string contrasenia)
        {
            return Json(controladorUsuario.Login(usuario, contrasenia), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{mail}")]
        public JsonResult Usuario(string mail)
        {
            return Json(controladorUsuario.BuscarUsuario(mail), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult ComprobarUsuario([FromBody] string usuario)
        {
            return Json(controladorUsuario.ComprobarUser(usuario), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPut]
        public JsonResult Usuario([FromBody] Usuario usuario)
        {
            return Json(controladorUsuario.ModificarUsuario(usuario), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPut]
        public JsonResult Contrasenia([FromBody] string mail)
        {
            return Json(controladorUsuario.RecuperarContraseña(mail), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}