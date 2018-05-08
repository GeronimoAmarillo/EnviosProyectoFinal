using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorPalet
    {
        Racks GetRack();

        Palets GetPalet();

        void SetPalet(Palets pPalet);

        bool AltaPalet(DTPalet palet);

        List<DTCliente> ListarClientes();

        List<Clientes> GetClientes();

        DTCliente SeleccionarClientes(int rut);

        void SetClientes(List<Clientes> pClientes);

        void SetCliente(Clientes pCliente);

        Clientes GetCliente();

        void IniciarRegistroPalet();

        Galpones GetGalpon();

        void SetGalpon(Galpones pGalpon);

        DTGalpon ObtenerGalpon(int id);

        DTPalet BuscarPalet(int id);

        bool BajaPalet(int id);

        DTRack SeleccionarRack(string codigo);

        DTSector SeleccionarSector(string codigo);
    }
}
