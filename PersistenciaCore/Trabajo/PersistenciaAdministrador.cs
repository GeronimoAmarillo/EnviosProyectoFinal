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
