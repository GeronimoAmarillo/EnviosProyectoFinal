using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaEntrega
    {
        bool Entregar(List<EntidadesCompartidas.Entrega> entregas);

        List<EntidadesCompartidas.Entrega> ListarEntregas();

        bool AltaEntrega(EntidadesCompartidas.Entrega entrega);
    }
}
