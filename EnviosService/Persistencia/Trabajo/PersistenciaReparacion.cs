using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaReparacion:IPersistenciaReparacion
    {
        public bool RegistrarMulta(EntidadesCompartidas.Multa multa)
        {
            return true;
        }
    }
}
