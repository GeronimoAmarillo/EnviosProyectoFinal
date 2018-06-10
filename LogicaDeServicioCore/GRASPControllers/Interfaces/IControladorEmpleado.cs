using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorEmpleado
    {
        bool ExisteEmpleado(int ci);

        Empleado BuscarEmpleado(int ci);

        bool ModificarEmpleado(Empleado pEmpleado);

        bool BajaEmpleado(Empleado pEmpleado);

        bool AltaEmpleado(Empleado pEmpleado);
    }
}
