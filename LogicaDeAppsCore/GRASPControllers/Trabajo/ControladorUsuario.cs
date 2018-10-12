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

        public string CrearContrasenia()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_@*#.";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int charNum = 1;
            while (charNum < 25)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
                charNum++;
            }
            return res.ToString();
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
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionUsuarios+"/Login?" + "usuario=" + user + "&contrasenia=" + pass);

                Usuario usuarioLogueado = null;
                Administrador admin = null;
                Cadete cadete = null;
                Cliente cliente = null;


                usuarioLogueado = JsonConvert.DeserializeObject<Administrador>(json);

                admin = (Administrador)usuarioLogueado;

                if (admin == null || admin.Tipo == null)
                {
                    usuarioLogueado = JsonConvert.DeserializeObject<Cadete>(json);
                    cadete = (Cadete)usuarioLogueado;

                    if (cadete == null || cadete.TipoLibreta == null)
                    {
                        usuarioLogueado = JsonConvert.DeserializeObject<Cliente>(json);
                        cliente = (Cliente)usuarioLogueado;
                    }
                }

                return usuarioLogueado;
                
            }
            catch(Exception ex)
            {
                throw new Exception("No existe un usuario registrado con el usuario y/o contraseña ingresados.");
            }
            
        }

        public async Task<bool> AltaUsuario(Usuario unUsuario)
        {
            try
            {
                bool exito = false;

                var httpClient = new HttpClient();

                var EnvioJson = JsonConvert.SerializeObject(unUsuario);
                
                HttpResponseMessage retorno = await httpClient.PostAsync("http://localhost:8080/api/Clientes/Alta", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));
                
                var contentResult = retorno.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Usuario: " + ex.Message);
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


        public async Task<bool> ModificarContraseña(Administrador pAdmin)
        {
            try
            {
                bool exito = false;
                var httpClient = new HttpClient();
                var EnvioJson = JsonConvert.SerializeObject(pAdmin);

                HttpResponseMessage retorno = await httpClient.PutAsync("http://localhost:8080/Api/Usuarios/ModificarContrasenia", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));
                string resultado = await retorno.Content.ReadAsStringAsync();

                if (retorno.IsSuccessStatusCode && resultado == "true")
                    exito = true;
                return exito;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar contraseña: " + ex.Message);
            }
        }

        public async Task<Usuario> ModificarEmail(Usuario pUsuario)
        {

            ClienteEmailNuevo cliente = null;
            long rut;

            try
            {

                if (pUsuario != null && pUsuario is ClienteEmailNuevo)
                {
                    cliente = (ClienteEmailNuevo)pUsuario;
                    rut = cliente.RUT;

                    bool exito = false;

                    var httpClient = new HttpClient();
                    var EnvioJson = JsonConvert.SerializeObject(pUsuario);

                    var result = await httpClient.PutAsync(ConexionREST.ConexionClientes + "/Modificar", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));

                    var contentResult = result.Content.ReadAsStringAsync();

                    if (contentResult.Result.ToUpper() == "TRUE")
                    {
                        exito = true;
                    }
                    else
                    {
                        exito = false;
                    }

                    if (exito)
                    {
                        try
                        {
                            //http://localhost:8080/api

                            Cliente clienteModificado = new Cliente();

                            var json = await httpClient.GetStringAsync(ConexionREST.ConexionClientes + "/Buscar?rut=" + rut);

                            JsonSerializerSettings settings = new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.Objects
                            };

                            clienteModificado = JsonConvert.DeserializeObject<Cliente>(json, settings);
                            
                            return clienteModificado;

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Ocurrio un error al recuperar el usuario modificado.");
                        }
                    }
                }

                return new Usuario();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Usuario: " + ex.Message);
            }
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

        public async Task<bool> ModificarUsuario(Usuario pUsuario)
        {
            try
            {
                bool exito = false;
                var httpClient = new HttpClient();
                var EnvioJson = JsonConvert.SerializeObject(pUsuario);

                HttpResponseMessage retorno = await httpClient.PostAsync("http://localhost:8080/api/Usuarios/Usuario", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));
                string resultado = await retorno.Content.ReadAsStringAsync();

                if (retorno.IsSuccessStatusCode && resultado == "true")
                    exito = true;
                return exito;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar: " + ex.Message);
            }
        }



        public async Task<bool> SetearCodigoContraseña(Usuario unUsuario)
        {
            try
            {
                bool exito = false;

                var httpClient = new HttpClient();

                var EnvioJson = JsonConvert.SerializeObject(unUsuario);

                HttpResponseMessage retorno = await httpClient.PostAsync(ConexionREST.ConexionUsuarios + "/RecuperacionContrasenia", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));

                var contentResult = retorno.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Usuario: " + ex.Message);
            }
        }

        public async Task<bool> SetearCodigoEmail(Usuario unUsuario)
        {
            try
            {
                bool exito = false;

                var httpClient = new HttpClient();

                var EnvioJson = JsonConvert.SerializeObject(unUsuario);

                HttpResponseMessage retorno = await httpClient.PostAsync(ConexionREST.ConexionUsuarios + "/RecuperacionEmail", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));

                var contentResult = retorno.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Usuario: " + ex.Message);
            }
        }


        public async Task<bool> VerificarCodigoContraseña(string codigo, string email)
        {
            try
            {
                bool exito = false;

                var httpClient = new HttpClient();

                List<string> valores = new List<string>();
                valores.Add(email);
                valores.Add(codigo);

                var EnvioJson = JsonConvert.SerializeObject(valores);

                HttpResponseMessage retorno = await httpClient.PostAsync(ConexionREST.ConexionUsuarios + "/VerificarCodigoContrasenia", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));

                var contentResult = retorno.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Usuario: " + ex.Message);
            }
        }

        public async Task<bool> VerificarCodigoEmail(string codigo, string email)
        {
            try
            {
                bool exito = false;

                var httpClient = new HttpClient();

                List<string> valores = new List<string>();
                valores.Add(email);
                valores.Add(codigo);

                var EnvioJson = JsonConvert.SerializeObject(valores);

                HttpResponseMessage retorno = await httpClient.PostAsync(ConexionREST.ConexionUsuarios + "/VerificarCodigoEmail", new StringContent(EnvioJson, Encoding.UTF8, "application/json"));

                var contentResult = retorno.Content.ReadAsStringAsync();

                if (contentResult.Result.ToUpper() == "TRUE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Usuario: " + ex.Message);
            }
        }
    }
}
