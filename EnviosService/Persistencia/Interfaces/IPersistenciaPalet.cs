using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaPalet
    {
        bool AltaPalet(Palets palet);

        Galpones BuscarGalpon(int id);

        bool BajaPalet(int id);
    }
}
