using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Newtonsoft.Json;

namespace LogicaDeAppsCore
{
    class ControladorUsuario: IControladorUsuario
    {
        public class Root
        {
            public List<Dictionary<string, object>> Data { get; set; }
        }

        public class RootRespuestas
        {
            public Object Data { get; set; }
        }

        private string contraseña;
        private Usuario usuario;

        public bool EnviarMail(Usuario usuario)
        {
            return true;
        }

        public Usuario BuscarUsuario(string mail)
        {
            return new Usuario();
        }

        public string GetContraseña()
        {
            return contraseña;
        }

        public void SetContraseña(string pContraseña)
        {
            contraseña = pContraseña;
        }

        public async Task<Usuario> Login(string user, string pass)
        {
            try
            {
                //http://localhost:8080/api

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Usuarios/Login?" + "usuario=" + user + "&contrasenia=" + pass);

                Usuario usuarioLogueado = null;

                usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json);

                return usuarioLogueado;
                
            }
            catch(Exception ex)
            {
                throw new Exception("No existe un usuario registrado con el usuario y/o contraseña ingresados.");
            }
            
        }

        public bool ModificarNombreUsuario(string user)
        {
            return true;
        }

        public bool ComprobarNombreUsuario(string user)
        {
            return true; 
        }

        public void SetUsuario(Usuario pUsuario)
        {
            usuario = pUsuario;
        }


        public Usuario ModificarContraseña(string contraseñaNueva)
        {
            return new Usuario();
        }

        public Usuario ModificarEmail(Usuario pUsuario)
        {
            return new Usuario();
        }

        public Usuario GetUsuario()
        {
            return usuario;
        }

        public bool ComprobarContraseña(string contraseña)
        {
            return true;
        }

        public bool RecuperarContraseña(string email)
        {
            return true;
        }

        public bool Logout()
        {
            return true;
        }

        public bool ModificarUsuario(Usuario pUsuario)
        {
            return true;
        }
    }
}
