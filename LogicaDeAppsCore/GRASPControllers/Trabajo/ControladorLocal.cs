﻿using System;
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
            //http://localhost:8080/

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:8080/api/Locales/Locales");

            var data = JsonConvert.DeserializeObject<Root>(json).Data;

            List<Local> locales = new List<Local>();

            foreach (var d in data)
            {
                foreach (var l in d)
                {
                    Local local = new Local();


                    switch (l.Key.ToString())
                    {
                        case "Id":
                            local.Id = Convert.ToInt32(l.Value);
                            break;
                        case "Nombre":
                            local.Nombre = l.Value.ToString();
                            break;
                        case "Direccion":
                            local.Direccion = l.Value.ToString();
                            break;
                    }

                    locales.Add(local);
                }
            }

            return locales;
        }

        public bool AltaLocal()
        {
            try
            {

                //------------------------------------------------------------------------------------------------------
                //Otra posible forma de hacerlo
                /*HttpClient client = new HttpClient();
                 List<MyClass> newList = getList();

                 string url = "http://localhost:57750/api/ControllerName/InsertSomething";
                 var content = new StringContent(JsonConvert.SerializeObject(newList),Encoding.UTF8,"application/json");
                 var result = client.PostAsync(url, content);*/
                //------------------------------------------------------------------------------------------------------

                //http://localhost/EnviosService/Api

                var httpClient = new HttpClient();
                string conexion = "http://localhost/EnviosService/Api/Locales/Local";

                //Declara el objeto con el que haremos la llamada al servicio

                HttpWebRequest request = WebRequest.Create(conexion) as HttpWebRequest;

                //Configurar las propiedad del objeto de llamada

                request.Method = "POST";
                request.ContentType = "application/json";

                //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft

                string objetoSerializado = JsonConvert.SerializeObject(local);

                //Convertir el objeto serializado a arreglo de byte

                Byte[] bt = Encoding.UTF8.GetBytes(objetoSerializado);

                //Agregar el objeto Byte[] al request

                Stream comunicacion = request.GetRequestStream();
                comunicacion.Write(bt, 0, bt.Length);
                comunicacion.Close();

                //Hacer la llamada

                string resultado;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    //Leer el resultado de la llamada

                    Stream stream1 = response.GetResponseStream();
                    StreamReader lectorRespuesta = new StreamReader(stream1);
                    resultado = lectorRespuesta.ReadToEnd();

                    var resultadoJson = JsonConvert.DeserializeObject<RootRespuestas>(resultado).Data;

                    resultado = resultadoJson.ToString();

                    if (resultado.ToLower() == "true")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR!: " + ex.Message);
            }
        }
    }
}
