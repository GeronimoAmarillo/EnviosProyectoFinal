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
    class ControladorCalificacion:IControladorCalificacion
    {
        public bool Calificar(Calificacion cal)
        {
            try
            {

                HttpClient client = new HttpClient();

                string url = ConexionREST.ConexionCalificaciones + "/Calificar";

                var content = new StringContent(JsonConvert.SerializeObject(cal), Encoding.UTF8, "application/json");

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
