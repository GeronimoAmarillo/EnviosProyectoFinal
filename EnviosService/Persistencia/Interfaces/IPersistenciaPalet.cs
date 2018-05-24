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
        bool AltaPalet(EntidadesCompartidas.Palets palet);

        EntidadesCompartidas.Galpones BuscarGalpon(int id);

        bool BajaPalet(EntidadesCompartidas.Palets palet);
    }
}
