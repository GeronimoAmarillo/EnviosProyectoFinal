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
    //[Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private IControladorUsuario controladorUsuario;

        public UsuariosController()
        {
            controladorUsuario = FabricaServicio.GetControladorUsuario();
        }

        
        [HttpPost]
        [Route("Api/Usuarios/AltaUsuario")]
        public JsonResult AltaUsuario([FromBody] Usuario unUsuario)
        {
            return Json(controladorUsuario.AltaUsuario(unUsuario), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet("{usuario, contrasenia}")]
        [Route("api/Usuarios/Login")]
        public JsonResult Usuario(string usuario, string contrasenia)
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

        [HttpPut]
        [Route("Api/Usuarios/ModificarContrasenia")]
        public JsonResult ModificarContrasenia([FromBody] Administrador usuario)
        {
            return Json(controladorUsuario.ModificarContrasenia(usuario), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}