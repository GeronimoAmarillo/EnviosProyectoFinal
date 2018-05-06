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
        bool AltaLocal(Locales local);

        bool ExisteLocal(string nombre, string direccion);

        Locales BuscarLocal(string nombre);

        bool ModificarLocal(Locales local);

        List<Locales> ListarLocales();
    }
}
