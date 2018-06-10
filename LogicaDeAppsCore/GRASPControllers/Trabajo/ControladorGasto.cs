using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorGasto: IControladorGasto
    {
        private Gasto gasto;
        private List<Gasto> gastos;

        public Gasto GetGasto()
        {
            return gasto;
        }

        public List<Gasto> ListarGastos()
        {
            return new List<Gasto>();
        }

        public List<Gasto> GetGastos()
        {
            return gastos;
        }

        public void IniciarRegistroGasto()
        {

        }

        public void SetGasto(Gasto pGasto)
        {
            gasto = pGasto;
        }

        public bool RegistrarGasto(Gasto gasto)
        {
            return true;
        }
    }
}
