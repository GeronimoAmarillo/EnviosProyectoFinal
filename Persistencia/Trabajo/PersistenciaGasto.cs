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
        public bool RegistrarGasto(EntidadesCompartidas.Gasto gasto)
        {
            return true;
        }

        public List<EntidadesCompartidas.Gasto> ListarGastos()
        {
            return new List<EntidadesCompartidas.Gasto>();
        }
    }
}
