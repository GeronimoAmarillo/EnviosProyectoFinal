using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaPalet
    {
        bool AltaPalet(EntidadesCompartidasCore.Palet palet);

        EntidadesCompartidasCore.Galpon BuscarGalpon(int id);

        Palet BuscarPalet(int id);

        bool BajaPalet(int id);
    }
}
