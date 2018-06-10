using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorEmpleado:IControladorEmpleado
    {
        public bool ExisteEmpleado(int ci)
        {
            return true;
        }

        public EntidadesCompartidasCore.Empleado BuscarEmpleado(int ci)
        {
            return new EntidadesCompartidasCore.Empleado();
        }

        public bool ModificarEmpleado(EntidadesCompartidasCore.Empleado pEmpleado)
        {
            return true;
        }

        public bool BajaEmpleado(EntidadesCompartidasCore.Empleado pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado(EntidadesCompartidasCore.Empleado pEmpleado)
        {
            return true;
        }
    }
}
