using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public class LogicaBalance
    {
        public List<Balance> ObtenerBalancesAnuales(int anio)
        {
            List<Balance> balancesdelAnio = new List<Balance>();
            return balancesdelAnio;
        }

        public EntidadesCompartidas.Balance BuscarBalance(int mes, int anio)
        {
            Balance balance = new Balance();
            return balance;
        }
    }
}
