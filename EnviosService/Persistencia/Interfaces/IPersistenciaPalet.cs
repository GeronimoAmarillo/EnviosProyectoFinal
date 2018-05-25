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
        bool AltaPalet(EntidadesCompartidas.Palet palet);

        EntidadesCompartidas.Galpon BuscarGalpon(int id);

        bool BajaPalet(EntidadesCompartidas.Palet palet);
    }
}
