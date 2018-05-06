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
        public bool AltaAuto(Automobiles automobiles)
        {
            return true;
        }

        public List<Automobiles> ListarAutos()
        {
            return new List<Automobiles>();
        }

        public bool BajaAuto(string matricula)
        {
            return true;
        }

        public bool ModificarAuto(Automobiles auto)
        {
            return true;
        }

        public Automobiles BuscarAuto(string matricula)
        {
            return new Automobiles();
        }

        public bool ExisteAuto(string matricula)
        {
            return true;
        }
    }
}
