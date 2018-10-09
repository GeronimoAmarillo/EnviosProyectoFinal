using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorCliente
    {
        bool ExisteCliente(int rut);

        void IniciarRegistroCliente();
        

        Cliente GetCliente();

        Task<Cliente> BuscarCliente(int rut);

        Task<List<Cliente>> ListarClientes();

        Task<bool> ExisteClienteXEmail(string email);

        bool ModificarCliente(Cliente pCliente);

        void SetCliente(Cliente pCliente);

        bool RegistrarCliente(Cliente pCliente);
        Task<Cliente> BuscarClienteXEmail(string email);
    }
}
