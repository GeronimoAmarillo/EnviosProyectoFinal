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
            return true;
        }

        public bool AltaAdministrador(EntidadesCompartidasCore.Administrador administrador)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
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

                    adminsResultado.Add(adminR);
                }

                return adminsResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los administradores." + ex.Message);
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
                }

                return adminResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el administrador administradores." + ex.Message);
            }
        }
    }
}
