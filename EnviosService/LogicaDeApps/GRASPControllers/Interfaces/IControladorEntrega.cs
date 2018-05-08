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

        List<Entregas> GetEntregasSeleccionadas();

        List<Entregas> GetEntregas();

        void SetEntregas(List<Entregas> pEntregas);

        void SetEntregasSeleccionadas(List<Entregas> pEntregas);

        bool EntregarPaquetes(string firma, string nombreReceptor);

    }
}
