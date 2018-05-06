using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaGasto:IPersistenciaGasto
    {
        public bool RegistrarGasto(Gastos gasto)
        {
            return true;
        }

        public List<Gastos> ListarGastos()
        {
            return new List<Gastos>();
        }
    }
}
