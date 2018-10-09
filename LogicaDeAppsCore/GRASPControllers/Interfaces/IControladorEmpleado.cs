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
        Task<bool> ExisteEmpleado(int ci);

        Empleado GetEmpleado();

        Cadete GetEmpleadoCad();

        Administrador GetEmpleadoAdm();

        void SetEmpleado(Empleado pEmpleado);

        Task <Empleado> BuscarEmpleado(int ci);

        bool ModificarAdmnistrador(Administrador pEmpleado);

        bool ModificarCadete(Cadete pEmpleado);

        bool EliminarEmpleado(Empleado emp);

        bool AltaEmpleadoAdministrador(Administrador pEmpleado);

        bool AltaEmpleadoCadete(Cadete pEmpleado);

        void SetCi(int pCi);

        Empleado ContemplarTipo();

        int GetCi();

        Task<List<Empleado>> ListarEmpleados();
    }
}
