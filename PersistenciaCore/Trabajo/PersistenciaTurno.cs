using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaTurno:IPersistenciaTurno
    {
        public bool ExisteTurno(string dia, DateTime hora)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Turno> ListarTurnos()
        {
            return new List<EntidadesCompartidasCore.Turno>();
        }

        public bool ModificarTurno(EntidadesCompartidasCore.Turno turno)
        {
            return true;
        }

        public bool AltaTurno(EntidadesCompartidasCore.Turno turno)
        {
            return true;
        }
    }
}
