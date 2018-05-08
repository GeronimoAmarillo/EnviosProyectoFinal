using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorRealizarEntregas : IControladorRealizarEntregas
    {
        private Entregas entrega;
        private List<Clientes> clientes;
        private Clientes cliente;
        private List<Locales> locales;
        private List<Turnos> turnos;
        private Locales local;
        private List<Cadetes> cadetes;
        private Turnos turno;
        private Cadetes cadete;

        public List<DTCliente> ListarClientes()
        {
            return new List<DTCliente>();
        }

        public List<DTCadete> ListarCadetesDisponibles()
        {
            return new List<DTCadete>();
        }

        public List<Clientes> GetClientes()
        {
            return clientes;
        }

        public void SetCadetes(List<Cadetes> cadetesDisponibles)
        {
            cadetes = cadetesDisponibles;
        }

        public void SetClientes(List<Clientes> pClientes)
        {
            clientes = pClientes;
        }

        public List<Cadetes> GetCadetes()
        {
            return cadetes;
        }

        public Clientes GetCliente()
        {
            return cliente;
        }

        public void SetCliente(Clientes pCliente)
        {
            cliente = pCliente;
        }

        public void SeleccionarCliente(int rut)
        {

        }

        public List<Turnos> GetTurnos()
        {
            return turnos;
        }

        public void SetTurnos(List<Turnos> pTurnos)
        {
            turnos = pTurnos;
        }

        public List<DTTurno> ListarTurnos()
        {
            return new List<DTTurno>();
        }

        public List<DTLocal> ListarLocales()
        {
            return new List<DTLocal>();
        }

        public List<Locales> GetLocales()
        {
            return locales;
        }

        public void SetLocales(List<Locales> pLocales)
        {
            locales = pLocales;
        }

        public Entregas GetEntrega()
        {
            return entrega;
        }

        public void SetEntrega(Entregas pEntrega)
        {
            entrega = pEntrega;
        }

        public void SeleccionarLocal(int idLocal)
        {

        }

        public Locales GetLocal()
        {
            return local;
        }

        public void SeleccionarCadete(int ci)
        {

        }

        public Cadetes GetCadete()
        {
            return cadete;
        }

        public void SeleccionarTurno(string codigo)
        {

        }

        public Turnos GetTurno()
        {
            return turno;
        }

        public bool AsignarPaquete(DTPaquete paquete)
        {
            return true;
        }

        public bool RegistrarEntrega(DTEntrega pEntrega)
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
