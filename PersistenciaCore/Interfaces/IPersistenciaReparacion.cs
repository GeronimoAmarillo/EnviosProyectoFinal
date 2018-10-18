using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaReparacion
    {
        bool RegistrarReparacion(Reparacion reparacion);
    }
}
