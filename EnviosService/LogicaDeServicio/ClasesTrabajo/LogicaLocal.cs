using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public class LogicaLocal
    {
        public bool AltaLocal(Locales unLocal)
        {
            bool exito = false;
            return exito;
        }

        public bool ExisteLocal(string direccion, string nombre)
        {
            bool existe = false;
            return existe;
        }

        public Locales BuscarLocal(string nombreLocal)
        {
            Locales local = new Locales();
            return local;
        }

        public Locales ModificarLocal(Locales unLocal)
        {
            Locales local = new Locales();
            return local;
        }

        public List<Locales> ListarLocales()
        {
            List<Locales> lista = new List<Locales>();
            return lista;
        }
    }
}
