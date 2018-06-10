using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorCliente: IControladorCliente
    {
        private Cliente cliente;

        public bool ExisteCliente(int rut)
        {
            return true;
        }

        public void IniciarRegistroCliente()
        {

        }

        public Cliente GetCliente()
        {
            return cliente;
        }

        public Cliente BuscarCliente(int rut)
        {
            return new Cliente();
        }

        public bool ModificarCliente(Cliente pCliente)
        {
            return true;
        }

        public void SetCliente(Cliente pCliente)
        {
            cliente = pCliente;
        }

        public bool RegistrarCliente(Cliente pCliente)
        {
            return true;
        }
    }
}
