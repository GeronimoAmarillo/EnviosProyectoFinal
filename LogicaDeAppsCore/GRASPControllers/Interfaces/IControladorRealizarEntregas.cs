using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorRealizarEntregas
    {
        List<Cliente> ListarClientes();

        Task<List<Cadete>> ListarCadetesDisponibles();

        List<Cliente> GetClientes();

        void SetCadetes(List<Cadete> cadetesDisponibles);

        void SetClientes(List<Cliente> pClientes);

        List<Cadete> GetCadetes();

        Cliente GetCliente();

        void SetCliente(Cliente pCliente);

        void SeleccionarCliente(int rut);

        List<Turno> GetTurnos();

        void SetTurnos(List<Turno> pTurnos);

        List<Turno> ListarTurnos();

        List<Local> ListarLocales();

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

        bool AsignarPaquete(Paquete paquete);

        bool RegistrarEntrega(Entrega pEntrega);

        void IniciarLevanteEntrega();

        void IniciarRegistroEntrega();

    }
}
