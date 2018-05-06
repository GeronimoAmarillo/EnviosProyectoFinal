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
        public bool AltaPalet(Palets palet)
        {
            return true;
        }

        public Galpones BuscarGalpon(int id)
        {
            return new Galpones();
        }

        public bool BajaPalet(int id)
        {
            return true;
        }
    }
}
