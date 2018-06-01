using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorTurno
    {
        void IniciarRegistroTurno();

        bool ExisteTurno(string dia, string hora);

        DTTurno BuscarTurno(string codigo);

        bool ModificarTurno(DTTurno pTurno);

        Turno GetTurno();

        void SetTurno(Turno pTurno);

        bool RegistrarTurno();

    }
}
