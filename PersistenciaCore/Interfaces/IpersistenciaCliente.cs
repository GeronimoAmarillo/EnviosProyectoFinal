using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaCliente
    {
        bool AltaCliente(EntidadesCompartidasCore.Cliente cliente);
        Cliente BuscarClienteXEmail(string email);

        bool ExisteCliente(long rut);

        bool ModificarCliente(EntidadesCompartidasCore.Cliente unCliente);

        bool ComprobarUser(string user);

        List<EntidadesCompartidasCore.Cliente> ListarClientes();

        Cliente BuscarCliente(int rut);

        EntidadesCompartidasCore.Cliente Login(string user, string contraseña);

        bool BajaCliente(int ci);

        bool ExisteClienteXEmail(string email);
    }
}
