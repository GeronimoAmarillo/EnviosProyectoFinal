using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorLocal:IControladorLocal
    {
        private Locales local;

        public bool ExisteLocal(string nombre, string direccion)
        {
            return true;
        }

        public void IniciarRegistroLocal()
        {

        }

        public DTLocal BuscarLocal(string nombre)
        {
            return new DTLocal();
        }

        public bool ModificarLocal(DTLocal local)
        {
            return true;
        }

        public void SetLocal(Locales pLocal)
        {
            local = pLocal;
        }

        public bool AltaLocal()
        {
            return true;
        }
    }
}
