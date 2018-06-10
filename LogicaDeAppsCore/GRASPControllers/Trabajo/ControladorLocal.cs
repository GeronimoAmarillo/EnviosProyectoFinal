using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Newtonsoft.Json;

namespace LogicaDeAppsCore
{
    class ControladorLocal:IControladorLocal
    {
        private Local local;

        public class Root
        {
            public List<Dictionary<string, object>> Data { get; set; }
        }

        public class RootRespuestas
        {
            public Object Data { get; set; }
        }

        public bool ExisteLocal(string nombre, string direccion)
        {


            return true;
        }

        public void IniciarRegistroLocal()
        {

        }

        public Local BuscarLocal(string nombre)
        {
            return new Local();
        }

        public bool ModificarLocal(Local local)
        {
            return true;
        }

        public void SetLocal(Local pLocal)
        {
            local = pLocal;
        }

        public Local GetLocal()
        {
            return local;
        }

        public async Task<List<Local>> ListarLocales()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Locales/Locales");

                List<Local> locales = null;

                locales = JsonConvert.DeserializeObject<List<Local>>(json);

                return locales;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los locales.");
            }
        }

        public bool AltaLocal()
        {
            try
            {

                HttpClient client = new HttpClient();
                Local local = GetLocal();

                string url = "http://localhost:8080/api/Locales/Alta";

                var content = new StringContent(JsonConvert.SerializeObject(local),Encoding.UTF8,"application/json");

                var result = client.PostAsync(url, content);

                if (result.Result.ToString().ToLower() == "true")
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
