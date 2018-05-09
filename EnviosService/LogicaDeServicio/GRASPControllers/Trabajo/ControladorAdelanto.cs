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
        public List<Empleados> ListarEmpleados()
        {
            return new List<Empleados>();
        }

        public Empleados BuscarEmpleado(int cedula)
        {
            return new Empleados();
        }

        public bool RealizarAdelanto(Adelantos pAdelanto)
        {
            return true;
        }
    }
}
