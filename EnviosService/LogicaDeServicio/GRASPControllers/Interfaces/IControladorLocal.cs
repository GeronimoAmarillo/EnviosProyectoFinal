using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorLocal
    {
        bool ExisteLocal(string nombre, string direccion);

        Locales BuscarLocal(string nombre);

        bool ModificarLocal(Locales local);

        bool AltaLocal(Locales local);
    }
}
