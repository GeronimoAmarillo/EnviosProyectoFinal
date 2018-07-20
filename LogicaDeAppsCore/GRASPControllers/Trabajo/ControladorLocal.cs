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

        public async Task<bool> ExisteLocal(string nombre, string direccion)
        {

            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Locales/ExisteLocal?"+"nombre="+nombre+"&direccion="+direccion);

                bool existe = false;

                existe = JsonConvert.DeserializeObject<bool>(json);

                return existe;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
        }

        public void IniciarRegistroLocal()
        {
            SetLocal(new Local());
        }

        public async Task<Local> BuscarLocal(int id)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Locales/Local?id=" + id);

                Local local = null;

                local = JsonConvert.DeserializeObject<Local>(json);

                return local;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el local.");
            }
        }

        public bool ModificarLocal(Local local)
        {
            try
            {

                HttpClient client = new HttpClient();

                if (ExisteLocal(local.Nombre, local.Direccion).ToString().ToUpper() == "FALSE")
                {
                    throw new Exception("El local que desea modificar no existe en el sistema.");
                }

                string url = "http://localhost:8080/api/Locales/Modificar";

                var content = new StringContent(JsonConvert.SerializeObject(local), Encoding.UTF8, "application/json");

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

                if (ExisteLocal(local.Nombre, local.Direccion).ToString().ToUpper() == "TRUE")
                {
                    throw new Exception("El local que desea dar de alta ya existe en el sistema.");
                }

                string url = "http://localhost:8080/api/Locales/Alta";

                var content = new StringContent(JsonConvert.SerializeObject(local),Encoding.UTF8,"application/json");

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
