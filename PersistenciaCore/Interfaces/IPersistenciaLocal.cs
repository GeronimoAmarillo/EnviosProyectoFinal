using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    public interface IPersistenciaLocal
    {
        bool AltaLocal(EntidadesCompartidasCore.Local local);

        bool ExisteLocal(string nombre, string direccion);

        EntidadesCompartidasCore.Local BuscarLocal(int id);

        bool ModificarLocal(EntidadesCompartidasCore.Local local);

        List<EntidadesCompartidasCore.Local> ListarLocales();
    }
}
