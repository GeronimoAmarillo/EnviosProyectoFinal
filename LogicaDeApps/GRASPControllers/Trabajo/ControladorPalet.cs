using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
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

        public bool AltaPalet(DTPalet palet)
        {
            return true;
        }

        public List<DTCliente> ListarClientes()
        {
            return new List<DTCliente>();
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public DTCliente SeleccionarClientes(int rut)
        {
            return new DTCliente();
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

        public DTGalpon ObtenerGalpon(int id)
        {
            return new DTGalpon();
        }

        public DTPalet BuscarPalet(int id)
        {
            return new DTPalet();
        }

        public bool BajaPalet(int id)
        {
            return true;
        }

        public DTRack SeleccionarRack(string codigo)
        {
            return new DTRack();
        }

        public DTSector SeleccionarSector(string codigo)
        {
            return new DTSector();
        }
    }
}
