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
        public List<Ingresos> ListarIngresos()
        {
            return new List<Ingresos>();
        }

        public bool RegistrarIngreso(Ingresos ingreso)
        {
            return true;
        }
    }
}
