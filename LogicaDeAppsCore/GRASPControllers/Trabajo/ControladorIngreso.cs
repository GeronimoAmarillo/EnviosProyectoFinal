using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
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

        public bool ReigstrarIngreso(Ingreso ingreso)
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

        public List<Ingreso> ListarIngresos()
        {
            return new List<Ingreso>();
        }
    }
}
