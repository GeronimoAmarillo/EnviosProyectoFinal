using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
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

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Where(c => c.Usuarios.NombreUsuario == user && c.Usuarios.Contraseña == contraseña).Select(c => new {
                        Cliente = c,
                        Usuario = c.Usuarios
                    }).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {

                        if (clienteEncontrado.Usuario != null && clienteEncontrado.Cliente != null)
                        {
                            clienteResultado = new Cliente();


                            clienteResultado.Contraseña = clienteEncontrado.Usuario.Contraseña;
                            clienteResultado.Direccion = clienteEncontrado.Usuario.Direccion;
                            clienteResultado.Email = clienteEncontrado.Usuario.Email;
                            clienteResultado.Id = clienteEncontrado.Usuario.Id;
                            clienteResultado.Mensualidad = clienteEncontrado.Cliente.Mensualidad;
                            clienteResultado.Nombre = clienteEncontrado.Usuario.Nombre;
                            clienteResultado.NombreUsuario = clienteEncontrado.Usuario.NombreUsuario;
                            clienteResultado.RUT = clienteEncontrado.Cliente.RUT;
                            clienteResultado.Telefono = clienteEncontrado.Usuario.Telefono;
                        }
                        
                    }

                    return clienteResultado;
                }

                    
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
