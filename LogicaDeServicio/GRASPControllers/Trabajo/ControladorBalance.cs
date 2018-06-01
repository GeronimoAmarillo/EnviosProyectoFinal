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
        public List<EntidadesCompartidas.Balance> ConsultarBalanceAnual(int año)
        {
            return new List<EntidadesCompartidas.Balance>();
        }

        public EntidadesCompartidas.Balance ConsultarBalanceMensual(string mes, int año)
        {
            return new EntidadesCompartidas.Balance();
        }
    }
}
