using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorEmpleado:IControladorEmpleado
    {
        public bool ExisteEmpleado(int ci)
        {
            return true;
        }

        public EntidadesCompartidas.Empleado BuscarEmpleado(int ci)
        {
            return new EntidadesCompartidas.Empleado();
        }

        public bool ModificarEmpleado(EntidadesCompartidas.Empleado pEmpleado)
        {
            return true;
        }

        public bool BajaEmpleado(EntidadesCompartidas.Empleado pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado(EntidadesCompartidas.Empleado pEmpleado)
        {
            return true;
        }
    }
}
