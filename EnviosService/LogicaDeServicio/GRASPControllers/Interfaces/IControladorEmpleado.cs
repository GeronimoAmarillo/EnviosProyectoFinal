using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorEmpleado
    {
        bool ExisteEmpleado(int ci);

        Empleados BuscarEmpleado(int ci);

        bool ModificarEmpleado(Empleados pEmpleado);

        bool BajaEmpleado(Empleados pEmpleado);

        bool AltaEmpleado(Empleados pEmpleado);
    }
}
