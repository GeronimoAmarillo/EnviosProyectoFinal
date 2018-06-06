using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
namespace PersistenciaCore
{
    class PersistenciaPalet:IPersistenciaPalet
    {
        public bool AltaPalet(EntidadesCompartidasCore.Palet palet)
        {
            return true;
        }

        public EntidadesCompartidasCore.Galpon BuscarGalpon(int id)
        {
            return new EntidadesCompartidasCore.Galpon();
        }

        public bool BajaPalet(EntidadesCompartidasCore.Palet palet)
        {
            return true;
        }
    }
}
