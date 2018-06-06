using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaGasto:IPersistenciaGasto
    {
        public bool RegistrarGasto(EntidadesCompartidasCore.Gasto gasto)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Gasto> ListarGastos()
        {
            return new List<EntidadesCompartidasCore.Gasto>();
        }
    }
}
