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

        public Turno BuscarTurno(string codigo)
        {
            return new Turno();
        }

        public bool ModificarTurno(Turno pTurno)
        {
            return true;
        }

        public bool AltaTurno(Turno turno)
        {
            return true;
        }
    }
}
