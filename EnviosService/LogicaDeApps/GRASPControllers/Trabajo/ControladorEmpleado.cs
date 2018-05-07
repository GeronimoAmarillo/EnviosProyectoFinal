using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorEmpleado : IControladorEmpleado
    {
        private int ci;
        private Empleados empleado;


        public bool ExisteEmpleado(int ci)
        {
            return true;
        }

        public Empleados GetEmpleado()
        {
            return new Empleados();
        }

        public void SetEmpleado(Empleados pEmpleado)
        {
            empleado = pEmpleado;
        }

        public DTEmpleado BuscarEmpleado(int ci)
        {
            return new DTEmpleado();
        }

        public bool ModificarEmpleado(DTEmpleado pEmpleado)
        {
            return true;
        }

        public bool EliminarEmpleado(DTEmpleado pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado(DTEmpleado pEmpleado)
        {
            return true;
        }

        public void SetCi(int pCi)
        {
            ci = pCi;
        }

        public DTEmpleado ContemplarTipo()
        {
            return new DTEmpleado();
        }

        public int GetCi()
        {
            return ci;
        }
    }
}
