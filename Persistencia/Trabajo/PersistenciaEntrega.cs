using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaEntrega:IPersistenciaEntrega
    {
        public bool Entregar(List<EntidadesCompartidas.Entrega> entregas)
        {
            return true;
        }

        public List<EntidadesCompartidas.Entrega> ListarEntregas()
        {
            return new List<EntidadesCompartidas.Entrega>();
        }

        public bool AltaEntrega(EntidadesCompartidas.Entrega entrega)
        {
            return true;
        }
    }
}
