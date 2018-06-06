using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public class LogicaValor
    {
        public List<Gasto> ListarGastos()
        {
            List<Gasto> gastos = new List<Gasto>();
            return gastos;
        }

        public List<Ingreso> ListarIngresos()
        {
            List<Ingreso> ingresos = new List<Ingreso>();
            return ingresos;
        }

        public bool RegistrarIngreso(Ingreso unIngreso)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarImpuesto(Impuesto unImpuesto)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarGasto(Gasto unGasto)
        {
            bool exito = false;
            return exito;
        }
    }
}
