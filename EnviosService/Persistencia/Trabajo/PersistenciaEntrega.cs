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
        public bool Entregar(List<EntidadesCompartidas.Entregas> entregas)
        {
            return true;
        }

        public List<EntidadesCompartidas.Entregas> ListarEntregas()
        {
            return new List<EntidadesCompartidas.Entregas>();
        }

        public bool AltaEntrega(EntidadesCompartidas.Entregas entrega)
        {
            return true;
        }
    }
}
