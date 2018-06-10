using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorPalet
    {
        Rack GetRack();

        Palet GetPalet();

        void SetPalet(Palet pPalet);

        bool AltaPalet(Palet palet);

        List<Cliente> ListarClientes();

        List<Cliente> GetClientes();

        Cliente SeleccionarClientes(int rut);

        void SetClientes(List<Cliente> pClientes);

        void SetCliente(Cliente pCliente);

        Cliente GetCliente();

        void IniciarRegistroPalet();

        Galpon GetGalpon();

        void SetGalpon(Galpon pGalpon);

        Galpon ObtenerGalpon(int id);

        Palet BuscarPalet(int id);

        bool BajaPalet(int id);

        Rack SeleccionarRack(string codigo);

        Sector SeleccionarSector(string codigo);
    }
}
