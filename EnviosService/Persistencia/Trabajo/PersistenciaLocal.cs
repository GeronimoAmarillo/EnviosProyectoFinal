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
        public bool AltaLocal(EntidadesCompartidas.Locales local)
        {
            /*try
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
            }*/

            return true;
        }

        public bool ExisteLocal(string nombre, string direccion)
        {
            return true;
        }

        public EntidadesCompartidas.Locales BuscarLocal(string nombre)
        {
            return new EntidadesCompartidas.Locales();
        }

        public bool ModificarLocal(EntidadesCompartidas.Locales local)
        {
            return true;
        }

        public List<EntidadesCompartidas.Locales> ListarLocales()
        {
            return new List<EntidadesCompartidas.Locales>();
        }
    }
}
