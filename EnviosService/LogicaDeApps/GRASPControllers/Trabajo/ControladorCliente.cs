using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorCliente: IControladorCliente
    {
        private Clientes cliente;

        public bool ExisteCliente(int rut)
        {
            return true;
        }

        public void IniciarRegistroCliente()
        {

        }

        public Clientes GetCliente()
        {
            return cliente;
        }

        public DTCliente BuscarCliente(int rut)
        {
            return new DTCliente();
        }

        public bool ModificarCliente(DTCliente pCliente)
        {
            return true;
        }

        public void SetCliente(Clientes pCliente)
        {
            cliente = pCliente;
        }

        public bool RegistrarCliente(DTCliente pCliente)
        {
            return true;
        }
    }
}
