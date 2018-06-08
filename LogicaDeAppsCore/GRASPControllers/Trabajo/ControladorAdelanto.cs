using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorAdelanto : IControladorAdelanto
    {
        private Adelanto adelanto;
        public void IniciarRegistroAdelanto()
        {

        }

        public List<Empleado> ListarEmpleados()
        {
            return new List<Empleado>();
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

        public Empleado SeleccionarEmpleado(int cedula)
        {
            return new Empleado();
        }

        public bool RealizarAdelanto(Adelanto pAdelanto)
        {
            return true;
        }
    }
}
