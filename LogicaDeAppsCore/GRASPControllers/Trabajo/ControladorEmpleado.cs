using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorEmpleado : IControladorEmpleado
    {
        private int ci;
        private Empleado empleado;


        public bool ExisteEmpleado(int ci)
        {
            return true;
        }

        public Empleado GetEmpleado()
        {
            return new Empleado();
        }

        public void SetEmpleado(Empleado pEmpleado)
        {
            empleado = pEmpleado;
        }

        public Empleado BuscarEmpleado(int ci)
        {
            return new Empleado();
        }

        public bool ModificarEmpleado(Empleado pEmpleado)
        {
            return true;
        }

        public bool EliminarEmpleado(Empleado pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado(Empleado pEmpleado)
        {
            return true;
        }

        public void SetCi(int pCi)
        {
            ci = pCi;
        }

        public Empleado ContemplarTipo()
        {
            return new Empleado();
        }

        public int GetCi()
        {
            return ci;
        }
    }
}
