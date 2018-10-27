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
        bool RealizarReclamo(Reclamo reclamo);

        Paquete GetPaquete();

        Task<Paquete> BuscarPaquete(int codigo);

        void SetPaquete(Paquete pPaquete);

        Task<List<EntidadesCompartidasCore.Reclamo>> ListarReclamos();

    }
}
