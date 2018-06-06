using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaReparacion:IPersistenciaReparacion
    {
        public bool RegistrarMulta(EntidadesCompartidasCore.Multa multa)
        {
            return true;
        }
    }
}
