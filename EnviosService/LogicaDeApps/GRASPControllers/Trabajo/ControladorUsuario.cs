using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;
using Newtonsoft.Json;

namespace LogicaDeApps
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
        private Usuarios usuario;

        public bool EnviarMail(DTUsuario usuario)
        {
            return true;
        }

        public Usuarios BuscarUsuario(string mail)
        {
            return new Usuarios();
        }

        public string GetContraseña()
        {
            return contraseña;
        }

        public void SetContraseña(string pContraseña)
        {
            contraseña = pContraseña;
        }

        public async Task<DTUsuario> Login(string user, string pass)
        {
            //http://localhost/EnviosService/Api

            var httpClient = new HttpClient();
            var json =await httpClient.GetStringAsync("http://localhost/EnviosService/Api/Usuarios");

            var data = JsonConvert.DeserializeObject<Root>(json).Data;

            DTUsuario usuarioLogueado = new DTUsuario();

            foreach (var d in data)
            {
                foreach (var u in d)
                {
                    switch (u.Key.ToString())
                    {
                        case "Id":
                            usuarioLogueado.Id = Convert.ToInt32(u.Value);
                            break;
                        case "Nombre":
                            usuarioLogueado.Nombre = u.Value.ToString();
                            break;
                        case "NombreUsuario":
                            usuarioLogueado.NombreUsuario = u.Value.ToString();
                            break;
                        case "Email":
                            usuarioLogueado.Email = u.Value.ToString();
                            break;
                        case "Contraseña":
                            usuarioLogueado.Contraseña = u.Value.ToString();
                            break;
                        case "Direccion":
                            usuarioLogueado.Direccion = u.Value.ToString();
                            break;
                        case "Telefono":
                            usuarioLogueado.Telefono = u.Value.ToString();
                            break;
                    }
                }
            }

            return usuarioLogueado;
        }

        public bool ModificarNombreUsuario(string user)
        {
            return true;
        }

        public bool ComprobarNombreUsuario(string user)
        {
            return true; 
        }

        public void SetUsuario(Usuarios pUsuario)
        {
            usuario = pUsuario;
        }


        public Usuarios ModificarContraseña(string contraseñaNueva)
        {
            return new Usuarios();
        }

        public Usuarios ModificarEmail(DTUsuario pUsuario)
        {
            return new Usuarios();
        }

        public Usuarios GetUsuario()
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

        public bool ModificarUsuario(DTUsuario pUsuario)
        {
            return true;
        }
    }
}
