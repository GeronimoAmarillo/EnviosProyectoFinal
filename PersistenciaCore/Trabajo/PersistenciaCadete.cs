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
            PersistenciaCore.Cadetes cadeteNuevo = new PersistenciaCore.Cadetes();

            cadeteNuevo.IdTelefono = cadete.IdTelefono;
            cadeteNuevo.TipoLibreta = cadete.TipoLibreta;
            cadeteNuevo.CiEmpleado = cadete.CiEmpleado;
           

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);


            using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
            {
                dbConnection.Cadetes.Add(cadeteNuevo);

                dbConnection.SaveChanges();

                return true;
            }
        }

        public bool ExisteCadete(int ci)
        {
            bool existe = false;


            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            using (var dbConnection = new EnviosContext(optionsBuilder.Options))
            {
                var cadete = dbConnection.Cadetes.Where(a => a.CiEmpleado == ci).Select(c => new {
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
            return new List<EntidadesCompartidasCore.Cadete>();
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
            return new List<EntidadesCompartidasCore.Cadete>();
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
            return new EntidadesCompartidasCore.Cadete();
        }
    }
}
