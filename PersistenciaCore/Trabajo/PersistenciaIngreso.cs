using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaIngreso:IPersistenciaIngreso
    {
        public List<EntidadesCompartidasCore.Ingreso> ListarIngresos()
        {
            return new List<EntidadesCompartidasCore.Ingreso>();
        }

        public bool RegistrarIngreso(EntidadesCompartidasCore.Ingreso ingreso)
        {
            return true;
        }
    }
}
