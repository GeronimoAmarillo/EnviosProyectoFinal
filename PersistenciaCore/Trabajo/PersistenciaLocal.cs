using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PersistenciaCore
{
    class PersistenciaLocal:IPersistenciaLocal
    {
        public bool AltaLocal(EntidadesCompartidasCore.Local local)
        {
            try
            {
                PersistenciaCore.Locales localAgregar = new PersistenciaCore.Locales();

                localAgregar.Direccion = local.Direccion;
                localAgregar.Nombre = local.Nombre;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Locales.Add(localAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el Local.");
            }
            
        }

        public bool ExisteLocal(string nombre, string direccion)
        {
            try
            {
                bool existe = false;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var local = dbConnection.Locales.Where(l => l.Direccion == direccion && l.Nombre == nombre).Select(c => new {
                        Local = c
                    }).FirstOrDefault();

                    if (local != null && local.Local is Locales)
                    {
                        existe = true;
                    }
                }

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los locales." + ex.Message);
            }
        }

        public EntidadesCompartidasCore.Local BuscarLocal(string nombre)
        {
            return new EntidadesCompartidasCore.Local();
        }

        public bool ModificarLocal(EntidadesCompartidasCore.Local local)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Local> ListarLocales()
        {
            try
            {
                List<Locales> locales = new List<Locales>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);
                
                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    locales = dbConnection.Locales.ToList();
                }

                List<Local> localesResultado = new List<Local>();

                foreach (Locales l in locales)
                {
                    Local localR = new Local();

                    localR.Id = l.Id;
                    localR.Nombre = l.Nombre;
                    localR.Direccion = l.Direccion;

                    localesResultado.Add(localR);
                }

                return localesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los locales." +  ex.Message);
            }
        }
    }
}
