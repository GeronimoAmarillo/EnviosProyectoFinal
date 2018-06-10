using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorGasto
    {
        Gasto GetGasto();

        List<Gasto> ListarGastos();

        List<Gasto> GetGastos();

        void IniciarRegistroGasto();

        void SetGasto(Gasto pGasto);

        bool RegistrarGasto(Gasto gasto);

    }
}
