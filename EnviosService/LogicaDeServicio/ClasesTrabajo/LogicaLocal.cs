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
        public bool altaLocal(Locales unLocal)
        {
            bool exito = false;
            return exito;
        }

        public bool existeLocal(string direccion, string nombre)
        {
            bool existe = false;
            return existe;
        }

        public Locales buscarLocal(string nombreLocal)
        {
            Locales local = new Locales();
            return local;
        }

        public Locales modificarLocal(Locales unLocal)
        {
            Locales local = new Locales();
            return local;
        }

        public List<Locales> listarLocales()
        {
            List<Locales> lista = new List<Locales>();
            return lista;
        }
    }
}
