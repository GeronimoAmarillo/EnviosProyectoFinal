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
            try
            {

                Persistencia.Locales localAgregar = new Persistencia.Locales();

                localAgregar.Direccion = local.Direccion;
                localAgregar.Nombre = local.Nombre;

                using (EnviosContext dbConnection = new EnviosContext())
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
