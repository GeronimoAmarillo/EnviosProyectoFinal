using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorLocal:IControladorLocal
    {
        public bool ExisteLocal(string nombre, string direccion)
        {
            return true;
        }

        public EntidadesCompartidas.Locales BuscarLocal(string nombre)
        {
            return new EntidadesCompartidas.Locales();
        }

        public bool ModificarLocal(EntidadesCompartidas.Locales local)
        {
            return true;
        }

        public bool AltaLocal(EntidadesCompartidas.Locales local)
        {
            try
            {
                return LogicaLocal.AltaLocal(local);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }
    }
}
