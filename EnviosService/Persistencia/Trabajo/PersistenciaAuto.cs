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
        public bool AltaAuto(EntidadesCompartidas.Automobil automobiles)
        {
            return true;
        }

        public List<EntidadesCompartidas.Automobil> ListarAutos()
        {
            return new List<EntidadesCompartidas.Automobil>();
        }

        public bool BajaAuto(string matricula)
        {
            return true;
        }

        public bool ModificarAuto(EntidadesCompartidas.Automobil auto)
        {
            return true;
        }

        public EntidadesCompartidas.Automobil BuscarAuto(string matricula)
        {
            return new EntidadesCompartidas.Automobil();
        }

        public bool ExisteAuto(string matricula)
        {
            return true;
        }
    }
}
