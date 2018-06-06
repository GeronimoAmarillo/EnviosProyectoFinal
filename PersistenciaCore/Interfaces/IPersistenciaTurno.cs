using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaTurno
    {
        bool ExisteTurno(string dia, DateTime hora);

        List<EntidadesCompartidasCore.Turno> ListarTurnos();

        bool ModificarTurno(EntidadesCompartidasCore.Turno turno);

        bool AltaTurno(EntidadesCompartidasCore.Turno turno);
    }
}
