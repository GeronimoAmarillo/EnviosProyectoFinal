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
        private Ingreso ingreso;
        private List<Ingreso> ingresos;

        public Ingreso GetIngreso()
        {
            return ingreso;
        }

        public void SetIngreso(Ingreso pIngreso)
        {
            ingreso = pIngreso;
        }

        public bool ReigstrarIngreso(DTIngreso ingreso)
        {
            return true;
        }

        public void SetIngresos(List<Ingreso> pIngresos)
        {
            ingresos = pIngresos;
        }

        public List<Ingreso> GetIngresos()
        {
            return ingresos;
        }

        public List<DTIngreso> ListarIngresos()
        {
            return new List<DTIngreso>();
        }
    }
}
