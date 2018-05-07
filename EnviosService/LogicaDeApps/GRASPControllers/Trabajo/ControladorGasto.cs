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
        private Gastos gasto;
        private List<Gastos> gastos;

        public Gastos GetGasto()
        {
            return gasto;
        }

        public List<DTGasto> ListarGastos()
        {
            return new List<DTGasto>();
        }

        public List<Gastos> GetGastos()
        {
            return gastos;
        }

        public void IniciarRegistroGasto()
        {

        }

        public void SetGasto(Gastos pGasto)
        {
            gasto = pGasto;
        }

        public bool RegistrarGasto(DTGasto gasto)
        {
            return true;
        }
    }
}
