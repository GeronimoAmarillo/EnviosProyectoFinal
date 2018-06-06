using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaImpuesto:IPersistenciaImpuesto
    {
        public bool RegistrarImpuesto(EntidadesCompartidasCore.Impuesto impuesto)
        {
            return true;
        }
    }
}
