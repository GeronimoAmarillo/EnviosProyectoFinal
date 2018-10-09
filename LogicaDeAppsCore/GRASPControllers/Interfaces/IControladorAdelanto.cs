using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorAdelanto
    {
        void IniciarRegistroAdelanto();

        Task<List<Empleado>> ListarEmpleados();

        void SetAdelanto(Adelanto pAdelanto);

        Adelanto GetAdelanto();

        Empleado GetEmpleado();

        Task<Empleado> SeleccionarEmpleado(int cedula);

        bool RealizarAdelanto(Adelanto pAdelanto);

        Task<List<Adelanto>> ListarAdelantos();

        Task<List<Adelanto>> ListarAdelantosXEmpleado(int cedula);

        Task<bool> verificarAdelantoSaldado(int cedula);
        
    }
}
