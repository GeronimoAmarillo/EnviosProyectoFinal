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
        public List<EntidadesCompartidas.Empleados> ListarEmpleados()
        {
            return new List<EntidadesCompartidas.Empleados>();
        }

        public EntidadesCompartidas.Empleados BuscarEmpleado(int cedula)
        {
            return new EntidadesCompartidas.Empleados();
        }

        public bool RealizarAdelanto(EntidadesCompartidas.Adelantos pAdelanto)
        {
            return true;
        }
    }
}
