using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaCliente:IPersistenciaCliente
    {
        public bool AltaCliente(Clientes cliente)
        {
            return true;
        }

        public bool ExisteCliente(int rut)
        {
            return true;
        }

        public bool ModificarCliente(Usuarios usuario)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public List<Clientes> ListarClientes()
        {
            return new List<Clientes>();
        }

        public Clientes Login(string user, string contraseña)
        {
            return new Clientes();
        }

        public bool BajaCliente(int ci)
        {
            return true;
        }
    }
}
