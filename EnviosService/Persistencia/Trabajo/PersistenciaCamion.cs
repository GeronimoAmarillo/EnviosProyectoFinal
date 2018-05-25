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
        public bool AltaCamion(EntidadesCompartidas.Camion camion)
        {
            return true;
        }

        public List<EntidadesCompartidas.Camion> ListarCamiones()
        {
            return new List<EntidadesCompartidas.Camion>();
        }

        public bool BajaCamion(string matricula)
        {
            return true;
        }

        public EntidadesCompartidas.Camion BuscarCamion(string matricula)
        {
            return new EntidadesCompartidas.Camion();
        }

        public bool ModificarCamion(EntidadesCompartidas.Camion camion)
        {
            return true;
        }

        public bool ExisteCamion(string matricula)
        {
            return true;
        }
    }
}
