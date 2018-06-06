using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
namespace PersistenciaCore
{
    class PersistenciaMoto:IPersistenciaMoto
    {
        public bool AltaMoto(EntidadesCompartidasCore.Moto moto)
        {
            return true;
        }

        public bool ExisteMoto(string matricula)
        {
            return true;
        }

        public EntidadesCompartidasCore.Moto BuscarMoto(string matricula)
        {
            return new EntidadesCompartidasCore.Moto();
        }

        public List<EntidadesCompartidasCore.Moto> ListarMotos()
        {
            return new List<EntidadesCompartidasCore.Moto>();
        }

        public bool BajaMoto(string matricula)
        {
            return true;
        }

        public bool ModificarMoto(EntidadesCompartidasCore.Moto moto)
        {
            return true;
        }
    }
}
