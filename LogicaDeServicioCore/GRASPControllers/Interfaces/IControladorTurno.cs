using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorTurno
    {
        bool ExisteTurno(string dia, string hora);

        Turno BuscarTurno(string codigo);

        bool ModificarTurno(Turno pTurno);

        bool AltaTurno(Turno turno);

        List<Turno> ListarTurnos();
    }
}
