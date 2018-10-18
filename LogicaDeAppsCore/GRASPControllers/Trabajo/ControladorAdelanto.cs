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
    class ControladorAdelanto : IControladorAdelanto
    {
        private Adelanto adelanto;
        public void IniciarRegistroAdelanto()
        {
            adelanto = new Adelanto();
        }

        public async Task<List<Empleado>> ListarEmpleados()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionAdelantos + "/Empleados");

                List<Empleado> empleados = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                //JsonConverter[] conv = new JsonConverter[] { new MessageConverter() };

                empleados = JsonConvert.DeserializeObject<List<Empleado>>(json, settings);

                return empleados;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los empleados.");
            }
        }

        public void SetAdelanto(Adelanto pAdelanto)
        {
            adelanto = pAdelanto;
        }

        public Adelanto GetAdelanto()
        {
            return adelanto;
        }

        public Empleado GetEmpleado()
        {
            return new Empleado();
        }

        public async Task<Empleado> SeleccionarEmpleado(int cedula)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionAdelantos + "/Empleado?cedula=" + cedula);

                Empleado empleado = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                empleado = JsonConvert.DeserializeObject<Empleado>(json, settings);

                return empleado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el empleado.");
            }
        }

        public bool RealizarAdelanto(Adelanto pAdelanto)
        {
            try
            {

                HttpClient client = new HttpClient();
                
                string url = ConexionREST.ConexionAdelantos + "/Adelanto";

                var content = new StringContent(JsonConvert.SerializeObject(pAdelanto), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

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

        public async Task<bool> verificarAdelantoSaldado(int cedula)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionAdelantos + "/Empleado/Habilitado?" + "cedula=" + cedula);

                bool existe = false;

                existe = JsonConvert.DeserializeObject<bool>(json);

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la capacidad de pedir adelanto del empleado.");
            }
        }
        public async Task<List<Adelanto>> ListarAdelantos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionAdelantos + "/Adelantos");

                List<Adelanto> adelantos = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                //JsonConverter[] conv = new JsonConverter[] { new MessageConverter() };

                adelantos = JsonConvert.DeserializeObject<List<Adelanto>>(json, settings);

                return adelantos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los adelantos.");
            }
        }

        public async Task<List<Adelanto>> ListarAdelantosXEmpleado(int cedula)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionAdelantos + "/AdelantosEmpleado?cedula=" + cedula);

                List<Adelanto> adelantos = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                //JsonConverter[] conv = new JsonConverter[] { new MessageConverter() };

                adelantos = JsonConvert.DeserializeObject<List<Adelanto>>(json, settings);

                return adelantos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los adelantos.");
            }
        }
    }
}
