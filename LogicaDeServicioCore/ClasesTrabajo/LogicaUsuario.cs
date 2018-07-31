using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaUsuario
    {
        public static bool AltaUsuario(Usuario unUsuario)
        {
            bool exito = false;
            try
            {
                if (unUsuario is Cliente)
                {
                    if (!ExisteCliente(((Cliente)unUsuario).RUT))
                    {
                        unUsuario.NombreUsuario = unUsuario.Email;
                        unUsuario.Contraseña = CrearContrasenia();
                        exito = FabricaPersistencia.GetPersistenciaCliente().AltaCliente((Cliente)unUsuario);
                        return exito;
                    }

                }
                return exito;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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

        public static EntidadesCompartidasCore.Cadete SeleccionarCadete(int cedula)
        {
            EntidadesCompartidasCore.Cadete cadete = new EntidadesCompartidasCore.Cadete();
            return cadete;
        }

        public static bool ModoficarUsuario(EntidadesCompartidasCore.Usuario unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public static List<EntidadesCompartidasCore.Empleado> ListarEmpleados()
        {
            try
            {
                List<Empleado> lista = new List<Empleado>();

                List<Administrador> admins = FabricaPersistencia.GetPersistenciaAdministrador().ListarAdministradores();

                lista.AddRange(admins);

                List<Cadete> cadetes = FabricaPersistencia.GetPersistenciaCadete().ListarCadetes();

                lista.AddRange(cadetes);

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los empleados." + ex.Message);
            }
        }

        public static List<EntidadesCompartidasCore.Cadete> ListarCadetesDisponibles()
        {
            List<EntidadesCompartidasCore.Cadete> lista = new List<EntidadesCompartidasCore.Cadete>();
            return lista;
        }

        public static List<EntidadesCompartidasCore.Cliente> ListarClientes()
        {
            try
            {
                List<Cliente> lista = FabricaPersistencia.GetPersistenciaCliente().ListarClientes();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes." + ex.Message);
            }
        }

        public static bool BajaUsuario(int cedula)
        {
            bool exito = false;
            return exito;
        }

        public static EntidadesCompartidasCore.Usuario Login(string usuario, string password)
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

        public static EntidadesCompartidasCore.Empleado BuscarEmpleado(int cedula)
        {
            Empleado empleado;

            try
            {
                empleado = FabricaPersistencia.GetPersistenciaAdministrador().BuscarAdministrador(cedula);

                if (empleado == null)
                {
                    empleado = FabricaPersistencia.GetPersistenciaCadete().BuscarCadete(cedula);
                }

                return empleado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Empleado" + ex.Message);
            }
        }

        public static string CrearContrasenia()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_@*#.";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int charNum = 1;
            while (charNum < 25)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
                charNum++;
            }
            return res.ToString();
        }
    }
}
