using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaLocal
    {
        bool AltaLocal(EntidadesCompartidas.Locales local);

        bool ExisteLocal(string nombre, string direccion);

        EntidadesCompartidas.Locales BuscarLocal(string nombre);

        bool ModificarLocal(EntidadesCompartidas.Locales local);

        List<EntidadesCompartidas.Locales> ListarLocales();
    }
}
