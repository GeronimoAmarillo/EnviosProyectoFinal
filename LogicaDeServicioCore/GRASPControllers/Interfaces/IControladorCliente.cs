using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorCliente
    {
        bool ExisteCliente(long rut);

        Cliente BuscarCliente(long rut);

        bool ModificarCliente(Cliente pCliente);

        bool AltaCliente(Cliente pCliente);

        bool ExisteClienteXEmail(string email);

        List<EntidadesCompartidasCore.Cliente> ListarClientes();

        EntidadesCompartidasCore.Cliente BuscarClienteXEmail(string email);
    }
}
