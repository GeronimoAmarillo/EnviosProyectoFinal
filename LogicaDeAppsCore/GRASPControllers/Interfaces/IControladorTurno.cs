using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorTurno
    {
        void IniciarRegistroTurno();

        Task<bool> ExisteTurno(string dia, string hora);

        Task<Turno>BuscarTurno(string codigo);

        bool ModificarTurno(Turno pTurno);

        Turno GetTurno();

        void SetTurno(Turno pTurno);

        bool RegistrarTurno();

        Task<List<Turno>> ListarTurnos();

    }
}
