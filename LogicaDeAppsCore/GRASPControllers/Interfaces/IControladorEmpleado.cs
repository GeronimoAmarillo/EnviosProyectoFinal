using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorEmpleado
    {
        bool ExisteEmpleado(int ci);

        Empleado GetEmpleado();

        void SetEmpleado(Empleado pEmpleado);

        Empleado BuscarEmpleado(int ci);

        bool ModificarEmpleado(Empleado pEmpleado);

        bool EliminarEmpleado(Empleado pEmpleado);

        bool AltaEmpleado(Empleado pEmpleado);

        void SetCi(int pCi);

        Empleado ContemplarTipo();

        int GetCi();
    }
}
