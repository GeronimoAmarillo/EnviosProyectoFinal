using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorPalet: IControladorPalet
    {
        private Palet palet;
        private List<Cliente> clientes;
        private Cliente cliente;
        private Galpon galpon;
        private Rack rack;
        private Sector sector;

        public Rack GetRack()
        {
            return rack;
        }

        public Palet GetPalet()
        {
            return palet;
        }

        public void SetPalet(Palet pPalet)
        {
            palet = pPalet;
        }

        public bool AltaPalet(Palet palet)
        {
            return true;
        }

        public List<Cliente> ListarClientes()
        {
            return new List<Cliente>();
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public Cliente SeleccionarClientes(int rut)
        {
            return new Cliente();
        }

        public void SetClientes(List<Cliente> pClientes)
        {
            clientes = pClientes;
        }

        public void SetCliente(Cliente pCliente)
        {
            cliente = pCliente;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }

        public void IniciarRegistroPalet()
        {

        }

        public Galpon GetGalpon()
        {
            return galpon;
        }

        public void SetGalpon(Galpon pGalpon)
        {
            galpon = pGalpon;
        }

        public Galpon ObtenerGalpon(int id)
        {
            return new Galpon();
        }

        public Palet BuscarPalet(int id)
        {
            return new Palet();
        }

        public bool BajaPalet(int id)
        {
            return true;
        }

        public Rack SeleccionarRack(string codigo)
        {
            return new Rack();
        }

        public Sector SeleccionarSector(string codigo)
        {
            return new Sector();
        }
    }
}
