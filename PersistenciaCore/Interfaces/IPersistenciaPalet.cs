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

        List<Palet> ListarPalets();

        bool BajaPalet(int id);

        List<EntidadesCompartidasCore.Palet> ListarPaletsTodos();
    }
}
