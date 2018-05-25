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
        bool AltaCliente(EntidadesCompartidas.Cliente cliente);

        bool ExisteCliente(int rut);

        bool ModificarCliente(EntidadesCompartidas.Usuario usuario);

        bool ComprobarUser(string user);

        List<EntidadesCompartidas.Cliente> ListarClientes();

        EntidadesCompartidas.Cliente Login(string user, string contraseña);

        bool BajaCliente(int ci);
    }
}
