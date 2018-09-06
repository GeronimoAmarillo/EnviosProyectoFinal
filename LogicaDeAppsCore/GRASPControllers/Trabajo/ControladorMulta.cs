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
    class ControladorMulta:IControladorMulta
    {
        private List<Vehiculo> vehiculos;
        private Multa multa;

        public void IniciarRegistroMulta()
        {

        }

        public List<Vehiculo> ListarVehiculos()
        {
            return new List<Vehiculo>();
        }

        public Vehiculo SeleccionarVehiculo(string matricula)
        {
            return new Vehiculo();
        }

        public Multa GetMulta()
        {
            return multa;
        }

        public void SetMulta(Multa pMulta)
        {
            multa = pMulta;
        }

        public void SetVehiculo(Vehiculo pVehiculo)
        {
            multa.Vehiculos = pVehiculo;
        }

        public List<Vehiculo> GetVehiculos()
        {
            return vehiculos;
        }

        public async Task<bool> RegistrarMulta(Multa pMulta)
        {
            try
            {
                bool exito = false;
                var httpClient = new HttpClient();
                var EnvioJson = JsonConvert.SerializeObject(pMulta);
                string url = ConexionREST.ConexionMultas + "/Multas";
                HttpResponseMessage retorno = await httpClient.PostAsync(url, new StringContent(EnvioJson, Encoding.UTF8, "application/json"));
                string resultado = await retorno.Content.ReadAsStringAsync();

                if (retorno.IsSuccessStatusCode && resultado == "true")
                    exito = true;
                return exito;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar registrar la multa: " + ex.Message);
            }
        }

    }
}
