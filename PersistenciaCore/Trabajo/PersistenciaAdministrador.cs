using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaAdministrador : IPersistenciaAdministrador
    {
        public bool ExisteAdmin(int ci)
        {
            try
            {

                bool existe = false;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var admin = dbConnection.Administradores.Where(a => a.CiEmpleado == ci).Select(c => new {
                        Admin = c
                    }).FirstOrDefault();

                    if (admin != null && admin.Admin is Administradores)
                    {
                        existe = true;
                    }
                }

                return existe;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el administrador.");
            }
        }

        public bool AltaAdministrador(EntidadesCompartidasCore.Administrador administrador)
        {
            try
            {
                PersistenciaCore.Usuarios usuNuevo = new PersistenciaCore.Usuarios();

                //usuNuevo.Id = administrador.Id;
                usuNuevo.Nombre = administrador.Nombre;
                usuNuevo.NombreUsuario = administrador.NombreUsuario;
                usuNuevo.Contraseña = administrador.Contraseña;
                usuNuevo.Direccion = administrador.Direccion;
                usuNuevo.Telefono = administrador.Telefono;
                usuNuevo.Email = administrador.Email;

                PersistenciaCore.Empleados empNuevo = new PersistenciaCore.Empleados();

                empNuevo.IdUsuario = usuNuevo.Id;
                empNuevo.Sueldo = administrador.Sueldo;
                empNuevo.Ci = administrador.Ci;

                PersistenciaCore.Administradores adminNuevo = new PersistenciaCore.Administradores();

                adminNuevo.CiEmpleado = administrador.Ci;
                adminNuevo.Tipo = administrador.Tipo;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext context = new EnviosContext(optionsBuilder.Options))
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            context.Usuarios.Add(usuNuevo);
                            context.SaveChanges();

                            var id = context.Usuarios.Where(u => u.NombreUsuario == usuNuevo.NombreUsuario).Select(c => new
                            {
                                id = c.Id
                            }).FirstOrDefault();
                            empNuevo.IdUsuario = id.id;
                            context.Empleados.Add(empNuevo);
                            context.Administradores.Add(adminNuevo);


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
                throw new Exception("Error al dar de alta el administrador");
            }


        }

        public bool ComprobarUser(string user)
        {
            try
            {

                bool existe = false;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var admin = dbConnection.Usuarios.Where(a => a.NombreUsuario == user).Select(c => new {
                        Admin = c
                    }).FirstOrDefault();

                    if (admin != null && admin.Admin is Usuarios)
                    {
                        existe = true;
                    }
                }

                return existe;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el administrador.");
            }
        }
        public List<EntidadesCompartidasCore.Administrador>ListarAdministradores()
        {
            try {
                List<Administradores> emp = new List<Administradores>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                   emp = dbConnection.Administradores.Include("Empleados.Usuarios").ToList();
                }


                List<Administrador> empresult = new List<Administrador>();

                    foreach (var a in emp)
                    {
                        Administrador empr = new Administrador();

                        empr.Ci = a.CiEmpleado;
                        empr.Contraseña = a.Empleados.Usuarios.Contraseña;
                        empr.Direccion = a.Empleados.Usuarios.Direccion;
                        empr.Email = a.Empleados.Usuarios.Email;
                        empr.Id = a.Empleados.IdUsuario;
                        empr.Nombre = a.Empleados.Usuarios.Nombre;
                        empr.NombreUsuario = a.Empleados.Usuarios.NombreUsuario;
                        empr.Sueldo = a.Empleados.Sueldo;
                        empr.Telefono = a.Empleados.Usuarios.Telefono;
                        empr.Tipo = a.Tipo;

                        empresult.Add(empr);
                    }

                    return empresult;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los Administradores." + ex.Message);
            }
          
        }
       


       public bool ModificarAdmin(EntidadesCompartidasCore.Administrador administrador)
        {
            try
            {
                PersistenciaCore.Usuarios usuNuevo = new PersistenciaCore.Usuarios();

                usuNuevo.Id = administrador.Id;
                usuNuevo.Nombre = administrador.Nombre;
                usuNuevo.NombreUsuario = administrador.NombreUsuario;
                usuNuevo.Contraseña = administrador.Contraseña;
                usuNuevo.Direccion = administrador.Direccion;
                usuNuevo.Telefono = administrador.Telefono;
                usuNuevo.Email = administrador.Email;

                PersistenciaCore.Empleados empNuevo = new PersistenciaCore.Empleados();

                empNuevo.IdUsuario = usuNuevo.Id;
                empNuevo.Sueldo = administrador.Sueldo;
                empNuevo.Ci = administrador.Ci;

                PersistenciaCore.Administradores adminNuevo = new PersistenciaCore.Administradores();

                adminNuevo.CiEmpleado = administrador.Ci;
                adminNuevo.Tipo = administrador.Tipo;

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
                            context.Administradores.Update(adminNuevo);


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
                throw new Exception("Error al modificar el administrador");
            }

        }

        public EntidadesCompartidasCore.Administrador Login(string user, string contraseña)
        {
            Administrador administradorResultado = null;

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var adminEncontrado = dbConnection.Administradores.Where(c => c.Empleados.Usuarios.NombreUsuario == user && c.Empleados.Usuarios.Contraseña == contraseña).Select(c => new {
                        Administrador = c,
                        Empleado = c.Empleados,
                        Usuario = c.Empleados.Usuarios
                    }).FirstOrDefault();

                    if (adminEncontrado !=  null)
                    {
                        if (adminEncontrado.Usuario != null && adminEncontrado.Empleado != null && adminEncontrado.Administrador != null)
                        {
                            administradorResultado = new Administrador();

                            administradorResultado.Contraseña = adminEncontrado.Usuario.Contraseña;
                            administradorResultado.Direccion = adminEncontrado.Usuario.Direccion;
                            administradorResultado.Email = adminEncontrado.Usuario.Email;
                            administradorResultado.Id = adminEncontrado.Usuario.Id;
                            administradorResultado.Ci = adminEncontrado.Empleado.Ci;
                            administradorResultado.Nombre = adminEncontrado.Usuario.Nombre;
                            administradorResultado.NombreUsuario = adminEncontrado.Usuario.NombreUsuario;
                            administradorResultado.Sueldo = adminEncontrado.Empleado.Sueldo;
                            administradorResultado.Telefono = adminEncontrado.Usuario.Telefono;
                            administradorResultado.Tipo = adminEncontrado.Administrador.Tipo;
                        }
                        
                    }

                    return administradorResultado;
                }

                    
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar loguear el Cadete" + ex.Message);
            }
        }

        public bool BajaAdministrador(int ci)
        {
            try
            {
                EntidadesCompartidasCore.Administrador administrador = FabricaPersistencia.GetPersistenciaAdministrador().BusxarAdministrador(ci);
                PersistenciaCore.Usuarios usuNuevo = new PersistenciaCore.Usuarios();

                usuNuevo.Id = administrador.Id;
                usuNuevo.Nombre = administrador.Nombre;
                usuNuevo.NombreUsuario = administrador.NombreUsuario;
                usuNuevo.Contraseña = administrador.Contraseña;
                usuNuevo.Direccion = administrador.Direccion;
                usuNuevo.Telefono = administrador.Telefono;
                usuNuevo.Email = administrador.Email;

                PersistenciaCore.Empleados empNuevo = new PersistenciaCore.Empleados();

                empNuevo.IdUsuario = usuNuevo.Id;
                empNuevo.Sueldo = administrador.Sueldo;
                empNuevo.Ci = administrador.Ci;

                PersistenciaCore.Administradores adminNuevo = new PersistenciaCore.Administradores();

                adminNuevo.CiEmpleado = administrador.Ci;
                adminNuevo.Tipo = administrador.Tipo;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext context = new EnviosContext(optionsBuilder.Options))
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            context.Administradores.Remove(adminNuevo);
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
                throw new Exception("Error al dar de baja el administrador");
            }

        }

        public EntidadesCompartidasCore.Administrador BusxarAdministrador(int Id)
        {
            Administrador administradorResultado = null;

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var adminEncontrado = dbConnection.Administradores.Where(c => c.Empleados.IdUsuario == Id).Select(c => new
                    {
                        Administrador = c,
                        Empleado = c.Empleados,
                        Usuario = c.Empleados.Usuarios
                    }).FirstOrDefault();

                    if (adminEncontrado != null)
                    {
                        if (adminEncontrado.Usuario != null && adminEncontrado.Empleado != null && adminEncontrado.Administrador != null)
                        {
                            administradorResultado = new Administrador();

                            administradorResultado.Contraseña = adminEncontrado.Usuario.Contraseña;
                            administradorResultado.Direccion = adminEncontrado.Usuario.Direccion;
                            administradorResultado.Email = adminEncontrado.Usuario.Email;
                            administradorResultado.Id = adminEncontrado.Usuario.Id;
                            administradorResultado.Ci = adminEncontrado.Empleado.Ci;
                            administradorResultado.Nombre = adminEncontrado.Usuario.Nombre;
                            administradorResultado.NombreUsuario = adminEncontrado.Usuario.NombreUsuario;
                            administradorResultado.Sueldo = adminEncontrado.Empleado.Sueldo;
                            administradorResultado.Telefono = adminEncontrado.Usuario.Telefono;
                            administradorResultado.Tipo = adminEncontrado.Administrador.Tipo;
                        }

                    }
                }
                return administradorResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar buscar el Administrador" + ex.Message);
            }
        }
    }

}
