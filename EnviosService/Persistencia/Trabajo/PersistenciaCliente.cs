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
        public bool AltaCliente(Cliente cliente)
        {
            return true;
        }

        public bool ExisteCliente(int rut)
        {
            return true;
        }

        public bool ModificarCliente(Usuario usuario)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public List<Cliente> ListarClientes()
        {
            return new List<Cliente>();
        }

        public Cliente Login(string user, string contraseña)
        {
            Cliente clienteResultado = null;

            EnviosContext dbConexion = new EnviosContext();
            try
            {

                var clienteEncontrado = from cliente in dbConexion.Clientes
                                       where cliente.Usuarios.NombreUsuario == user && cliente.Usuarios.Contraseña == contraseña
                                       select cliente;

                foreach (Clientes c in clienteEncontrado)
                {
                    clienteResultado = new Cliente();
                    clienteResultado.Contraseña = c.Usuarios.Contraseña;
                    clienteResultado.Direccion = c.Usuarios.Direccion;
                    clienteResultado.Email = c.Usuarios.Email;
                    clienteResultado.Id = c.Usuarios.Id;
                    clienteResultado.Mensualidad = c.Mensualidad;
                    clienteResultado.Nombre = c.Usuarios.Nombre;
                    clienteResultado.NombreUsuario = c.Usuarios.NombreUsuario;
                    clienteResultado.RUT = c.RUT;
                    clienteResultado.Telefono = c.Usuarios.Telefono;
                }

                return clienteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar loguear el Cliente" + ex.Message);
            }
        }

        public bool BajaCliente(int ci)
        {
            return true;
        }
    }
}
