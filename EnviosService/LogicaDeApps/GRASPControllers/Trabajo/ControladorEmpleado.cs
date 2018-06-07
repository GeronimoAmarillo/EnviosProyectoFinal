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
    class ControladorEmpleado : IControladorEmpleado
    {
        private int ci;
        private Empleado empleado;

        public class Root
        {
            public List<Dictionary<string, object>> Data { get; set; }
        }

        public class RootRespuestas
        {
            public Object Data { get; set; }
        }
        public bool ExisteEmpleado(int ci)
        {
            return true;
        }

        public Empleado GetEmpleado()
        {
            return new Empleado();
        }

        public void SetEmpleado(Empleado pEmpleado)
        {
            empleado = pEmpleado;
        }

        public DTEmpleado BuscarEmpleado(int ci)
        {
            return new DTEmpleado();
        }

        public bool ModificarEmpleado(DTEmpleado pEmpleado)
        {
            return true;
        }

        public bool EliminarEmpleado(DTEmpleado pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado()
        {
            try
            {

             
                //http://localhost/EnviosService/Api

                var httpClient = new HttpClient();
                string conexion = "http://localhost/EnviosService/Api/Empleados/Empleado";

              

                HttpWebRequest request = WebRequest.Create(conexion) as HttpWebRequest;

                

                request.Method = "POST";
                request.ContentType = "application/json";



                string objetoSerializado = JsonConvert.SerializeObject(empleado);

           

                Byte[] bt = Encoding.UTF8.GetBytes(objetoSerializado);

             

                Stream comunicacion = request.GetRequestStream();
                comunicacion.Write(bt, 0, bt.Length);
                comunicacion.Close();

              

                string resultado;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
          
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
    

        public void SetCi(int pCi)
        {
            ci = pCi;
        }

        public DTEmpleado ContemplarTipo()
        {
            return new DTEmpleado();
        }

        public int GetCi()
        {
            return ci;
        }
    }
}
