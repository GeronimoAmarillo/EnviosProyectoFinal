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
    class ControladorCliente: IControladorCliente
    {
        private Cliente cliente;

        public bool ExisteCliente(int rut)
        {
            return true;
        }

        public async Task<bool> ExisteClienteXEmail(string email)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionClientes + "/ExisteXEmail?" + "email=" + email);

                bool existe = false;

                existe = JsonConvert.DeserializeObject<bool>(json);

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Cliente con los datos ingresados.");
            }
        }

        public async Task<Cliente> BuscarClienteXEmail(string email)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionClientes + "/BuscarXEmail?" + "email=" + email);

                Cliente cliente = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                cliente = JsonConvert.DeserializeObject<Cliente>(json, settings);

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Cliente.");
            }
        }

        public void IniciarRegistroCliente()
        {

        }

        public Cliente GetCliente()
        {
            return cliente;
        }

        public Cliente BuscarCliente(int rut)
        {
            return new Cliente();
        }

        public bool ModificarCliente(Cliente pCliente)
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = ConexionREST.ConexionClientes + "/Modificar";

                var content = new StringContent(JsonConvert.SerializeObject(pCliente), Encoding.UTF8, "application/json");

                var result = client.PutAsync(url, content).Result;

                var contentResult = result.Content.ReadAsStringAsync();

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
                throw new Exception("ERROR!: " + ex.Message);
            }
        }

        public void SetCliente(Cliente pCliente)
        {
            cliente = pCliente;
        }

        public bool RegistrarCliente(Cliente pCliente)
        {
            return true;
        }
    }
}
