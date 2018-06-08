using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

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
            return new Balance();
        }

        public List<Registro> ConsultarRegistros(string mes, int año)
        {
            return new List<Registro>();
        }
    }
}
