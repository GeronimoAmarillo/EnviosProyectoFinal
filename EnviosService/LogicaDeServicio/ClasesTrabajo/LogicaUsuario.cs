using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace LogicaDeServicio
{
    public class LogicaUsuario
    {
        public static bool AltaUsuario(EntidadesCompartidas.Usuario unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public static bool ExisteCliente(long rut)
        {
            bool existe = false;
            return existe;
        }

        public static bool ExisteEmpleado(int cedula)
        {
            bool existe = false;
            return existe;
        }

        public static EntidadesCompartidas.Cadete SeleccionarCadete(int cedula)
        {
            EntidadesCompartidas.Cadete cadete = new EntidadesCompartidas.Cadete();
            return cadete;
        }

        public static bool ModoficarUsuario(EntidadesCompartidas.Usuario unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public static List<EntidadesCompartidas.Empleado> ListarEmpleados()
        {
            List<EntidadesCompartidas.Empleado> lista = new List<EntidadesCompartidas.Empleado>();
            return lista;
        }

        public static List<EntidadesCompartidas.Cadete> ListarCadetesDisponibles()
        {
            List<EntidadesCompartidas.Cadete> lista = new List<EntidadesCompartidas.Cadete>();
            return lista;
        }

        public static List<EntidadesCompartidas.Cliente> ListarClientes()
        {
            List<EntidadesCompartidas.Cliente> clientes = new List<EntidadesCompartidas.Cliente>();
            return clientes;
        }

        public static bool BajaUsuario(int cedula)
        {
            bool exito = false;
            return exito;
        }

        public static EntidadesCompartidas.Usuario Login(string usuario, string password)
        {
            /*EntidadesCompartidas.Usuarios usuarioLogueado;
            try
            {
                usuarioLogueado = FabricaPersistencia.GetPersistenciaAdministrador().Login(usuario, password);

                if (usuarioLogueado == null)
                {
                    usuarioLogueado = FabricaPersistencia.GetPersistenciaCadete().Login(usuario, password);
                }

                if (usuarioLogueado == null)
                {
                    usuarioLogueado = FabricaPersistencia.GetPersistenciaCliente().Login(usuario, password);
                }

                return usuarioLogueado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al loguear el Usuario" + ex.Message);
            }*/

            return new EntidadesCompartidas.Usuario();

        }

        public static bool ComprobarUser(string user)
        {
            bool exito = false;
            return exito;
        }

        public static EntidadesCompartidas.Empleado BuscarEmpleado(int cedula)
        {
            EntidadesCompartidas.Empleado empleado = new EntidadesCompartidas.Empleado();
            return empleado;
        }
    }
}
