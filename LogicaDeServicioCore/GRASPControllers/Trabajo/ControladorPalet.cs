using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorPalet:IControladorPalet
    {
        

        public bool AltaPalet(Palet palet)
        {
            return true;
        }

        public List<Cliente> ListarClientes()
        {
            return new List<Cliente>();
        }

        public Galpon BuscarGalpon(int id)
        {
            return new Galpon();
        }

        public Palet BuscarPalet(int id)
        {
            return new Palet();
        }

        public bool BajaPalet(Palet palet)
        {
            return true;
        }
    }
}
