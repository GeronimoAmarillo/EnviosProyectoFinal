using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaTurno:IPersistenciaTurno
    {
        public bool ExisteTurno(string dia, DateTime hora)
        {
            return true;
        }

        public List<EntidadesCompartidas.Turnos> ListarTurnos()
        {
            return new List<EntidadesCompartidas.Turnos>();
        }

        public bool ModificarTurno(EntidadesCompartidas.Turnos turno)
        {
            return true;
        }

        public bool AltaTurno(EntidadesCompartidas.Turnos turno)
        {
            return true;
        }
    }
}
