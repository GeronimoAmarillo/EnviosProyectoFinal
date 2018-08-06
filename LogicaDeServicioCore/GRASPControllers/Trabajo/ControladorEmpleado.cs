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
            try
            {
                return LogicaUsuario.ExisteEmpleado(ci);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
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
            try
            {
                return LogicaUsuario.AltaUsuario(pEmpleado);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }
        public List<Empleado> Listar()
        {
            try
            {
                return LogicaUsuario.ListarEmpleados();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los locales." + ex.Message);
            }
        }
    }
}
