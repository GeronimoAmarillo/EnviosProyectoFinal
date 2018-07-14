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
    class ControladorImpuesto: IControladorImpuesto
    {
        private Impuesto impuesto;

        public Impuesto GetImpuesto()
        {
            return impuesto;
        }

        public void SetImpuesto(Impuesto pImpuesto)
        {
            impuesto = pImpuesto;
        }

        public bool RegistrarImpuesto(Impuesto impuesto)
        {
            try
            {

                HttpClient client = new HttpClient();

                string url = "http://localhost:8080/api/Valores/Impuesto";

                var content = new StringContent(JsonConvert.SerializeObject(impuesto), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

                //result.Content

                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }

        public async Task<List<Impuesto>> ListarImpuestos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Valores/Impuestos");

                List<Impuesto> impuestos = null;

                impuestos = JsonConvert.DeserializeObject<List<Impuesto>>(json);

                return impuestos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los impuestos.");
            }
        }

        public void IniciarReigstroImpuesto()
        {
            SetImpuesto(new Impuesto());
        }
    }
}
