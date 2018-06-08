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

        List<Empleado> ListarEmpleados();

        void SetAdelanto(Adelanto pAdelanto);

        Adelanto GetAdelanto();

        Empleado GetEmpleado();

        Empleado SeleccionarEmpleado(int cedula);

        bool RealizarAdelanto(Adelanto pAdelanto);

    }
}
