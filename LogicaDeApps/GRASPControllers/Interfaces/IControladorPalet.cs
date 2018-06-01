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
        Rack GetRack();

        Palet GetPalet();

        void SetPalet(Palet pPalet);

        bool AltaPalet(DTPalet palet);

        List<DTCliente> ListarClientes();

        List<Cliente> GetClientes();

        DTCliente SeleccionarClientes(int rut);

        void SetClientes(List<Cliente> pClientes);

        void SetCliente(Cliente pCliente);

        Cliente GetCliente();

        void IniciarRegistroPalet();

        Galpon GetGalpon();

        void SetGalpon(Galpon pGalpon);

        DTGalpon ObtenerGalpon(int id);

        DTPalet BuscarPalet(int id);

        bool BajaPalet(int id);

        DTRack SeleccionarRack(string codigo);

        DTSector SeleccionarSector(string codigo);
    }
}
