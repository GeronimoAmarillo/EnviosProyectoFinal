using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaTurno
    {
        bool ExisteTurno(string dia, DateTime hora);

        List<Turnos> ListarTurnos();

        bool ModificarTurno(Turnos turno);

        bool AltaTurno(Turnos turno);
    }
}
