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

        List<Clientes> GetClientes();

        void SetCadetes(List<Cadetes> cadetesDisponibles);

        void SetClientes(List<Clientes> pClientes);

        List<Cadetes> GetCadetes();

        Clientes GetCliente();

        void SetCliente(Clientes pCliente);

        void SeleccionarCliente(int rut);

        List<Turnos> GetTurnos();

        void SetTurnos(List<Turnos> pTurnos);

        List<DTTurno> ListarTurnos();

        List<DTLocal> ListarLocales();

        List<Locales> GetLocales();

        void SetLocales(List<Locales> pLocales);

        Entregas GetEntrega();

        void SetEntrega(Entregas pEntrega);

        void SeleccionarLocal(int idLocal);

        Locales GetLocal();

        void SeleccionarCadete(int ci);

        Cadetes GetCadete();

        void SeleccionarTurno(string codigo);

        Turnos GetTurno();

        bool AsignarPaquete(DTPaquete paquete);

        bool RegistrarEntrega(DTEntrega pEntrega);

        void IniciarLevanteEntrega();

        void IniciarRegistroEntrega();

    }
}
