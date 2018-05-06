using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public class LogicaValor
    {
        public List<Gastos> listarGastos()
        {
            List<Gastos> gastos = new List<Gastos>();
            return gastos;
        }

        public List<Ingresos> listarIngresos()
        {
            List<Ingresos> ingresos = new List<Ingresos>();
            return ingresos;
        }

        public bool registrarIngreso(Ingresos unIngreso)
        {
            bool exito = false;
            return exito;
        }

        public bool registrarImpuesto(Impuestos unImpuesto)
        {
            bool exito = false;
            return exito;
        }

        public bool registrarGasto(Gastos unGasto)
        {
            bool exito = false;
            return exito;
        }
    }
}
