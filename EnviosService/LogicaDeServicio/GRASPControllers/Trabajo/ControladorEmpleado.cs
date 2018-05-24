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

        public EntidadesCompartidas.Empleados BuscarEmpleado(int ci)
        {
            return new EntidadesCompartidas.Empleados();
        }

        public bool ModificarEmpleado(EntidadesCompartidas.Empleados pEmpleado)
        {
            return true;
        }

        public bool BajaEmpleado(EntidadesCompartidas.Empleados pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado(EntidadesCompartidas.Empleados pEmpleado)
        {
            return true;
        }
    }
}
