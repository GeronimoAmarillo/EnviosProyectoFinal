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

        public Empleados BuscarEmpleado(int ci)
        {
            return new Empleados();
        }

        public bool ModificarEmpleado(Empleados pEmpleado)
        {
            return true;
        }

        public bool BajaEmpleado(Empleados pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado(Empleados pEmpleado)
        {
            return true;
        }
    }
}
