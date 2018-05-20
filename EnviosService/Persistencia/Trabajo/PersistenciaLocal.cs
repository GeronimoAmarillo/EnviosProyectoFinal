using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaLocal:IPersistenciaLocal
    {
        public bool AltaLocal(Locales local)
        {
            try
            {
                using (EnviosEntities dbConnection = new EnviosEntities())
                {
                    dbConnection.Locales.Add(local);

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

        public Locales BuscarLocal(string nombre)
        {
            return new Locales();
        }

        public bool ModificarLocal(Locales local)
        {
            return true;
        }

        public List<Locales> ListarLocales()
        {
            return new List<Locales>();
        }
    }
}
