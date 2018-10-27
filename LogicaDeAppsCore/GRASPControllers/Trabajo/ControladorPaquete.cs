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
    class ControladorPaquete:IControladorPaquete
    {
        private Reclamo reclamo;
        private Paquete paquete;

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }

        public Paquete GetPaquete()
        {
            return paquete;
        }

        public Paquete BuscarPaquete(int codigo)
        {
            return new Paquete();
        }

        public void SetPaquete(Paquete pPaquete)
        {
            paquete = pPaquete;
        }
        //Reclamos
        public async Task<List<EntidadesCompartidasCore.Reclamo>> ListarReclamos()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionPaquetes + "/ListarReclamos");

                List<EntidadesCompartidasCore.Reclamo> reclamos = null;

                reclamos = JsonConvert.DeserializeObject<List<EntidadesCompartidasCore.Reclamo>>(json);

                return reclamos;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los reclamos.");
            }
        }
    }
}
