using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorAdelanto
    {
        void IniciarRegistroAdelanto();

        List<DTEmpleado> ListarEmpleados();

        void SetAdelanto(Adelanto pAdelanto);

        Adelanto GetAdelanto();

        Empleado GetEmpleado();

        DTEmpleado SeleccionarEmpleado(int cedula);

        bool RealizarAdelanto(DTAdelanto pAdelanto);

    }
}
