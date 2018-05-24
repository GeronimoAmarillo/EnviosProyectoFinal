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
        bool Entregar(List<EntidadesCompartidas.Entregas> entregas);

        List<EntidadesCompartidas.Entregas> ListarEntregas();

        bool AltaEntrega(EntidadesCompartidas.Entregas entrega);
    }
}
