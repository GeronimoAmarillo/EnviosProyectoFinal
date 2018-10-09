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

        public bool RegistrarMulta(Multa pMulta)
        {
            try
            {

                HttpClient client = new HttpClient();

                string url = ConexionREST.ConexionMultas + "/Alta";

                var content = new StringContent(JsonConvert.SerializeObject(pMulta), Encoding.UTF8, "application/json");

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

    }
}
