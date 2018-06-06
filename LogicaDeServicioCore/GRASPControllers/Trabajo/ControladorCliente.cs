using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorCliente:IControladorCliente
    {
        public bool ExisteCliente(int rut)
        {
            return true;
        }

        
        public EntidadesCompartidasCore.Cliente BuscarCliente(int rut)
        {
            return new Cliente();
        }

        public bool ModificarCliente(EntidadesCompartidasCore.Cliente pCliente)
        {
            return true;
        }

        public bool AltaCliente(EntidadesCompartidasCore.Cliente pCliente)
        {
            return true;
        }
    }
}
