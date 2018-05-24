using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCliente
    {
        bool AltaCliente(EntidadesCompartidas.Clientes cliente);

        bool ExisteCliente(int rut);

        bool ModificarCliente(EntidadesCompartidas.Usuarios usuario);

        bool ComprobarUser(string user);

        List<EntidadesCompartidas.Clientes> ListarClientes();

        EntidadesCompartidas.Clientes Login(string user, string contraseña);

        bool BajaCliente(int ci);
    }
}
