using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

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

                using (EnviosContext dbConnection = new EnviosContext(new DbContextOptions<EnviosContext>()))
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
            return true;
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
                

                using (EnviosContext dbConnection = new EnviosContext())
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
                throw new Exception("Error al listar los locales.");
            }
        }
    }
}
