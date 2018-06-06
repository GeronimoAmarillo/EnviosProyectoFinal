using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorValores:IControladorValores
    {
        public List<Gasto> ListarGastos()
        {
            return new List<Gasto>();
        }

        public bool RegistrarGasto(Gasto gasto)
        {
            return true;
        }

        public bool RegistrarImpuesto(Impuesto impuesto)
        {
            return true;
        }

        public bool RegistrarIngreso(Ingreso ingreso)
        {
            return true;
        }

        public List<Ingreso> ListarIngresos()
        {
            return new List<Ingreso>();
        }
    }
}
