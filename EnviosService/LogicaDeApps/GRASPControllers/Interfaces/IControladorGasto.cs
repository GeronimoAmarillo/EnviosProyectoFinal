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
        Gasto GetGasto();

        List<DTGasto> ListarGastos();

        List<Gasto> GetGastos();

        void IniciarRegistroGasto();

        void SetGasto(Gasto pGasto);

        bool RegistrarGasto(DTGasto gasto);

    }
}
