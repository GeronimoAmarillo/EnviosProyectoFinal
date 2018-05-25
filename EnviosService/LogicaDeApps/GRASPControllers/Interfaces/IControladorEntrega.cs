using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorEntrega
    {
        List<DTEntrega> SeleccionarEntregas(List<int> pEntregas);

        List<DTEntrega> ListarEntregas();

        List<Entrega> GetEntregasSeleccionadas();

        List<Entrega> GetEntregas();

        void SetEntregas(List<Entrega> pEntregas);

        void SetEntregasSeleccionadas(List<Entrega> pEntregas);

        bool EntregarPaquetes(string firma, string nombreReceptor);

    }
}
