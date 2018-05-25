using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorEmpleado
    {
        bool ExisteEmpleado(int ci);

        Empleado GetEmpleado();

        void SetEmpleado(Empleado pEmpleado);

        DTEmpleado BuscarEmpleado(int ci);

        bool ModificarEmpleado(DTEmpleado pEmpleado);

        bool EliminarEmpleado(DTEmpleado pEmpleado);

        bool AltaEmpleado(DTEmpleado pEmpleado);

        void SetCi(int pCi);

        DTEmpleado ContemplarTipo();

        int GetCi();
    }
}
