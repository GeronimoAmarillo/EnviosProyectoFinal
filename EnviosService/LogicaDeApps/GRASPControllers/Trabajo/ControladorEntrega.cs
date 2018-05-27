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
        private List<Entrega> entregas;
        private List<Entrega> entregasSeleccionadas;

        public List<DTEntrega> SeleccionarEntregas(List<int> pEntregas)
        {
            return new List<DTEntrega>();
        }

        public List<DTEntrega> ListarEntregas()
        {
            return new List<DTEntrega>();
        }

        public List<Entrega> GetEntregasSeleccionadas()
        {
            return entregasSeleccionadas;
        }

        public List<Entrega> GetEntregas()
        {
            return entregas;
        }

        public void SetEntregas(List<Entrega> pEntregas)
        {
            entregas = pEntregas;
        }

        public void SetEntregasSeleccionadas(List<Entrega> pEntregas)
        {
            entregasSeleccionadas = pEntregas;
        }

        public bool EntregarPaquetes(string firma, string nombreReceptor)
        {
            return true;
        }
    }
}
