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
        private Adelanto adelanto;
        public void IniciarRegistroAdelanto()
        {

        }

        public List<DTEmpleado> ListarEmpleados()
        {
            return new List<DTEmpleado>();
        }

        public void SetAdelanto(Adelanto pAdelanto)
        {
            adelanto = pAdelanto;
        }

        public Adelanto GetAdelanto()
        {
            return adelanto;
        }

        public Empleado GetEmpleado()
        {
            return new Empleado();
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
