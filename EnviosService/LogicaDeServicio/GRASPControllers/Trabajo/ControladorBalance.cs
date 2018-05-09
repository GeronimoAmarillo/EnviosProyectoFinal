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
        public List<Balances> ConsultarBalanceAnual(int año)
        {
            return new List<Balances>();
        }

        public Balances ConsultarBalanceMensual(string mes, int año)
        {
            return new Balances();
        }
    }
}
