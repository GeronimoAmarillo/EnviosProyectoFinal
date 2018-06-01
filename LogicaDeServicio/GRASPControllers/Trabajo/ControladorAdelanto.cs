using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace LogicaDeServicio
{
    class ControladorAdelanto:IControladorAdelanto
    {
        public List<EntidadesCompartidas.Empleado> ListarEmpleados()
        {
            return new List<EntidadesCompartidas.Empleado>();
        }

        public EntidadesCompartidas.Empleado BuscarEmpleado(int cedula)
        {
            return new EntidadesCompartidas.Empleado();
        }

        public bool RealizarAdelanto(EntidadesCompartidas.Adelanto pAdelanto)
        {
            return true;
        }
    }
}
