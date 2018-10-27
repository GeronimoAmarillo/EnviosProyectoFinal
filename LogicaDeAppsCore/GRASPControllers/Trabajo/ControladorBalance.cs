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
    class ControladorBalance: IControladorBalance
    {
        public List<Balance> ConsultarBalanceAnual(int año)
        {
            return new List<Balance>();
        }

        public Balance ConsultarBalanceMensual(string mes, int año)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = httpClient.GetStringAsync(ConexionREST.ConexionBalances + "/Balance");
                Balance balanceARetornar = JsonConvert.DeserializeObject<Balance>(json);
            }
        }

        public List<Registro> ConsultarRegistros(string mes, int año)
        {
            return new List<Registro>();
        }
    }
}
