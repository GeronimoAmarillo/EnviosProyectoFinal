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
                if (unUsuario is Administrador)
                {
                    if (!ExisteEmpleado(((Administrador)unUsuario).Ci))
                    {
                        unUsuario.NombreUsuario = unUsuario.Email;
                        unUsuario.Contraseña = CrearContrasenia();
                        exito = FabricaPersistencia.GetPersistenciaAdministrador().AltaAdministrador((Administrador)unUsuario);
                        return exito;
                    }

                }
                if (unUsuario is Cadete)
                {
                    if (!ExisteEmpleado(((Cadete)unUsuario).Ci))
                    {
                        unUsuario.NombreUsuario = unUsuario.Email;
                        unUsuario.Contraseña = CrearContrasenia();
                        exito = FabricaPersistencia.GetPersistenciaCadete().AltaCadete((Cadete)unUsuario);
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
            try
            {
                existe = FabricaPersistencia.GetPersistenciaAdministrador().ExisteAdmin(cedula);

                if (existe==false)
                    
                {
                  existe=FabricaPersistencia.GetPersistenciaCadete().ExisteCadete(cedula);
                }

                return existe;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados." + ex.Message);
            }
        }

        public static EntidadesCompartidasCore.Cadete SeleccionarCadete(int cedula)
        {
            EntidadesCompartidasCore.Cadete cadete = new EntidadesCompartidasCore.Cadete();
            return cadete;
        }

        public static bool ModificarUsuario(EntidadesCompartidasCore.Usuario unUsuario)
        {
            bool exito = false;
            if (unUsuario is Cliente)
            {
                exito = FabricaPersistencia.GetPersistenciaCliente().ModificarCliente((Cliente)unUsuario);
                return exito;
            }
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
            try
            {
                EntidadesCompartidasCore.Usuario usuario = LogicaUsuario.BuscarEmpleado(cedula);

                if (usuario is EntidadesCompartidasCore.Administrador)
                {
                    exito = FabricaPersistencia.GetPersistenciaAdministrador().BajaAdministrador(cedula);
                }
                if (usuario is EntidadesCompartidasCore.Cadete)
                {
                    exito = FabricaPersistencia.GetPersistenciaCadete().BajaCadete(cedula);
                }
                if (usuario is EntidadesCompartidasCore.Cliente)
                {
                    exito = FabricaPersistencia.GetPersistenciaCliente().BajaCliente(cedula);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al borrar el usuario." + ex.Message);
            }


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
            bool exito=false;
            try
            {
              
                    exito = FabricaPersistencia.GetPersistenciaAdministrador().ComprobarUser(user);
                
                    return exito;
             
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados." + ex.Message);
            }
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
