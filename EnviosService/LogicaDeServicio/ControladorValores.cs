using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorValores:IControladorValores
    {
        public List<Gastos> ListarGastos()
        {
            return new List<Gastos>();
        }

        public bool RegistrarGasto(Gastos gasto)
        {
            return true;
        }

        public bool RegistrarImpuesto(Impuestos impuesto)
        {
            return true;
        }

        public bool RegistrarIngreso(Ingresos ingreso)
        {
            return true;
        }

        public List<Ingresos> ListarIngresos()
        {
            return new List<Ingresos>();
        }
    }
}
