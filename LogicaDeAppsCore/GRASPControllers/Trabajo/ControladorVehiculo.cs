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
    class ControladorVehiculo: IControladorVehiculo
    {
        private Vehiculo vehiculo;
        private string matricula;
        private List<Cadete> cadetesDisponibles;

        public Vehiculo GetVehiculo()
        {
            return vehiculo;
        }

        public void SetMatricula(string matricula)
        {
            vehiculo.Matricula = matricula;
        }

        public async Task<List<Cadete>> ListarCadetesDisponibles()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionVehiculos + "/Cadetes");

                List<Cadete> cadetes = null;

                cadetes = JsonConvert.DeserializeObject<List<Cadete>>(json);

                return cadetes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar listar los cadetes disponibles.");
            }
        }

        public Cadete GetCadete()
        {
            return vehiculo.Cadetes;
        }

        public string GetMatricula()
        {
            return matricula;
        }

        public bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            try
            {

                HttpClient client = new HttpClient();

                string url = ConexionREST.ConexionVehiculos + "/Modificar";

                var content = new StringContent(JsonConvert.SerializeObject(pVehiculo), Encoding.UTF8, "application/json");

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

        public Cadete SeleccionarCadete(int ci)
        {
            return new Cadete();
        }

        public List<Cadete> GetCadetes()
        {
            return new List<Cadete>();
        }

        public void SetCadetes(List<Cadete> pCadetesDisponibles)
        {
            cadetesDisponibles = pCadetesDisponibles;
        }

        public void SetVehiculo(Vehiculo pVehiculo)
        {
            vehiculo = pVehiculo;
        }

        public bool EliminarVehiculo(Vehiculo vehiculo)
        {
            return true;
        }

        public Vehiculo BuscarVehiculo(string matricula)
        {
            return new Vehiculo();
        }

        public Vehiculo ContemplarTipo()
        {
            return new Vehiculo();
        }

        public bool AltaVehiculo(Vehiculo pVehiculo)
        {
            try
            {

                HttpClient client = new HttpClient();

                if (ExisteVehiculo(pVehiculo.Matricula).ToString().ToUpper() == "TRUE")
                {
                    throw new Exception("El vehiculo que desea dar de alta ya existe en el sistema.");
                }

                string url = "";

                if (pVehiculo is Automobil)
                {
                     url = ConexionREST.ConexionVehiculos + "/Auto";
                }
                else if (pVehiculo is Camion)
                {
                     url = ConexionREST.ConexionVehiculos + "/Camion";
                }
                else if (pVehiculo is Camioneta)
                {
                     url = ConexionREST.ConexionVehiculos + "/Camioneta";
                }
                else
                {
                     url = ConexionREST.ConexionVehiculos + "/Moto";
                }
                

                var content = new StringContent(JsonConvert.SerializeObject(pVehiculo), Encoding.UTF8, "application/json");

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

        public async Task<bool> ExisteVehiculo(string matricula)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionVehiculos + "/Existe?" + "matricula=" + matricula);

                bool existe = false;

                existe = JsonConvert.DeserializeObject<bool>(json);

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Vehiculo con los datos ingresados.");
            }
        }

        public async Task<List<Vehiculo>> ListarVehiculos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionVehiculos + "/Vehiculos");

                List<Vehiculo> vehiculos = null;

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                //JsonConverter[] conv = new JsonConverter[] { new MessageConverter() };

                vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(json, settings);

                return vehiculos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los vehiculos.");
            }
        }
    }
}
