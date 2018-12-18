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
    class ControladorPalet: IControladorPalet
    {
        private Palet palet;
        private List<Cliente> clientes;
        private Cliente cliente;
        private Galpon galpon;
        private Rack rack;
        private Sector sector;

        public async Task<List<Palet>> ListarPalets()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionPalets + "/PaletsTodos");

                List<Palet> palets = null;

                palets = JsonConvert.DeserializeObject<List<Palet>>(json);

                return palets;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los palets.");
            }
        }
    }
}
