using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorIngreso:IControladorIngreso
    {
        private Ingresos ingreso;
        private List<Ingresos> ingresos;

        public Ingresos GetIngreso()
        {
            return ingreso;
        }

        public void SetIngreso(Ingresos pIngreso)
        {
            ingreso = pIngreso;
        }

        public bool ReigstrarIngreso(DTIngreso ingreso)
        {
            return true;
        }

        public void SetIngresos(List<Ingresos> pIngresos)
        {
            ingresos = pIngresos;
        }

        public List<Ingresos> GetIngresos()
        {
            return ingresos;
        }

        public List<DTIngreso> ListarIngresos()
        {
            return new List<DTIngreso>();
        }
    }
}
