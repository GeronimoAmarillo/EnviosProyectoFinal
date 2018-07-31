using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    class ControladorAdelanto:IControladorAdelanto
    {
        public List<EntidadesCompartidasCore.Empleado> ListarEmpleados()
        {
            try
            {
                return LogicaUsuario.ListarEmpleados();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar listar los empleados." + ex.Message);
            }
        }

        public EntidadesCompartidasCore.Empleado BuscarEmpleado(int cedula)
        {
            try
            {
                return LogicaUsuario.BuscarEmpleado(cedula);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar buscar el Empleado." + ex.Message);
            }
        }

        public bool RealizarAdelanto(EntidadesCompartidasCore.Adelanto pAdelanto)
        {
            try
            {
                return LogicaAdelanto.RealizarAdelanto(pAdelanto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar registrar el adelanto." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Adelanto> ListarAdelantos()
        {
            try
            {
                return LogicaAdelanto.ListarAdelantos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar listar los adelantos." + ex.Message);
            }
        }
    }
}
