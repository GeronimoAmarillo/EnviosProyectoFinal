using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaIngreso:IPersistenciaIngreso
    {
        public List<EntidadesCompartidas.Ingreso> ListarIngresos()
        {
            return new List<EntidadesCompartidas.Ingreso>();
        }

        public bool RegistrarIngreso(EntidadesCompartidas.Ingreso ingreso)
        {
            return true;
        }
    }
}
