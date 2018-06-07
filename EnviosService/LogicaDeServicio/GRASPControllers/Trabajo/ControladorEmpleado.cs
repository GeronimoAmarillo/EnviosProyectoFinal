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
            try
            {
                return LogicaUsuario.ExisteEmpleado(ci);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario.");
            }
            
        }

        public Empleado BuscarEmpleado(int ci)
        {
            return new Empleado();
        }

        public bool ModificarEmpleado(Empleado pEmpleado)
        {
            return true;
        }

        public bool BajaEmpleado(Empleado pEmpleado)
        {
            return true;
        }

        public bool AltaEmpleado(Empleado pEmpleado)
        {
            try
            {
                   return LogicaUsuario.AltaUsuario(pEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar un empleado.");
            }
        }
    }
}
