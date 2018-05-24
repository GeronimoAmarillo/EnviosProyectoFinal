using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorBalance:IControladorBalance
    {
        public List<EntidadesCompartidas.Balances> ConsultarBalanceAnual(int año)
        {
            return new List<EntidadesCompartidas.Balances>();
        }

        public EntidadesCompartidas.Balances ConsultarBalanceMensual(string mes, int año)
        {
            return new EntidadesCompartidas.Balances();
        }
    }
}
