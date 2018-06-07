using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaAdministrador:IPersistenciaAdministrador
    {
        public bool ExisteAdmin(int ci)
        {
            try
            {

                EnviosContext dbConexion = new EnviosContext();

                var empleadoEncontrado = from Empleados in dbConexion.Cadetes
                                       where Empleados.CiEmpleado == ci 
                                       select Empleados;

                if (empleadoEncontrado != null)
                {
                    return true;
                }
               
                    return false;
                             
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el administrador.");
            }
        }

        public bool AltaAdministrador(Administrador administrador)
        {
            try
            {
                Administradores adminNuevo = new Administradores();
                adminNuevo.Id = administrador.Id;
                adminNuevo.NombreUsuario = administrador.NombreUsuario;
                adminNuevo.Sueldo = administrador.Sueldo;
                adminNuevo.Telefono = administrador.Telefono;
                adminNuevo.CiEmpleado = administrador.CiEmpleado;
                adminNuevo.Tipo = administrador.Tipo;
                adminNuevo.Contraseña = administrador.Contraseña;
                adminNuevo.Email = administrador.Email;
                adminNuevo.Direccion = administrador.Direccion;
      

                using (EnviosContext dbConnection = new EnviosContext())
                {
                    dbConnection.Administradores.Add(adminNuevo);
                    dbConnection.SaveChanges();
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

        public List<Administrador> ListarAdministradores()
        {
            return new List<Administrador>();
        }

        public bool ModificarAdmin(Administrador admin)
        {
            return true;
        }

        public Administrador Login(string user, string contraseña)
        {
            Administrador administradorResultado = new Administrador();

            EnviosContext dbConexion = new EnviosContext();
            try
            {

                var adminEncontrado = from admin in dbConexion.Administradores
                                       where admin.Empleados.Usuarios.NombreUsuario == user && admin.Empleados.Usuarios.Contraseña == contraseña
                                       select admin;

                foreach (Administradores a in adminEncontrado)
                {
                    administradorResultado.Contraseña = a.Empleados.Usuarios.Contraseña;
                    administradorResultado.Direccion = a.Empleados.Usuarios.Direccion;
                    administradorResultado.Email = a.Empleados.Usuarios.Email;
                    administradorResultado.Id = a.Empleados.Usuarios.Id;
                    administradorResultado.Ci = a.CiEmpleado;
                    administradorResultado.Nombre = a.Empleados.Usuarios.Nombre;
                    administradorResultado.NombreUsuario = a.Empleados.Usuarios.NombreUsuario;
                    administradorResultado.Sueldo = a.Empleados.Sueldo;
                    administradorResultado.Telefono = a.Empleados.Usuarios.Telefono;
                    administradorResultado.Tipo = a.Tipo;
                }

                return administradorResultado;
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

        public Administrador BusxarAdministrador(int ci)
        {
            return new Administrador();
        }
    }
}
