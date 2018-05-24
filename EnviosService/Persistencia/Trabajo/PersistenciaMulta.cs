using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaMulta:IPersistenciaMulta
    {
        public bool RegistrarMulta(EntidadesCompartidas.Multas multa)
        {
            return true;
        }
    }
}
