using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorBalance:IControladorBalance
    {
        public List<EntidadesCompartidasCore.Balance> ConsultarBalanceAnual(int año)
        {
            return new List<EntidadesCompartidasCore.Balance>();
        }

        public EntidadesCompartidasCore.Balance ConsultarBalanceMensual(string mes, int año)
        {
            return new EntidadesCompartidasCore.Balance();
        }
    }
}
