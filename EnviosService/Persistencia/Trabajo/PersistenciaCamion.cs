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
        public bool AltaCamion(EntidadesCompartidas.Camiones camion)
        {
            return true;
        }

        public List<EntidadesCompartidas.Camiones> ListarCamiones()
        {
            return new List<EntidadesCompartidas.Camiones>();
        }

        public bool BajaCamion(string matricula)
        {
            return true;
        }

        public EntidadesCompartidas.Camiones BuscarCamion(string matricula)
        {
            return new EntidadesCompartidas.Camiones();
        }

        public bool ModificarCamion(EntidadesCompartidas.Camiones camion)
        {
            return true;
        }

        public bool ExisteCamion(string matricula)
        {
            return true;
        }
    }
}
