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
        public List<EntidadesCompartidas.Ingresos> ListarIngresos()
        {
            return new List<EntidadesCompartidas.Ingresos>();
        }

        public bool RegistrarIngreso(EntidadesCompartidas.Ingresos ingreso)
        {
            return true;
        }
    }
}
