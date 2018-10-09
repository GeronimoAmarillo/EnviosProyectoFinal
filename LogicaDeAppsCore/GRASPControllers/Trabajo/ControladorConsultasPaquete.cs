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
    class ControladorConsultasPaquete:IControladorConsultasPaquete
    {
        private Local local;
        private List<Paquete> paquetes;

        public void SeleccionarLocal()
        {

        }

        public void SetLocal(Local pLocal)
        {
            local = pLocal;
        }

        public Local GetLocal()
        {
            return local;
        }

        public List<Local> ListarLocales()
        {
            return new List<Local>();
        }

        public async Task<Paquete> BuscarPaquete(int numReferencia)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionPaquetes + "/Buscar?numReferencia=" + numReferencia);

                Paquete paquete = null;

                paquete = JsonConvert.DeserializeObject<Paquete>(json);

                return paquete;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el paquete.");
            }
        }

        public async Task<Paquete> BuscarPaqueteIndividual(int numReferencia, long cliente)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionPaquetes + "/BuscarIndividual?numReferencia=" + numReferencia + "&cliente=" + cliente);

                Paquete paquete = null;

                paquete = JsonConvert.DeserializeObject<Paquete>(json);

                return paquete;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el paquete.");
            }
        }

        public async Task<List<Paquete>> ListarPaquetesEnviadosXCliente(long rut)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionPaquetes + "/ListarEnviados?rut=" + rut);

                List<Paquete> paquetes = null;

                paquetes = JsonConvert.DeserializeObject<List<Paquete>>(json);

                return paquetes;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los paquetes.");
            }
        }

        public void SetPaquetes(List<Paquete> pPaquetes)
        {
            paquetes = pPaquetes;
        }

        public List<Paquete> FiltrarPaquetesEnviados(string estado, DateTime fechaEnvio)
        {
            return new List<Paquete>();
        }

        public List<Paquete> FiltrarPaquetesRecibidos(string estado, DateTime fechaEnvio)
        {
            return new List<Paquete>();
        }

        public List<Paquete> GetPaquetes()
        {
            return paquetes;
        }

        public List<Paquete> ListarPaquetesRecibidosXCliente(int cedula)
        {
            return new List<Paquete>();
        }

        public Paquete ConsultarEstado(int numReferencia)
        {
            return new Paquete();
        }
    }
}
