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
        public static bool AltaUsuario(Usuario unUsuario)
        {

            try
            {
                if (unUsuario is Administrador)
                {
                    return FabricaPersistencia.GetPersistenciaAdministrador().AltaAdministrador((Administrador)unUsuario);
                }
                else if (unUsuario is Cadete)
                {
                    return FabricaPersistencia.GetPersistenciaCadete().AltaCadete((Cadete)unUsuario);
                }
                
                    return FabricaPersistencia.GetPersistenciaCliente().AltaCliente((Cliente)unUsuario);
                

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo dar de alta al usuario.");
            }
        }

        public static bool ExisteCliente(long rut)
        {
            bool existe = false;
            return existe;
        }

        public static bool ExisteEmpleado(int cedula)
        {
             return FabricaPersistencia.GetPersistenciaAdministrador().ExisteAdmin(cedula); 
        }

        public static Cadete SeleccionarCadete(int cedula)
        {
            EntidadesCompartidas.Cadete cadete = new EntidadesCompartidas.Cadete();
            return cadete;
        }

        public static bool ModoficarUsuario(Usuario unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public static List<Empleado> ListarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            return lista;
        }

        public static List<Cadete> ListarCadetesDisponibles()
        {
            List<Cadete> lista = new List<Cadete>();
            return lista;
        }

        public static List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            return clientes;
        }

        public static bool BajaUsuario(int cedula)
        {
            bool exito = false;
            return exito;
        }

        public static EntidadesCompartidas.Usuario Login(string usuario, string password)
        {
            Usuario usuarioLogueado;
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

        public static EntidadesCompartidas.Empleado BuscarEmpleado(int cedula)
        {
            EntidadesCompartidas.Empleado empleado = new EntidadesCompartidas.Empleado();
            return empleado;
        }
    }
}
