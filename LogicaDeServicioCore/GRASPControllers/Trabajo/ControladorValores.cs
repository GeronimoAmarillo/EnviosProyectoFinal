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
            try
            {
                return LogicaValor.ListarGastos();
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }

        public bool RegistrarGasto(Gasto gasto)
        {
            try
            {
                return LogicaValor.RegistrarGasto(gasto);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
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
