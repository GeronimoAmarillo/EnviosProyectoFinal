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

            /*
            //http://localhost/EnviosService/Api

            var httpClient = new HttpClient();
            var json =await httpClient.GetStringAsync("http://localhost/EnviosService/Api/Usuarios");

            var data = JsonConvert.DeserializeObject<Root>(json).Data;

            Usuarios usuarioLogueado = new Usuarios();

            foreach (var d in data)
            {
                EmpleadoHelper empleado = new EmpleadoHelper();

                foreach (var e in d)
                {
                    switch (e.Key.ToString())
                    {
                        case "Ci":
                            empleado.Ci = Convert.ToInt32(e.Value);
                            break;
                        case "Nombre":
                            empleado.Nombre = e.Value.ToString();
                            break;
                        case "Apellido":
                            empleado.Apellido = e.Value.ToString();
                            break;
                        case "Edad":
                            empleado.Edad = Convert.ToInt32(e.Value);
                            break;
                        case "Puesto":
                            empleado.Puesto = e.Value.ToString();
                            break;
                        case "Sueldo":
                            empleado.Sueldo = Convert.ToDecimal(e.Value);
                            break;
                    }
                }
                empleados.Add(empleado);
            }

    */

            return new DTUsuario();
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
