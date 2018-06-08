using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorEntrega: IControladorEntrega
    {
        private List<Entrega> entregas;
        private List<Entrega> entregasSeleccionadas;

        public List<Entrega> SeleccionarEntregas(List<int> pEntregas)
        {
            return new List<Entrega>();
        }

        public List<Entrega> ListarEntregas()
        {
            return new List<Entrega>();
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
