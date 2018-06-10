using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaEntrega:IPersistenciaEntrega
    {
        public bool Entregar(List<EntidadesCompartidasCore.Entrega> entregas)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Entrega> ListarEntregas()
        {
            return new List<EntidadesCompartidasCore.Entrega>();
        }

        public bool AltaEntrega(EntidadesCompartidasCore.Entrega entrega)
        {
            return true;
        }
    }
}
