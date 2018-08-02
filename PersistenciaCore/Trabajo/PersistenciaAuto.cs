using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
namespace PersistenciaCore
{
    class PersistenciaAuto:IPersistenciaAuto
    {
        public bool AltaAuto(EntidadesCompartidasCore.Automobil automobiles)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Automobil> ListarAutos()
        {
            return new List<EntidadesCompartidasCore.Automobil>();
        }

        public bool BajaAuto(string matricula)
        {
            return true;
        }

        public bool ModificarAuto(EntidadesCompartidasCore.Automobil auto)
        {
            return true;
        }

        public EntidadesCompartidasCore.Automobil BuscarAuto(string matricula)
        {
            return new EntidadesCompartidasCore.Automobil();
        }

        public bool ExisteAuto(string matricula)
        {
            return true;
        }
    }
}
