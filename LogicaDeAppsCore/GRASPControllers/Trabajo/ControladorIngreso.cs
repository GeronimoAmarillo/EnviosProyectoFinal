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
    class ControladorIngreso:IControladorIngreso
    {
        private Ingreso ingreso;
        private List<Ingreso> ingresos;

        public Ingreso GetIngreso()
        {
            return ingreso;
        }

        public void SetIngreso(Ingreso pIngreso)
        {
            ingreso = pIngreso;
        }

        public void IniciarRegistroIngreso()
        {
            SetIngreso(new Ingreso());
        }

        public bool ReigstrarIngreso(Ingreso ingreso)
        {
            try
            {

                HttpClient client = new HttpClient();

                string url = "http://localhost:8080/api/Valores/Ingreso";

                var content = new StringContent(JsonConvert.SerializeObject(ingreso), Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, content).Result;

                //result.Content

                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }

        public void SetIngresos(List<Ingreso> pIngresos)
        {
            ingresos = pIngresos;
        }

        public List<Ingreso> GetIngresos()
        {
            return ingresos;
        }

        public async Task<List<Ingreso>> ListarIngresos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Valores/Ingresos");

                List<Ingreso> ingresos = null;

                ingresos = JsonConvert.DeserializeObject<List<Ingreso>>(json);

                return ingresos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los ingresos.");
            }
        }
    }
}
