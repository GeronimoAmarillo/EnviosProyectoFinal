using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaCamion:IPersistenciaCamion
    {
        public bool AltaCamion(Camiones camion)
        {
            return true;
        }

        public List<Camiones> ListarCamiones()
        {
            return new List<Camiones>();
        }

        public bool BajaCamion(string matricula)
        {
            return true;
        }

        public Camiones BuscarCamion(string matricula)
        {
            return new Camiones();
        }

        public bool ModificarCamion(Camiones camion)
        {
            return true;
        }

        public bool ExisteCamion(string matricula)
        {
            return true;
        }
    }
}
