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
                    var admin = dbConnection.Administradores.Where(a => a.CiEmpleado == ci).Select(c => new
                    {
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

        public bool VerificarCodigoContraseña(string email, string codigo)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var adminEncontrado = dbConnection.Administradores.Include("Empleados.Usuarios").Where(x => x.Empleados.Usuarios.Email == email && x.Empleados.Usuarios.CodigoRecuperacionContraseña == codigo).FirstOrDefault();

                    if (adminEncontrado != null)
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
                    var adminEncontrado = dbConnection.Administradores.Include("Empleados.Usuarios").Where(x => x.Empleados.Usuarios.Email == email && x.Empleados.Usuarios.CodigoModificarEmail == codigo).FirstOrDefault();

                    if (adminEncontrado != null)
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

        public bool AltaAdministrador(EntidadesCompartidasCore.Administrador administrador)
        {
            try
            {
                PersistenciaCore.Administradores adminNuevo = new PersistenciaCore.Administradores();
                
                adminNuevo.CiEmpleado = administrador.Ci;
                adminNuevo.Tipo = administrador.Tipo;
                adminNuevo.Empleados = new Empleados();
                adminNuevo.Empleados.Sueldo = administrador.Sueldo;
                adminNuevo.Empleados.Ci = administrador.Ci;
                adminNuevo.Empleados.IdUsuario = administrador.IdUsuario;
                adminNuevo.Empleados.Usuarios = new Usuarios();
                adminNuevo.Empleados.Usuarios.Id = administrador.Id;
                adminNuevo.Empleados.Usuarios.Nombre = administrador.Nombre;
                adminNuevo.Empleados.Usuarios.NombreUsuario = administrador.NombreUsuario;
                adminNuevo.Empleados.Usuarios.Contraseña = administrador.Contraseña;
                adminNuevo.Empleados.Usuarios.Direccion = administrador.Direccion;
                adminNuevo.Empleados.Usuarios.Telefono = administrador.Telefono;
                adminNuevo.Empleados.Usuarios.Email = administrador.Email;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext context = new EnviosContext(optionsBuilder.Options))
                {
                    context.Administradores.Add(adminNuevo);
                    context.SaveChanges();

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
                    var admin = dbConnection.Usuarios.Where(a => a.NombreUsuario == user).Select(c => new
                    {
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

        public EntidadesCompartidasCore.Administrador BuscarAdministrador(int ci)
        {
            try
            {
                Administradores administrador = new Administradores();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    administrador = dbConnection.Administradores.Include("Empleados.Usuarios").Where(a => a.CiEmpleado == ci).FirstOrDefault();
                }

                Administrador adminResultado = new Administrador();

                if (administrador != null)
                {

                    adminResultado.Ci = administrador.CiEmpleado;
                    adminResultado.CiEmpleado = administrador.CiEmpleado;
                    adminResultado.Direccion = administrador.Empleados.Usuarios.Direccion;
                    adminResultado.Email = administrador.Empleados.Usuarios.Email;
                    adminResultado.Id = administrador.Empleados.Usuarios.Id;
                    adminResultado.Nombre = administrador.Empleados.Usuarios.Nombre;
                    adminResultado.NombreUsuario = administrador.Empleados.Usuarios.NombreUsuario;
                    adminResultado.Sueldo = administrador.Empleados.Sueldo;
                    adminResultado.Telefono = administrador.Empleados.Usuarios.Telefono;
                    adminResultado.Tipo = administrador.Tipo;
                    adminResultado.CodigoRecuperacionContraseña = administrador.Empleados.Usuarios.CodigoRecuperacionContraseña;
                    adminResultado.CodigoModificarEmail = administrador.Empleados.Usuarios.CodigoModificarEmail;
                }

                return adminResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el administrador administradores." + ex.Message);
            }

        }



        public List<EntidadesCompartidasCore.Administrador> ListarAdministradores()
        {
            try
            {
                List<Administradores> administradores = new List<Administradores>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    administradores = dbConnection.Administradores.Include("Empleados.Usuarios").ToList();
                }

                List<Administrador> adminsResultado = new List<Administrador>();

                foreach (Administradores a in administradores)
                {
                    Administrador adminR = new Administrador();

                    adminR.Ci = a.CiEmpleado;
                    adminR.CiEmpleado = a.CiEmpleado;
                    adminR.Direccion = a.Empleados.Usuarios.Direccion;
                    adminR.Email = a.Empleados.Usuarios.Email;
                    adminR.Id = a.Empleados.Usuarios.Id;
                    adminR.Nombre = a.Empleados.Usuarios.Nombre;
                    adminR.NombreUsuario = a.Empleados.Usuarios.NombreUsuario;
                    adminR.Sueldo = a.Empleados.Sueldo;
                    adminR.Telefono = a.Empleados.Usuarios.Telefono;
                    adminR.Tipo = a.Tipo;
                    adminR.CodigoRecuperacionContraseña = a.Empleados.Usuarios.CodigoRecuperacionContraseña;
                    adminR.CodigoModificarEmail = a.Empleados.Usuarios.CodigoModificarEmail;

                    adminsResultado.Add(adminR);
                }

                return adminsResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los administradores." + ex.Message);
            }
        }

        public bool SetearCodigoRecuperacionContraseña(Administrador admin)
        {
            try

            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Administradores adminDesdeBd = dbConnection.Administradores.Include("Empleados.Usuarios").Where(x => x.CiEmpleado == admin.Ci).FirstOrDefault();


                    if (adminDesdeBd != null)
                    {
                        adminDesdeBd.Empleados.Usuarios.CodigoRecuperacionContraseña = admin.CodigoRecuperacionContraseña;

                        dbConnection.Administradores.Update(adminDesdeBd);

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
                throw new Exception("Error al intentar modificar el Administrador" + ex.Message);
            }
        }

        public bool SetearCodigoModificarEmail(Administrador admin)
        {
            try

            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Administradores adminDesdeBd = dbConnection.Administradores.Include("Empleados.Usuarios").Where(x => x.CiEmpleado == admin.Ci).FirstOrDefault();


                    if (adminDesdeBd != null)
                    {
                        adminDesdeBd.Empleados.Usuarios.CodigoModificarEmail = admin.CodigoModificarEmail;

                        dbConnection.Administradores.Update(adminDesdeBd);

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
                throw new Exception("Error al intentar modificar el Administrador" + ex.Message);
            }
        }

        public bool ModificarContrasenia(Administrador unAdmin)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();
        
            optionsBuilder.UseSqlServer(Conexion.ConnectionString);
            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Administradores usuDesdeBd = dbConnection.Administradores.Include("Usuarios").Where(x => x.CiEmpleado == unAdmin.Ci).FirstOrDefault();


                    if (usuDesdeBd != null)
                    {
                        usuDesdeBd.Empleados.Usuarios.Contraseña = unAdmin.Contraseña;
                        usuDesdeBd.Empleados.Usuarios.NombreUsuario = unAdmin.NombreUsuario;
                        dbConnection.Administradores.Update(usuDesdeBd);
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
                throw new Exception("Error al intentar modificar el Cliente" + ex.Message);
            }
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
                    var adminEncontrado = dbConnection.Administradores.Where(c => c.Empleados.Usuarios.NombreUsuario == user && c.Empleados.Usuarios.Contraseña == contraseña).Select(c => new
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
                EntidadesCompartidasCore.Administrador administrador = FabricaPersistencia.GetPersistenciaAdministrador().BuscarAdministrador(ci);
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
    }
}
