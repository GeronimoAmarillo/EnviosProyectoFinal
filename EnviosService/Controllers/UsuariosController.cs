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
    public class UsuariosController : Controller
    {
        private IControladorUsuario controladorUsuario;

        public UsuariosController()
        {
            controladorUsuario = FabricaServicio.GetControladorUsuario();
        }


        [HttpPost]
        [Route("Api/Usuarios/AltaUsuario")]
        public JsonResult AltaUsuario([FromBody] EntidadesCompartidasCore.Usuario unUsuario)
        {
            return Json(controladorUsuario.AltaUsuario(unUsuario), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        [Route("Api/Usuarios/RecuperacionContrasenia")]
        public JsonResult CodigoContraseña([FromBody] EntidadesCompartidasCore.Cliente unUsuario)
        {
            return Json(controladorUsuario.SetearCodigoRecuperarContraseña(unUsuario), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        [Route("Api/Usuarios/RecuperacionEmail")]
        public JsonResult CodigoEmail([FromBody] EntidadesCompartidasCore.Cliente unUsuario)
        {
            return Json(controladorUsuario.SetearCodigoModificarEmail(unUsuario), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        [Route("Api/Usuarios/VerificarCodigoContrasenia")]
        public JsonResult VerificarCodigoContraseña([FromBody] List<string> valores)
        {
            if (valores != null)
            {
                return Json(controladorUsuario.VerificarCodigoContraseña(valores[0], valores[1]), new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                return Json(null, new Newtonsoft.Json.JsonSerializerSettings());
            }

        }

        [HttpPost]
        [Route("Api/Usuarios/VerificarCodigoEmail")]
        public JsonResult VerificarCodigoEmail([FromBody] List<string> valores)
        {
            if (valores != null)
            {
                return Json(controladorUsuario.VerificarCodigoEmail(valores[0], valores[1]), new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                return Json(null, new Newtonsoft.Json.JsonSerializerSettings());
            }

        }

        [HttpGet("{usuario, contrasenia}")]
        [Route("api/Usuarios/Login")]
        public JsonResult Usuario(string usuario, string contrasenia)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorUsuario.Login(usuario, contrasenia), settings);
        }

        [HttpGet("{usuario, contrasenia}")]
        [Route("api/Usuarios/LoginDroid")]
        public JsonResult UsuarioAndroid(string usuario, string contrasenia)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            
            return Json(controladorUsuario.LoginDroid(usuario, contrasenia), settings);
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
        public JsonResult Usuario([FromBody] EntidadesCompartidasCore.Usuario usuario)
        {
            return Json(controladorUsuario.ModificarUsuario(usuario), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPut]
        public JsonResult Contrasenia([FromBody] string mail)
        {
            return Json(controladorUsuario.RecuperarContraseña(mail), new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        [Route("Api/Usuarios/ModificarContraseniaAdmin")]
        public JsonResult ModificarContrasenia([FromBody] EntidadesCompartidasCore.Administrador Admin)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorUsuario.ModificarContrasenia(Admin), settings);
        }

        [HttpPost]
        [Route("Api/Usuarios/ModificarContraseniaCliente")]
        public JsonResult ModificarContrasenia([FromBody] EntidadesCompartidasCore.Cliente CLi)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorUsuario.ModificarContrasenia(CLi), settings);
        }

        [HttpPost]
        [Route("Api/Usuarios/ModificarContraseniaCadete")]
        public JsonResult ModificarContrasenia([FromBody] EntidadesCompartidasCore.Cadete Cadete)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return Json(controladorUsuario.ModificarContrasenia(Cadete), settings);
        }
    }
}