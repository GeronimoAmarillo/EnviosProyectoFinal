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
    class ControladorReparacion : IControladorReparacion
    {
        private Reparacion reparacion;

        public Reparacion GetReparacion()
        {
            return reparacion;
        }

        public void SetReparacion(Reparacion pReparacion)
        {
            reparacion = pReparacion;
        }

        public bool RegistrarReparacion(Reparacion reparacion)
        {
            try
            {

                HttpClient client = new HttpClient();

                string url = ConexionREST.ConexionReparaciones + "/Reparacion";

                var content = new StringContent(JsonConvert.SerializeObject(reparacion), Encoding.UTF8, "application/json");

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

        public async Task<List<Vehiculo>> ListarVehiculos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionReparaciones + "/Vehiculos");

                List<Vehiculo> vehiculos = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                

                vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(json, settings);

                return vehiculos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los vehiculos.");
            }
        }

        public async Task<Vehiculo> SeleccionarVehiculo(string matricula)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionReparaciones + "/Vehiculo?matricula=" + matricula);

                Vehiculo vehiculo = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                vehiculo = JsonConvert.DeserializeObject<Vehiculo>(json, settings);

                return vehiculo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el vehiculo.");
            }
        }

        public void IniciarRegistroReparacion()
        {

        }
    }
}
