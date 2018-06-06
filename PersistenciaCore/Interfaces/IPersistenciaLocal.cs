using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaLocal
    {
        bool AltaLocal(EntidadesCompartidasCore.Local local);

        bool ExisteLocal(string nombre, string direccion);

        EntidadesCompartidasCore.Local BuscarLocal(string nombre);

        bool ModificarLocal(EntidadesCompartidasCore.Local local);

        List<EntidadesCompartidasCore.Local> ListarLocales();
    }
}
