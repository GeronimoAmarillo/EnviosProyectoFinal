using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorAdelanto
    {
        List<Empleados> ListarEmpleados();

        Empleados BuscarEmpleado(int cedula);

        bool RealizarAdelanto(Adelantos pAdelanto);
    }
}
