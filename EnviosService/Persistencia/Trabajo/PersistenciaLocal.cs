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
        public bool AltaLocal(Local local)
        {
            try
            {
                Locales localAgregar = new Locales();

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

        public Local BuscarLocal(string nombre)
        {
            return new Local();
        }

        public bool ModificarLocal(Local local)
        {
            return true;
        }

        public List<EntidadesCompartidas.Local> ListarLocales()
        {
            return new List<Local>();
        }
    }
}
