using System;
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
        public bool AltaCadete(EntidadesCompartidasCore.Cadete cadete)
        {
            return true;
        }

        public bool ExisteCadete(int ci)
        {
            return true;
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
                    cadetes = dbConnection.Cadetes.Include("Empleados.Usuarios").ToList();
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
                    cadeteR.IdTelefono = a.IdTelefono;

                    cadetesResultado.Add(cadeteR);
                }

                return cadetesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los cadetes." + ex.Message);
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

                    var cadeteEncontrado = dbConnection.Cadetes.Where(c => c.Empleados.Usuarios.NombreUsuario == user && c.Empleados.Usuarios.Contraseña == contraseña).Select(c => new {
                        Cadete = c,
                        Empleado = c.Empleados,
                        Usuario = c.Empleados.Usuarios }).FirstOrDefault();

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
            return true;
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
                    cadeteR.IdTelefono = l.IdTelefono;
                    cadeteR.NombreUsuario = l.Empleados.Usuarios.NombreUsuario;
                    cadeteR.Sueldo = l.Empleados.Sueldo;
                    cadeteR.Telefono = l.Empleados.Usuarios.Telefono;
                    cadeteR.TipoLibreta = l.TipoLibreta;

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
            return true;
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

                if(cadete != null)
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
                    cadeteResultado.IdTelefono = cadete.IdTelefono;
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
