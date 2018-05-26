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

        List<EntidadesCompartidas.Turno> ListarTurnos();

        bool ModificarTurno(EntidadesCompartidas.Turno turno);

        bool AltaTurno(EntidadesCompartidas.Turno turno);
    }
}
