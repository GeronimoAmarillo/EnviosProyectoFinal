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

        public Locales BuscarLocal(string nombre)
        {
            return new Locales();
        }

        public bool ModificarLocal(Locales local)
        {
            return true;
        }

        public bool AltaLocal(Locales local)
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
