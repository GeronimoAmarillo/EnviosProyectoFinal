using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
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

        public DTTurno BuscarTurno(string codigo)
        {
            return new DTTurno();
        }

        public bool ModificarTurno(DTTurno pTurno)
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
