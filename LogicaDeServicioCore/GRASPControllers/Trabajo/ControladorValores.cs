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
                throw new Exception("Error al intentar listar los gastos.");
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
                throw new Exception("Error al intentar dar de alta el gasto.");
            }
        }

        public bool RegistrarImpuesto(Impuesto impuesto)
        {
            try
            {
                return LogicaValor.RegistrarImpuesto(impuesto);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el impuesto.");
            }
        }

        public List<Impuesto> ListarImpuestos()
        {
            try
            {
                return LogicaValor.ListarImpuestos();
            }
            catch
            {
                throw new Exception("Error al intentar listar los impuestos.");
            }
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
