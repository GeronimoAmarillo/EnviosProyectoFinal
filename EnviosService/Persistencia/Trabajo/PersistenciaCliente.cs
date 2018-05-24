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
        public bool AltaCliente(EntidadesCompartidas.Clientes cliente)
        {
            return true;
        }

        public bool ExisteCliente(int rut)
        {
            return true;
        }

        public bool ModificarCliente(EntidadesCompartidas.Usuarios usuario)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public List<EntidadesCompartidas.Clientes> ListarClientes()
        {
            return new List<EntidadesCompartidas.Clientes>();
        }

        public EntidadesCompartidas.Clientes Login(string user, string contraseña)
        {
            /*Clientes clienteLogueado = new Clientes();
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
            }*/

            return new EntidadesCompartidas.Clientes();
        }

        public bool BajaCliente(int ci)
        {
            return true;
        }
    }
}
