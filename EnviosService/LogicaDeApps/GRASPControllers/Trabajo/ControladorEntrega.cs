using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorEntrega: IControladorEntrega
    {
        private List<Entregas> entregas;
        private List<Entregas> entregasSeleccionadas;

        public List<DTEntrega> SeleccionarEntregas(List<int> pEntregas)
        {
            return new List<DTEntrega>();
        }

        public List<DTEntrega> ListarEntregas()
        {
            return new List<DTEntrega>();
        }

        public List<Entregas> GetEntregasSeleccionadas()
        {
            return entregasSeleccionadas;
        }

        public List<Entregas> GetEntregas()
        {
            return entregas;
        }

        public void SetEntregas(List<Entregas> pEntregas)
        {
            entregas = pEntregas;
        }

        public void SetEntregasSeleccionadas(List<Entregas> pEntregas)
        {
            entregasSeleccionadas = pEntregas;
        }

        public bool EntregarPaquetes(string firma, string nombreReceptor)
        {
            return true;
        }
    }
}
