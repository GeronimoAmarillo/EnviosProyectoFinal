using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorBalance: IControladorBalance
    {
        public List<DTBalance> ConsultarBalanceAnual(int año)
        {
            return new List<DTBalance>();
        }

        public DTBalance ConsultarBalanceMensual(string mes, int año)
        {
            return new DTBalance();
        }

        public List<DTRegistro> ConsultarRegistros(string mes, int año)
        {
            return new List<DTRegistro>();
        }
    }
}
