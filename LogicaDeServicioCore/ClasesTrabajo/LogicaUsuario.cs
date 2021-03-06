﻿using System;
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

        private static EntidadesCompartidasAndroid.Usuario TransformarUserAAndroid(EntidadesCompartidasCore.Usuario userCore)
        {
            try
            {

                if (userCore is EntidadesCompartidasCore.Administrador)
                {
                    try
                    {
                        EntidadesCompartidasAndroid.Administrador adminR = new EntidadesCompartidasAndroid.Administrador();

                        adminR.Direccion = userCore.Direccion;
                        adminR.Email = userCore.Email;
                        adminR.Id = userCore.Id;
                        adminR.Tipo = ((EntidadesCompartidasCore.Administrador)userCore).Tipo;
                        adminR.Nombre = userCore.Nombre;
                        adminR.NombreUsuario = userCore.NombreUsuario;
                        adminR.Telefono = userCore.Telefono;
                        adminR.Ci = ((EntidadesCompartidasCore.Administrador)userCore).Ci;
                        adminR.CiEmpleado = ((EntidadesCompartidasCore.Administrador)userCore).CiEmpleado;
                        adminR.Contraseña = userCore.Contraseña;

                        return adminR;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al transformar el administrador.");
                    }
                }
                else if (userCore is EntidadesCompartidasCore.Cadete)
                {
                    try
                    {
                        EntidadesCompartidasAndroid.Cadete adminR = new EntidadesCompartidasAndroid.Cadete();

                        adminR.Direccion = userCore.Direccion;
                        adminR.Email = userCore.Email;
                        adminR.Id = userCore.Id;
                        adminR.TipoLibreta = ((EntidadesCompartidasCore.Cadete)userCore).TipoLibreta;
                        adminR.Nombre = userCore.Nombre;
                        adminR.NombreUsuario = userCore.NombreUsuario;
                        adminR.Telefono = userCore.Telefono;
                        adminR.Ci = ((EntidadesCompartidasCore.Cadete)userCore).Ci;
                        adminR.CiEmpleado = ((EntidadesCompartidasCore.Cadete)userCore).CiEmpleado;
                        adminR.Contraseña = userCore.Contraseña;

                        return adminR;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al transformar el cadete.");
                    }
                }
                else if (userCore is EntidadesCompartidasCore.Cliente)
                {
                    try
                    {
                        EntidadesCompartidasAndroid.Cliente adminR = new EntidadesCompartidasAndroid.Cliente();

                        adminR.Direccion = userCore.Direccion;
                        adminR.Email = userCore.Email;
                        adminR.Id = userCore.Id;
                        adminR.Mensualidad = ((EntidadesCompartidasCore.Cliente)userCore).Mensualidad;
                        adminR.Nombre = userCore.Nombre;
                        adminR.NombreUsuario = userCore.NombreUsuario;
                        adminR.Telefono = userCore.Telefono;
                        adminR.RUT = ((EntidadesCompartidasCore.Cliente)userCore).RUT;
                        adminR.Contraseña = userCore.Contraseña;

                        return adminR;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al transformar el cliente.");
                    }
                }
                else
                {
                    return new EntidadesCompartidasAndroid.Usuario();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
        }


        public static bool VerificarCodigoContraseña(string email, string codigo)
        {
            try
            {
                bool correcto = false;

                correcto = FabricaPersistencia.GetPersistenciaCliente().VerificarCodigoContraseña(email, codigo);

                return correcto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static EntidadesCompartidasAndroid.Usuario LoginDroid(string user, string pass)
        {
            EntidadesCompartidasAndroid.Usuario usuarioLogueado = new EntidadesCompartidasAndroid.Usuario();
            EntidadesCompartidasCore.Usuario userCore = new EntidadesCompartidasCore.Usuario();

            try
            {
                userCore = Login(user, pass);

                usuarioLogueado = TransformarUserAAndroid(userCore);

                return usuarioLogueado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al loguear el Usuario" + ex.Message);
            }
        }

        public static Geolocalizacion ConsultarLocalizacion(int numReferencia, int rut)
        {
            try
            {
                Geolocalizacion geo = new Geolocalizacion();
                geo.Cadete = FabricaPersistencia.GetPersistenciaCadete().ConsultarLocalizacion(numReferencia);
                geo.Paquete = FabricaPersistencia.GetPersistenciaPaquete().BuscarPaqueteIndividual(numReferencia, rut);

                return geo;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool VerificarCodigoEmail(string email, string codigo)
        {
            try
            {
                bool correcto = false;

                correcto = FabricaPersistencia.GetPersistenciaCliente().VerificarCodigoEmail(email, codigo);

                return correcto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


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

        public static bool SetearCodigoRecuperarContraseña(Usuario unUsuario)
        {
            bool exito = false;

            try
            {
                if (unUsuario is Cliente)
                {
                    if (ExisteCliente(((Cliente)unUsuario).RUT))
                    {
                        if (unUsuario.CodigoRecuperacionContraseña == null || unUsuario.CodigoRecuperacionContraseña.Length == 0)
                        {
                            unUsuario.CodigoRecuperacionContraseña = GenerarCodigo();
                        }
                        else
                        {
                            unUsuario.CodigoRecuperacionContraseña = null;
                        }

                        exito = FabricaPersistencia.GetPersistenciaCliente().SetearCodigoRecuperacionContraseña((Cliente)unUsuario);
                        return exito;
                    }

                }
                if (unUsuario is Administrador)
                {
                    if (ExisteEmpleado(((Administrador)unUsuario).Ci))
                    {
                        if (unUsuario.CodigoRecuperacionContraseña == null)
                        {
                            unUsuario.CodigoRecuperacionContraseña = GenerarCodigo();
                        }

                        exito = FabricaPersistencia.GetPersistenciaAdministrador().SetearCodigoRecuperacionContraseña((Administrador)unUsuario);
                        return exito;
                    }

                }
                if (unUsuario is Cadete)
                {
                    if (ExisteEmpleado(((Cadete)unUsuario).Ci))
                    {
                        if (unUsuario.CodigoRecuperacionContraseña == null)
                        {
                            unUsuario.CodigoRecuperacionContraseña = GenerarCodigo();
                        }

                        exito = FabricaPersistencia.GetPersistenciaCadete().SetearCodigoRecuperacionContraseña((Cadete)unUsuario);
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


        public static bool SetearCodigoModificarEmail(Usuario unUsuario)
        {
            bool exito = false;

            try
            {
                if (unUsuario is Cliente)
                {
                    if (ExisteCliente(((Cliente)unUsuario).RUT))
                    {
                        if (unUsuario.CodigoModificarEmail == null || unUsuario.CodigoModificarEmail.Length == 0)
                        {
                            unUsuario.CodigoModificarEmail = GenerarCodigo();
                        }
                        else
                        {
                            unUsuario.CodigoModificarEmail = null;
                        }

                        exito = FabricaPersistencia.GetPersistenciaCliente().SetearCodigoModificarEmail((Cliente)unUsuario);
                        return exito;
                    }

                }
                if (unUsuario is Administrador)
                {
                    if (ExisteEmpleado(((Administrador)unUsuario).Ci))
                    {
                        if (unUsuario.CodigoModificarEmail == null)
                        {
                            unUsuario.CodigoModificarEmail = GenerarCodigo();
                        }

                        exito = FabricaPersistencia.GetPersistenciaAdministrador().SetearCodigoModificarEmail((Administrador)unUsuario);
                        return exito;
                    }

                }
                if (unUsuario is Cadete)
                {
                    if (ExisteEmpleado(((Cadete)unUsuario).Ci))
                    {
                        if (unUsuario.CodigoModificarEmail == null)
                        {
                            unUsuario.CodigoModificarEmail = GenerarCodigo();
                        }

                        exito = FabricaPersistencia.GetPersistenciaCadete().SetearCodigoModificarEmail((Cadete)unUsuario);
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
            try
            {
                return FabricaPersistencia.GetPersistenciaCliente().ExisteCliente(rut);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del cliente con los datos ingresados." + ex.Message);
            }
        }

        public static bool ExisteClienteXEmail(string email)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaCliente().ExisteClienteXEmail(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Cliente" + ex.Message);
            }
        }

        public static bool ExisteEmpleado(int cedula)
        {
            bool existe = false;
            try
            {
                existe = FabricaPersistencia.GetPersistenciaAdministrador().ExisteAdmin(cedula);

                if (existe == false)

                {
                    existe = FabricaPersistencia.GetPersistenciaCadete().ExisteCadete(cedula);
                }

                return existe;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del cliente con los datos ingresados." + ex.Message);
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
            try
            {
                if (unUsuario is Cliente)
                {
                    exito = FabricaPersistencia.GetPersistenciaCliente().ModificarCliente((Cliente)unUsuario);
                    return exito;
                }
                if (unUsuario is Administrador)
                {
                    exito = FabricaPersistencia.GetPersistenciaAdministrador().ModificarAdmin((Administrador)unUsuario);
                    return exito;
                }
                if (unUsuario is Cadete)
                {
                    exito = FabricaPersistencia.GetPersistenciaCadete().ModificarCadete((Cadete)unUsuario);
                    return exito;
                }
                return exito;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Usuario." + ex.Message);
            }

        }

        public static bool ModificarContrasenia(Usuario unUsuario)
        {
            try
            {
                if(unUsuario is Administrador)
                    return FabricaPersistencia.GetPersistenciaAdministrador().ModificarContrasenia((Administrador)unUsuario);
                else
                    return FabricaPersistencia.GetPersistenciaCliente().ModificarContrasenia((Cliente)unUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar la contraseña." + ex.Message);
            }
        }

        public static EntidadesCompartidasCore.Cliente BuscarCliente(int rut)
        {
            Cliente cliente;

            try
            {
                cliente = FabricaPersistencia.GetPersistenciaCliente().BuscarCliente(rut);

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Cliente" + ex.Message);
            }
        }

        public static EntidadesCompartidasCore.Cliente BuscarClienteXEmail(string email)
        {
            Cliente cliente;

            try
            {
                cliente = FabricaPersistencia.GetPersistenciaCliente().BuscarClienteXEmail(email);

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Cliente" + ex.Message);
            }
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
            try
            {
                List<EntidadesCompartidasCore.Cadete> lista = new List<EntidadesCompartidasCore.Cadete>();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los cadetes." + ex.Message);
            }
            
        }

        public static List<EntidadesCompartidasAndroid.Cadete> ListarCadetes()
        {

            try
            {
                List<Cadete> cadetesNormales = FabricaPersistencia.GetPersistenciaCadete().ListarCadetes();
                return TransformarCadetesAndroid(cadetesNormales);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los cadetes." + ex.Message);
            }

        }

        private static List<EntidadesCompartidasAndroid.Cadete> TransformarCadetesAndroid(List<Cadete> cadetesNormales)
        {
            try
            {
                List<EntidadesCompartidasAndroid.Cadete> cadetes = new List<EntidadesCompartidasAndroid.Cadete>();

                foreach (Cadete c in cadetesNormales)
                {
                    EntidadesCompartidasAndroid.Cadete cN = new EntidadesCompartidasAndroid.Cadete();

                    cN.Ci = c.Ci;
                    cN.CiEmpleado = c.CiEmpleado;
                    cN.Direccion = c.Direccion;
                    cN.Email = c.Email;
                    cN.Id = c.Id;
                    cN.Nombre = c.Nombre;
                    cN.NombreUsuario = c.NombreUsuario;
                    cN.Telefono = c.Telefono;
                    cN.TipoLibreta = c.TipoLibreta;
                    cN.Vehiculos = TransformarVehiculos(c.Vehiculos);

                    cadetes.Add(cN);
                }

                return cadetes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los Cadetes." + ex.Message);
            }
        }

        private static List<EntidadesCompartidasAndroid.Vehiculo> TransformarVehiculos(List<EntidadesCompartidasCore.Vehiculo> vehiculosP)
        {
            try
            {
                List<EntidadesCompartidasAndroid.Vehiculo> vehiculos = new List<EntidadesCompartidasAndroid.Vehiculo>();

                foreach (EntidadesCompartidasCore.Vehiculo c in vehiculosP)
                {

                    EntidadesCompartidasAndroid.Vehiculo cN = new EntidadesCompartidasAndroid.Vehiculo();

                    cN.Capacidad = c.Capacidad;
                    cN.Estado = c.Estado;
                    cN.Marca = c.Marca;
                    cN.Matricula = c.Matricula;
                    cN.Modelo = c.Modelo;

                    vehiculos.Add(cN);
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los Vehiculos." + ex.Message);
            }
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
                EntidadesCompartidasCore.Usuario usuario = LogicaUsuario.BuscarUsuario(cedula);

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
            catch (Exception ex)
            {
                throw new Exception("Error al loguear el Usuario" + ex.Message);
            }

        }

        public static bool ComprobarUser(string user)
        {
            bool exito = false;
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
        public static EntidadesCompartidasCore.Usuario BuscarUsuario(int cedula)
        {
            Empleado empleado;

            try
            {
                empleado = FabricaPersistencia.GetPersistenciaAdministrador().BuscarAdministrador(cedula);

                if (empleado.NombreUsuario == null)
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
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
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

        public static string GenerarCodigo()
        {
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int charNum = 1;
            while (charNum < 6)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
                charNum++;
            }
            return res.ToString();
        }
    }
}
