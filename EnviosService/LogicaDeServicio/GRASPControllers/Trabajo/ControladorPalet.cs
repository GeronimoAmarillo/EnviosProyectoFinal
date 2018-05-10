using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorPalet:IControladorPalet
    {
        

        public bool AltaPalet(Palets palet)
        {
            return true;
        }

        public List<Clientes> ListarClientes()
        {
            return new List<Clientes>();
        }

        public Galpones BuscarGalpon(int id)
        {
            return new Galpones();
        }

        public Palets BuscarPalet(int id)
        {
            return new Palets();
        }

        public bool BajaPalet(Palets palet)
        {
            return true;
        }
    }
}
