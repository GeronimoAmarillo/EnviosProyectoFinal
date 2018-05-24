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
        public static bool AltaUsuario(EntidadesCompartidas.Usuarios unUsuario)
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

        public static EntidadesCompartidas.Cadetes SeleccionarCadete(int cedula)
        {
            EntidadesCompartidas.Cadetes cadete = new EntidadesCompartidas.Cadetes();
            return cadete;
        }

        public static bool ModoficarUsuario(EntidadesCompartidas.Usuarios unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public static List<EntidadesCompartidas.Empleados> ListarEmpleados()
        {
            List<EntidadesCompartidas.Empleados> lista = new List<EntidadesCompartidas.Empleados>();
            return lista;
        }

        public static List<EntidadesCompartidas.Cadetes> ListarCadetesDisponibles()
        {
            List<EntidadesCompartidas.Cadetes> lista = new List<EntidadesCompartidas.Cadetes>();
            return lista;
        }

        public static List<EntidadesCompartidas.Clientes> ListarClientes()
        {
            List<EntidadesCompartidas.Clientes> clientes = new List<EntidadesCompartidas.Clientes>();
            return clientes;
        }

        public static bool BajaUsuario(int cedula)
        {
            bool exito = false;
            return exito;
        }

        public static EntidadesCompartidas.Usuarios Login(string usuario, string password)
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

            return new EntidadesCompartidas.Usuarios();

        }

        public static bool ComprobarUser(string user)
        {
            bool exito = false;
            return exito;
        }

        public static EntidadesCompartidas.Empleados BuscarEmpleado(int cedula)
        {
            EntidadesCompartidas.Empleados empleado = new EntidadesCompartidas.Empleados();
            return empleado;
        }
    }
}
