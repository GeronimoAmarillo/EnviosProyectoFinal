﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaCadete:IPersistenciaCadete
    {
        public Cadete ConsultarLocalizacion(int numReferencia)
        {
            try
            {
                Cadetes cadete = new Cadetes();
                Entregas entrega = null;
                Paquetes paquete = null;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    entrega = dbConnection.Entregas.Include("Cadetes").FirstOrDefault(x => x.Paquetes.Any(y => y.NumReferencia == numReferencia) || x.Paquetes1.Any(y => y.NumReferencia == numReferencia));
                    
                    cadete = dbConnection.Cadetes.Include("Empleados.Usuarios").Where(x => x.CiEmpleado == entrega.Cadete).FirstOrDefault();
                }

                Cadete cadeteResultado = new Cadete();

                if (cadete != null)
                {

                    cadeteResultado.Ci = cadete.CiEmpleado;
                    cadeteResultado.CiEmpleado = cadete.CiEmpleado;
                    cadeteResultado.Email = cadete.Empleados.Usuarios.Email;
                    cadeteResultado.Id = cadete.Empleados.Usuarios.Id;
                    cadeteResultado.Nombre = cadete.Empleados.Usuarios.Nombre;
                    cadeteResultado.Telefono = cadete.Empleados.Usuarios.Telefono;
                    cadeteResultado.Latitud = cadete.Latitud;
                    cadeteResultado.Longitud = cadete.Longitud;
                }

                return cadeteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cadete." + ex.Message);
            }
        }

        public bool AltaCadete(EntidadesCompartidasCore.Cadete cadete)
        {
            try
            {
                
                PersistenciaCore.Cadetes cadeteNuevo = new PersistenciaCore.Cadetes();

                
                cadeteNuevo.CiEmpleado = cadete.Ci;
                cadeteNuevo.Latitud = cadete.Latitud;
                cadeteNuevo.Longitud = cadete.Longitud;
                cadeteNuevo.TipoLibreta = cadete.TipoLibreta;
                cadeteNuevo.Empleados = new Empleados();
                cadeteNuevo.Empleados.Sueldo = cadete.Sueldo;
                cadeteNuevo.Empleados.Ci = cadete.Ci;
                cadeteNuevo.Empleados.IdUsuario = cadete.IdUsuario;
                cadeteNuevo.Empleados.Usuarios = new Usuarios();
                cadeteNuevo.Empleados.Usuarios.Id = cadete.Id;
                cadeteNuevo.Empleados.Usuarios.Nombre = cadete.Nombre;
                cadeteNuevo.Empleados.Usuarios.NombreUsuario = cadete.NombreUsuario;
                cadeteNuevo.Empleados.Usuarios.Contraseña = cadete.Contraseña;
                cadeteNuevo.Empleados.Usuarios.Direccion = cadete.Direccion;
                cadeteNuevo.Empleados.Usuarios.Telefono = cadete.Telefono;
                cadeteNuevo.Empleados.Usuarios.Email = cadete.Email;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext context = new EnviosContext(optionsBuilder.Options))
                {
                    context.Cadetes.Add(cadeteNuevo);
                    context.SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el cadete.");
            }

        }

        public bool VerificarCodigoContraseña(string email, string codigo)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var cadeteEncontrado = dbConnection.Cadetes.Include("Empleados.Usuarios").Where(x => x.Empleados.Usuarios.Email == email && x.Empleados.Usuarios.CodigoRecuperacionContraseña == codigo).FirstOrDefault();

                    if (cadeteEncontrado != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool VerificarCodigoEmail(string email, string codigo)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var cadeteEncontrado = dbConnection.Cadetes.Include("Empleados.Usuarios").Where(x => x.Empleados.Usuarios.Email == email && x.Empleados.Usuarios.CodigoModificarEmail == codigo).FirstOrDefault();

                    if (cadeteEncontrado != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool SetearCodigoRecuperacionContraseña(Cadete cadete)
        {
            try

            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Cadetes cadeteDesdeBd = dbConnection.Cadetes.Include("Empleados.Usuarios").Where(x => x.CiEmpleado == cadete.Ci).FirstOrDefault();


                    if (cadeteDesdeBd != null)
                    {
                        cadeteDesdeBd.Empleados.Usuarios.CodigoRecuperacionContraseña = cadete.CodigoRecuperacionContraseña;

                        dbConnection.Cadetes.Update(cadeteDesdeBd);

                        dbConnection.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Cadete" + ex.Message);
            }
        }

        public bool SetearCodigoModificarEmail(Cadete cadete)
        {
            try

            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Cadetes cadeteDesdeBd = dbConnection.Cadetes.Include("Empleados.Usuarios").Where(x => x.CiEmpleado == cadete.Ci).FirstOrDefault();


                    if (cadeteDesdeBd != null)
                    {
                        cadeteDesdeBd.Empleados.Usuarios.CodigoModificarEmail = cadete.CodigoModificarEmail;

                        dbConnection.Cadetes.Update(cadeteDesdeBd);

                        dbConnection.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Cadete" + ex.Message);
            }
        }

        public bool ExisteCadete(int ci)
        {
            bool existe = false;


            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            using (var dbConnection = new EnviosContext(optionsBuilder.Options))
            {
                var cadete = dbConnection.Cadetes.Where(a => a.CiEmpleado == ci).Select(c => new
                {
                    Cadete = c
                }).FirstOrDefault();

                if (cadete != null && cadete.Cadete is Cadetes)
                {
                    existe = true;
                }
            }

            return existe;

        }

        public List<EntidadesCompartidasCore.Cadete> ListarCadetes()
        {
            try
            {
                List<Cadetes> cadetes = new List<Cadetes>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    cadetes = dbConnection.Cadetes.Include("Empleados.Usuarios").Include("Vehiculos").ToList();
                }

                List<Cadete> cadetesResultado = new List<Cadete>();

                foreach (Cadetes a in cadetes)
                {
                    Cadete cadeteR = new Cadete();

                    cadeteR.Ci = a.CiEmpleado;
                    cadeteR.CiEmpleado = a.CiEmpleado;
                    cadeteR.Direccion = a.Empleados.Usuarios.Direccion;
                    cadeteR.Email = a.Empleados.Usuarios.Email;
                    cadeteR.Id = a.Empleados.Usuarios.Id;
                    cadeteR.Nombre = a.Empleados.Usuarios.Nombre;
                    cadeteR.NombreUsuario = a.Empleados.Usuarios.NombreUsuario;
                    cadeteR.Sueldo = a.Empleados.Sueldo;
                    cadeteR.Telefono = a.Empleados.Usuarios.Telefono;
                    cadeteR.Latitud = a.Latitud;
                    cadeteR.Longitud = a.Longitud;
                    cadeteR.TipoLibreta = a.TipoLibreta;
                    cadeteR.CodigoRecuperacionContraseña = a.Empleados.Usuarios.CodigoRecuperacionContraseña;
                    cadeteR.CodigoModificarEmail = a.Empleados.Usuarios.CodigoModificarEmail;
                    cadeteR.Contraseña = a.Empleados.Usuarios.Contraseña;
                    cadeteR.Vehiculos = TransformarVehiculos(a.Vehiculos);

                    cadetesResultado.Add(cadeteR);
                }

                return cadetesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los cadetes." + ex.Message);
            }
        }

        private List<Vehiculo> TransformarVehiculos(ICollection<Vehiculos> vehiculosP)
        {
            try
            {
                List<Vehiculo> vehiculos = new List<Vehiculo>();

                foreach (Vehiculos c in vehiculosP)
                {
                    
                    Vehiculo cN = new Vehiculo();

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

        public EntidadesCompartidasCore.Cadete Login(string user, string contraseña)
        {
            Cadete cadeteResultado = null;

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    var cadeteEncontrado = dbConnection.Cadetes.Where(c => c.Empleados.Usuarios.NombreUsuario == user && c.Empleados.Usuarios.Contraseña == contraseña).Select(c => new
                    {
                        Cadete = c,
                        Empleado = c.Empleados,
                        Usuario = c.Empleados.Usuarios
                    }).FirstOrDefault();

                    if (cadeteEncontrado != null)
                    {
                        if (cadeteEncontrado.Usuario != null && cadeteEncontrado.Empleado != null && cadeteEncontrado.Cadete != null)
                        {
                            cadeteResultado = new Cadete();

                            cadeteResultado.Contraseña = cadeteEncontrado.Usuario.Contraseña;
                            cadeteResultado.Direccion = cadeteEncontrado.Usuario.Direccion;
                            cadeteResultado.Email = cadeteEncontrado.Usuario.Email;
                            cadeteResultado.Id = cadeteEncontrado.Usuario.Id;
                            cadeteResultado.Ci = cadeteEncontrado.Cadete.CiEmpleado;
                            cadeteResultado.Nombre = cadeteEncontrado.Usuario.Nombre;
                            cadeteResultado.NombreUsuario = cadeteEncontrado.Usuario.NombreUsuario;
                            cadeteResultado.Sueldo = cadeteEncontrado.Empleado.Sueldo;
                            cadeteResultado.Telefono = cadeteEncontrado.Usuario.Telefono;
                            cadeteResultado.TipoLibreta = cadeteEncontrado.Cadete.TipoLibreta;
                            cadeteResultado.CodigoRecuperacionContraseña = cadeteEncontrado.Cadete.Empleados.Usuarios.CodigoRecuperacionContraseña;
                            cadeteResultado.CodigoModificarEmail = cadeteEncontrado.Cadete.Empleados.Usuarios.CodigoModificarEmail;
                        }


                        //Tal vez corresponde tambien asignarle el vehiculo, esto va a necesitar de un cambio en el script de la base de datos, debido a que el 
                        //cadete de momento puede tener varios vehiculos, y me parece que eso no representa la realidad, no lo recuerdo.
                    }

                    return cadeteResultado;
                }

                    
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar loguear el Cadete" + ex.Message);
            }


        }

        public bool ModificarCadete(EntidadesCompartidasCore.Cadete cadete)
        {
            try
            {
                PersistenciaCore.Usuarios usuNuevo = new PersistenciaCore.Usuarios();

                usuNuevo.Id = cadete.Id;
                usuNuevo.Nombre = cadete.Nombre;
                usuNuevo.NombreUsuario = cadete.NombreUsuario;
                usuNuevo.Contraseña = cadete.Contraseña;
                usuNuevo.Direccion = cadete.Direccion;
                usuNuevo.Telefono = cadete.Telefono;
                usuNuevo.Email = cadete.Email;

                PersistenciaCore.Empleados empNuevo = new PersistenciaCore.Empleados();

                empNuevo.IdUsuario = usuNuevo.Id;
                empNuevo.Sueldo = cadete.Sueldo;
                empNuevo.Ci = cadete.Ci;

                PersistenciaCore.Cadetes cadeteNuevo = new PersistenciaCore.Cadetes();

                cadeteNuevo.CiEmpleado = cadete.Ci;
                cadeteNuevo.Latitud = cadete.Latitud;
                cadeteNuevo.Longitud = cadete.Longitud;
                cadeteNuevo.TipoLibreta = cadete.TipoLibreta;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext context = new EnviosContext(optionsBuilder.Options))
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            context.Usuarios.Update(usuNuevo);
                            context.Empleados.Update(empNuevo);
                            context.Cadetes.Update(cadeteNuevo);


                            context.SaveChanges();

                            dbContextTransaction.Commit();

                            return true;

                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return false;
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el cadete.");
            }

        }

        public List<EntidadesCompartidasCore.Cadete> ListarCadetesDisponibles()
        {
            try
            {
                List<Cadetes> cadetes = new List<Cadetes>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    cadetes = dbConnection.Cadetes.Include("Empleados.Usuarios").Include("Vehiculos").Where(c => c.Vehiculos == null || !(c.Vehiculos.Any())).ToList();
                }

                List<Cadete> cadetesResultado = new List<Cadete>();

                foreach (Cadetes l in cadetes)
                {
                    Cadete cadeteR = new Cadete();

                    cadeteR.Id = l.Empleados.Usuarios.Id;
                    cadeteR.Nombre = l.Empleados.Usuarios.Nombre;
                    cadeteR.Direccion = l.Empleados.Usuarios.Direccion;
                    cadeteR.Ci = l.Empleados.Ci;
                    cadeteR.Contraseña = l.Empleados.Usuarios.Contraseña;
                    cadeteR.Email = l.Empleados.Usuarios.Email;
                    cadeteR.Latitud = l.Latitud;
                    cadeteR.Longitud = l.Longitud;
                    cadeteR.NombreUsuario = l.Empleados.Usuarios.NombreUsuario;
                    cadeteR.Sueldo = l.Empleados.Sueldo;
                    cadeteR.Telefono = l.Empleados.Usuarios.Telefono;
                    cadeteR.TipoLibreta = l.TipoLibreta;
                    cadeteR.CodigoRecuperacionContraseña = l.Empleados.Usuarios.CodigoRecuperacionContraseña;
                    cadeteR.CodigoModificarEmail = l.Empleados.Usuarios.CodigoModificarEmail;

                    cadetesResultado.Add(cadeteR);
                }

                return cadetesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los cadetes disponibles." + ex.Message);
            }
        }
        

        public bool BajaCadete(int ci)
        {
            try
            {
                EntidadesCompartidasCore.Cadete cadete = FabricaPersistencia.GetPersistenciaCadete().BuscarCadete(ci);
                PersistenciaCore.Usuarios usuNuevo = new PersistenciaCore.Usuarios();

                usuNuevo.Id = cadete.Id;
                usuNuevo.Nombre = cadete.Nombre;
                usuNuevo.NombreUsuario = cadete.NombreUsuario;
                usuNuevo.Contraseña = cadete.Contraseña;
                usuNuevo.Direccion = cadete.Direccion;
                usuNuevo.Telefono = cadete.Telefono;
                usuNuevo.Email = cadete.Email;

                PersistenciaCore.Empleados empNuevo = new PersistenciaCore.Empleados();

                empNuevo.IdUsuario = usuNuevo.Id;
                empNuevo.Sueldo = cadete.Sueldo;
                empNuevo.Ci = cadete.Ci;

                PersistenciaCore.Cadetes cadNuevo = new PersistenciaCore.Cadetes();

                cadNuevo.CiEmpleado = cadete.Ci;
                cadNuevo.TipoLibreta = cadete.TipoLibreta;
                cadNuevo.Latitud = cadete.Latitud;
                cadNuevo.Longitud = cadete.Longitud;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext context = new EnviosContext(optionsBuilder.Options))
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            context.Cadetes.Remove(cadNuevo);
                            context.Empleados.Remove(empNuevo);
                            context.Usuarios.Remove(usuNuevo);


                            context.SaveChanges();

                            dbContextTransaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el cadete");
            }

        }
    public bool ComprobarUser(string user)
        {
            return true;
        }

        public EntidadesCompartidasCore.Cadete BuscarCadete(int ci)
        {
            try
            {
                Cadetes cadete = new Cadetes();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    cadete = dbConnection.Cadetes.Include("Empleados.Usuarios").Where(c => c.CiEmpleado == ci).FirstOrDefault();
                }

                Cadete cadeteResultado = new Cadete();

                if (cadete != null)
                {

                    cadeteResultado.Ci = cadete.CiEmpleado;
                    cadeteResultado.CiEmpleado = cadete.CiEmpleado;
                    cadeteResultado.Direccion = cadete.Empleados.Usuarios.Direccion;
                    cadeteResultado.Email = cadete.Empleados.Usuarios.Email;
                    cadeteResultado.Id = cadete.Empleados.Usuarios.Id;
                    cadeteResultado.Nombre = cadete.Empleados.Usuarios.Nombre;
                    cadeteResultado.NombreUsuario = cadete.Empleados.Usuarios.NombreUsuario;
                    cadeteResultado.Sueldo = cadete.Empleados.Sueldo;
                    cadeteResultado.Telefono = cadete.Empleados.Usuarios.Telefono;
                    cadeteResultado.Latitud = cadete.Latitud;
                    cadeteResultado.Longitud = cadete.Longitud;
                    cadeteResultado.CodigoRecuperacionContraseña = cadete.Empleados.Usuarios.CodigoRecuperacionContraseña;
                    cadeteResultado.CodigoModificarEmail = cadete.Empleados.Usuarios.CodigoModificarEmail;
                }

                return cadeteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cadete." + ex.Message);
            }

        }
    
    }
}
