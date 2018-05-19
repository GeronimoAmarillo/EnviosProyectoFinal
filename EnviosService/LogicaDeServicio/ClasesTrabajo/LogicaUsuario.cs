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
        public static bool AltaUsuario(Usuarios unUsuario)
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

        public static Cadetes SeleccionarCadete(int cedula)
        {
            Cadetes cadete = new Cadetes();
            return cadete;
        }

        public static bool ModoficarUsuario(Usuarios unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public static List<Empleados> ListarEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            return lista;
        }

        public static List<Cadetes> ListarCadetesDisponibles()
        {
            List<Cadetes> lista = new List<Cadetes>();
            return lista;
        }

        public static List<Clientes> ListarClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            return clientes;
        }

        public static bool BajaUsuario(int cedula)
        {
            bool exito = false;
            return exito;
        }

        public static Usuarios Login(string usuario, string password)
        {
            Usuarios usuarioLogueado;
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
            }

        }

        public static bool ComprobarUser(string user)
        {
            bool exito = false;
            return exito;
        }

        public static Empleados BuscarEmpleado(int cedula)
        {
            Empleados empleado = new Empleados();
            return empleado;
        }
    }
}
