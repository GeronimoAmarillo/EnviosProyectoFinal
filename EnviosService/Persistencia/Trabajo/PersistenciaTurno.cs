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

        public List<Turnos> ListarTurnos()
        {
            return new List<Turnos>();
        }

        public bool ModificarTurno(Turnos turno)
        {
            return true;
        }

        public bool AltaTurno(Turnos turno)
        {
            return true;
        }
    }
}
