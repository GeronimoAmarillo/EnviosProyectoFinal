using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorPaquete
    {
        bool RealizarReclamo(string descripcion);

        Paquete GetPaquete();

        Paquete BuscarPaquete(int codigo);

        void SetPaquete(Paquete pPaquete);

        Task<List<EntidadesCompartidasCore.Reclamo>> ListarReclamos();

    }
}
