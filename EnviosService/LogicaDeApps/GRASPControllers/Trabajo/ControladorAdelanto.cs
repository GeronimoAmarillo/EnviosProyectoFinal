using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorAdelanto : IControladorAdelanto
    {
        private Adelantos adelanto;
        public void IniciarRegistroAdelanto()
        {

        }

        public List<DTEmpleado> ListarEmpleados()
        {
            return new List<DTEmpleado>();
        }

        public void SetAdelanto(Adelantos pAdelanto)
        {
            adelanto = pAdelanto;
        }

        public Adelantos GetAdelanto()
        {
            return adelanto;
        }

        public Empleados GetEmpleado()
        {
            return new Empleados();
        }

        public DTEmpleado SeleccionarEmpleado(int cedula)
        {
            return new DTEmpleado();
        }

        public bool RealizarAdelanto(DTAdelanto pAdelanto)
        {
            return true;
        }
    }
}
