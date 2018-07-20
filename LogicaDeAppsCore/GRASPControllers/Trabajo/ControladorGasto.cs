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
    class ControladorGasto: IControladorGasto
    {
        private Gasto gasto;
        private List<Gasto> gastos;

        public Gasto GetGasto()
        {
            return gasto;
        }

        public async Task<List<Gasto>> ListarGastos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Valores/Gastos");

                List<Gasto> gastos = null;

                gastos = JsonConvert.DeserializeObject<List<Gasto>>(json);

                return gastos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los gastos.");
            }
        }

        public List<Gasto> GetGastos()
        {
            return gastos;
        }

        public void IniciarRegistroGasto()
        {
            SetGasto(new Gasto());
        }

        public void SetGasto(Gasto pGasto)
        {
            gasto = pGasto;
        }

        public bool RegistrarGasto(Gasto gasto)
        {
            try
            {

                HttpClient client = new HttpClient();

                string url = "http://localhost:8080/api/Valores/Gasto";

                var content = new StringContent(JsonConvert.SerializeObject(gasto), Encoding.UTF8, "application/json");

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
