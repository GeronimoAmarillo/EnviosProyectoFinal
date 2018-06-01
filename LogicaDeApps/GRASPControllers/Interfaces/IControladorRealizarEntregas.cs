using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorRealizarEntregas
    {
        List<DTCliente> ListarClientes();

        List<DTCadete> ListarCadetesDisponibles();

        List<Cliente> GetClientes();

        void SetCadetes(List<Cadete> cadetesDisponibles);

        void SetClientes(List<Cliente> pClientes);

        List<Cadete> GetCadetes();

        Cliente GetCliente();

        void SetCliente(Cliente pCliente);

        void SeleccionarCliente(int rut);

        List<Turno> GetTurnos();

        void SetTurnos(List<Turno> pTurnos);

        List<DTTurno> ListarTurnos();

        List<DTLocal> ListarLocales();

        List<Local> GetLocales();

        void SetLocales(List<Local> pLocales);

        Entrega GetEntrega();

        void SetEntrega(Entrega pEntrega);

        void SeleccionarLocal(int idLocal);

        Local GetLocal();

        void SeleccionarCadete(int ci);

        Cadete GetCadete();

        void SeleccionarTurno(string codigo);

        Turno GetTurno();

        bool AsignarPaquete(DTPaquete paquete);

        bool RegistrarEntrega(DTEntrega pEntrega);

        void IniciarLevanteEntrega();

        void IniciarRegistroEntrega();

    }
}
