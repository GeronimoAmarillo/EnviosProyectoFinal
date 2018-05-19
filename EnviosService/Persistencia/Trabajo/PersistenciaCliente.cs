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
        EnviosEntities dbConnection;

        public bool AltaCliente(Clientes cliente)
        {
            try
            {
                if (dbConnection.Clientes.Any(x => x.RUT.ToString() == cliente.RUT.ToString()))
                {
                    return false;
                }
                else
                {
                    dbConnection.Clientes.Add(cliente);
                    dbConnection.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar agregar el Cliente o el RUT ya se encuentra registrado" + ex.Message);
            }

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
            Clientes clienteLogueado = new Clientes();
            EnviosEntities dbConexion = new EnviosEntities();
            try
            {

                var clienteEncontrado = from cliente in dbConexion.Clientes
                                       where cliente.Usuarios.NombreUsuario == user && cliente.Usuarios.Contraseña == contraseña
                                       select cliente;

                foreach (Clientes c in clienteEncontrado)
                {
                    clienteLogueado = c;
                }

                return clienteLogueado;
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
