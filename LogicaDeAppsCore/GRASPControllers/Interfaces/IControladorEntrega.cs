using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorEntrega
    {
        List<Entrega> SeleccionarEntregas(List<int> pEntregas);

        List<Entrega> ListarEntregas();

        List<Entrega> GetEntregasSeleccionadas();

        List<Entrega> GetEntregas();

        void SetEntregas(List<Entrega> pEntregas);

        void SetEntregasSeleccionadas(List<Entrega> pEntregas);

        bool EntregarPaquetes(string firma, string nombreReceptor);

    }
}
