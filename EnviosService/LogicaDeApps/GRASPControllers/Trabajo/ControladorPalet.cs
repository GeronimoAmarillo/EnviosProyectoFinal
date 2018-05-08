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
        private Palets palet;
        private List<Clientes> clientes;
        private Clientes cliente;
        private Galpones galpon;
        private Racks rack;
        private Sectores sector;

        public Racks GetRack()
        {
            return rack;
        }

        public Palets GetPalet()
        {
            return palet;
        }

        public void SetPalet(Palets pPalet)
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

        public List<Clientes> GetClientes()
        {
            return clientes;
        }

        public DTCliente SeleccionarClientes(int rut)
        {
            return new DTCliente();
        }

        public void SetClientes(List<Clientes> pClientes)
        {
            clientes = pClientes;
        }

        public void SetCliente(Clientes pCliente)
        {
            cliente = pCliente;
        }

        public Clientes GetCliente()
        {
            return cliente;
        }

        public void IniciarRegistroPalet()
        {

        }

        public Galpones GetGalpon()
        {
            return galpon;
        }

        public void SetGalpon(Galpones pGalpon)
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
