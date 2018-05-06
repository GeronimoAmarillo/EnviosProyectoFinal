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
        public bool Entregar(List<Entregas> entregas)
        {
            return true;
        }

        public List<Entregas> ListarEntregas()
        {
            return new List<Entregas>();
        }

        public bool AltaEntrega(Entregas entrega)
        {
            return true;
        }
    }
}
