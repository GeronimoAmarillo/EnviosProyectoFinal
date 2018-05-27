using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorTurno
    {
        bool ExisteTurno(string dia, string hora);

        Turno BuscarTurno(string codigo);

        bool ModificarTurno(Turno pTurno);

        bool AltaTurno(Turno turno);
    }
}
