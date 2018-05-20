using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;
using Newtonsoft.Json;

namespace LogicaDeApps
{
    class ControladorLocal:IControladorLocal
    {
        private Locales local;

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

        public DTLocal BuscarLocal(string nombre)
        {
            return new DTLocal();
        }

        public bool ModificarLocal(DTLocal local)
        {
            return true;
        }

        public void SetLocal(Locales pLocal)
        {
            local = pLocal;
        }

        public bool AltaLocal()
        {
            try
            {
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
