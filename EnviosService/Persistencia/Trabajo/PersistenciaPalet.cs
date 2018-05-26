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
        public bool AltaPalet(EntidadesCompartidas.Palet palet)
        {
            return true;
        }

        public EntidadesCompartidas.Galpon BuscarGalpon(int id)
        {
            return new EntidadesCompartidas.Galpon();
        }

        public bool BajaPalet(EntidadesCompartidas.Palet palet)
        {
            return true;
        }
    }
}
