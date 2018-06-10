using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorRealizarEntregas : IControladorRealizarEntregas
    {
        private Entrega entrega;
        private List<Cliente> clientes;
        private Cliente cliente;
        private List<Local> locales;
        private List<Turno> turnos;
        private Local local;
        private List<Cadete> cadetes;
        private Turno turno;
        private Cadete cadete;

        public List<Cliente> ListarClientes()
        {
            return new List<Cliente>();
        }

        public List<Cadete> ListarCadetesDisponibles()
        {
            return new List<Cadete>();
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public void SetCadetes(List<Cadete> cadetesDisponibles)
        {
            cadetes = cadetesDisponibles;
        }

        public void SetClientes(List<Cliente> pClientes)
        {
            clientes = pClientes;
        }

        public List<Cadete> GetCadetes()
        {
            return cadetes;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }

        public void SetCliente(Cliente pCliente)
        {
            cliente = pCliente;
        }

        public void SeleccionarCliente(int rut)
        {

        }

        public List<Turno> GetTurnos()
        {
            return turnos;
        }

        public void SetTurnos(List<Turno> pTurnos)
        {
            turnos = pTurnos;
        }

        public List<Turno> ListarTurnos()
        {
            return new List<Turno>();
        }

        public List<Local> ListarLocales()
        {
            return new List<Local>();
        }

        public List<Local> GetLocales()
        {
            return locales;
        }

        public void SetLocales(List<Local> pLocales)
        {
            locales = pLocales;
        }

        public Entrega GetEntrega()
        {
            return entrega;
        }

        public void SetEntrega(Entrega pEntrega)
        {
            entrega = pEntrega;
        }

        public void SeleccionarLocal(int idLocal)
        {

        }

        public Local GetLocal()
        {
            return local;
        }

        public void SeleccionarCadete(int ci)
        {

        }

        public Cadete GetCadete()
        {
            return cadete;
        }

        public void SeleccionarTurno(string codigo)
        {

        }

        public Turno GetTurno()
        {
            return turno;
        }

        public bool AsignarPaquete(Paquete paquete)
        {
            return true;
        }

        public bool RegistrarEntrega(Entrega pEntrega)
        {
            return true;
        }

        public void IniciarLevanteEntrega()
        {

        }

        public void IniciarRegistroEntrega()
        {

        }
    }
}
