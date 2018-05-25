using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorGasto: IControladorGasto
    {
        private Gasto gasto;
        private List<Gasto> gastos;

        public Gasto GetGasto()
        {
            return gasto;
        }

        public List<DTGasto> ListarGastos()
        {
            return new List<DTGasto>();
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

        public bool RegistrarGasto(DTGasto gasto)
        {
            return true;
        }
    }
}
