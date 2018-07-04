using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaAdministrador:IPersistenciaAdministrador
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

                            context.Usuarios.Add(usuNuevo);
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
            return true;
        }

        public List<EntidadesCompartidasCore.Administrador> ListarAdministradores()
        {
            return new List<EntidadesCompartidasCore.Administrador>();
        }

        public bool ModificarAdmin(EntidadesCompartidasCore.Administrador admin)
        {
            return true;
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
            return true;
        }

        public EntidadesCompartidasCore.Administrador BusxarAdministrador(int ci)
        {
            return new EntidadesCompartidasCore.Administrador();
        }
    }
}
