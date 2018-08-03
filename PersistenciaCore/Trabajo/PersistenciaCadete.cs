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
            try
            {
                PersistenciaCore.Usuarios usuNuevo = new PersistenciaCore.Usuarios();

                //usuNuevo.Id = cadete.Id;
                usuNuevo.Nombre = cadete.Nombre;
                usuNuevo.NombreUsuario = cadete.NombreUsuario;
                usuNuevo.Contraseña = cadete.Contraseña;
                usuNuevo.Direccion = cadete.Direccion;
                usuNuevo.Telefono = cadete.Telefono;
                usuNuevo.Email = cadete.Email;

                PersistenciaCore.Empleados empNuevo = new PersistenciaCore.Empleados();

               // empNuevo.IdUsuario = usuNuevo.Id;
                empNuevo.Sueldo = cadete.Sueldo;
                empNuevo.Ci = cadete.Ci;

                PersistenciaCore.Cadetes cadeteNuevo = new PersistenciaCore.Cadetes();

                cadeteNuevo.CiEmpleado = cadete.Ci;
                cadeteNuevo.IdTelefono = cadete.IdTelefono;
                cadeteNuevo.TipoLibreta = cadete.TipoLibreta;
 
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
                            context.Cadetes.Add(cadeteNuevo);


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
                throw new Exception("Error al dar de alta el cadete.");
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
            try
            {
                List<Cadetes> emp = new List<Cadetes>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var resultado = dbConnection.Cadetes.Select(c => new
                    {
                        Administrador = c,
                        Empleado = c.Empleados,
                        Usuario = c.Empleados.Usuarios
                    }).ToList();


                    List<Cadete> empresult = new List<Cadete>();

                    foreach (var a in resultado)
                    {
                        Cadete cad = new Cadete();

                        cad.Ci = a.Empleado.Ci;
                        cad.Contraseña = a.Usuario.Contraseña;
                        cad.Direccion = a.Usuario.Direccion;
                        cad.Email = a.Usuario.Email;
                        cad.Id = a.Usuario.Id;
                        cad.Nombre = a.Usuario.Nombre;
                        cad.NombreUsuario = a.Usuario.NombreUsuario;
                        cad.Sueldo = a.Empleado.Sueldo;
                        cad.Telefono = a.Usuario.Telefono;
                        cad.TipoLibreta = a.Empleado.Cadetes.TipoLibreta;
                        

                        empresult.Add(cad);
                    }

                    return empresult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los empleados." + ex.Message);
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
