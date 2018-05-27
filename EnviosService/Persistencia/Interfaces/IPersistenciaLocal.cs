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
        bool AltaLocal(EntidadesCompartidas.Local local);

        bool ExisteLocal(string nombre, string direccion);

        EntidadesCompartidas.Local BuscarLocal(string nombre);

        bool ModificarLocal(EntidadesCompartidas.Local local);

        List<EntidadesCompartidas.Local> ListarLocales();
    }
}
