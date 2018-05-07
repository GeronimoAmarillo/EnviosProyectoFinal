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
        public List<Gastos> ListarGastos()
        {
            List<Gastos> gastos = new List<Gastos>();
            return gastos;
        }

        public List<Ingresos> ListarIngresos()
        {
            List<Ingresos> ingresos = new List<Ingresos>();
            return ingresos;
        }

        public bool RegistrarIngreso(Ingresos unIngreso)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarImpuesto(Impuestos unImpuesto)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarGasto(Gastos unGasto)
        {
            bool exito = false;
            return exito;
        }
    }
}
