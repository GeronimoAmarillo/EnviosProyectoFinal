using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaEntrega
    {
        bool Entregar(EntidadesCompartidasCore.Entrega entrega);

        List<EntidadesCompartidasCore.Entrega> ListarEntregas();

        bool AltaEntrega(EntidadesCompartidasCore.Entrega entrega);

        Entrega BuscarEntrega(int codigo);
    }
}
