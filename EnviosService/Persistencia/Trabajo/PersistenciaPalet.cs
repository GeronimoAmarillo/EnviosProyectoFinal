using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
namespace Persistencia
{
    class PersistenciaPalet:IPersistenciaPalet
    {
        public bool AltaPalet(EntidadesCompartidas.Palets palet)
        {
            return true;
        }

        public EntidadesCompartidas.Galpones BuscarGalpon(int id)
        {
            return new EntidadesCompartidas.Galpones();
        }

        public bool BajaPalet(EntidadesCompartidas.Palets palet)
        {
            return true;
        }
    }
}
