using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorTurno:IControladorTurno
    {

        public bool ExisteTurno(string dia, string hora)
        {
            return true;
        }

        public Turnos BuscarTurno(string codigo)
        {
            return new Turnos();
        }

        public bool ModificarTurno(Turnos pTurno)
        {
            return true;
        }

        public bool AltaTurno(Turnos turno)
        {
            return true;
        }
    }
}
