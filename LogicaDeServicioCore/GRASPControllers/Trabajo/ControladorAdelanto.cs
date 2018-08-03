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
            return new List<EntidadesCompartidasCore.Empleado>();
        }

        public EntidadesCompartidasCore.Empleado BuscarEmpleado(int cedula)
        {
            return new EntidadesCompartidasCore.Empleado();
        }

        public bool RealizarAdelanto(EntidadesCompartidasCore.Adelanto pAdelanto)
        {
            return true;
        }
    }
}
