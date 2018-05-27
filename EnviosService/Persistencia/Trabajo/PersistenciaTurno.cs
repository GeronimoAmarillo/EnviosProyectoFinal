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

        public List<EntidadesCompartidas.Turno> ListarTurnos()
        {
            return new List<EntidadesCompartidas.Turno>();
        }

        public bool ModificarTurno(EntidadesCompartidas.Turno turno)
        {
            return true;
        }

        public bool AltaTurno(EntidadesCompartidas.Turno turno)
        {
            return true;
        }
    }
}
