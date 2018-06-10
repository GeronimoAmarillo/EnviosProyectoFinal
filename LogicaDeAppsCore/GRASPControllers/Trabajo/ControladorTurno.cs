using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorTurno:IControladorTurno
    {
        private Turno turno;

        public void IniciarRegistroTurno()
        {

        }

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

        public Turno GetTurno()
        {
            return turno;
        }

        public void SetTurno(Turno pTurno)
        {
            turno = pTurno;
        }

        public bool RegistrarTurno()
        {
            return true;
        }
    }
}
