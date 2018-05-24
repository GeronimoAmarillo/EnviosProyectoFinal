using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
namespace Persistencia
{
    class PersistenciaAuto:IPersistenciaAuto
    {
        public bool AltaAuto(EntidadesCompartidas.Automobiles automobiles)
        {
            return true;
        }

        public List<EntidadesCompartidas.Automobiles> ListarAutos()
        {
            return new List<EntidadesCompartidas.Automobiles>();
        }

        public bool BajaAuto(string matricula)
        {
            return true;
        }

        public bool ModificarAuto(EntidadesCompartidas.Automobiles auto)
        {
            return true;
        }

        public EntidadesCompartidas.Automobiles BuscarAuto(string matricula)
        {
            return new EntidadesCompartidas.Automobiles();
        }

        public bool ExisteAuto(string matricula)
        {
            return true;
        }
    }
}
