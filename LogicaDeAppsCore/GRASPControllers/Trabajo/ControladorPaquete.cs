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
    class ControladorPaquete:IControladorPaquete
    {
        private Reclamo reclamo;
        private Paquete paquete;

        public bool RealizarReclamo(Reclamo reclamo)
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = ConexionREST.ConexionPaquetes + "/Reclamo";

                var content = new StringContent(JsonConvert.SerializeObject(reclamo), Encoding.UTF8, "application/json");

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

        public Paquete GetPaquete()
        {
            return paquete;
        }

        public async Task<Paquete> BuscarPaquete(int codigo)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionPaquetes + "/Buscar?numReferencia=" + codigo);

                Paquete paquete = null;

                paquete = JsonConvert.DeserializeObject<Paquete>(json);

                return paquete;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el paquete.");
            }
        }

        public void SetPaquete(Paquete pPaquete)
        {
            paquete = pPaquete;
        }

    }
}
