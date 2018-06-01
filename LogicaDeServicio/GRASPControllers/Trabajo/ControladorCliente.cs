using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorCliente:IControladorCliente
    {
        public bool ExisteCliente(int rut)
        {
            return true;
        }

        
        public EntidadesCompartidas.Cliente BuscarCliente(int rut)
        {
            return new Cliente();
        }

        public bool ModificarCliente(EntidadesCompartidas.Cliente pCliente)
        {
            return true;
        }

        public bool AltaCliente(EntidadesCompartidas.Cliente pCliente)
        {
            return true;
        }
    }
}
