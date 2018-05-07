using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorGasto
    {
        Gastos GetGasto();

        List<DTGasto> ListarGastos();

        List<Gastos> GetGastos();

        void IniciarRegistroGasto();

        void SetGasto(Gastos pGasto);

        bool RegistrarGasto(DTGasto gasto);

    }
}
