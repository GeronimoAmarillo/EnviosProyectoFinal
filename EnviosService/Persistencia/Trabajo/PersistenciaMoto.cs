using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
namespace Persistencia
{
    class PersistenciaMoto:IPersistenciaMoto
    {
        public bool AltaMoto(EntidadesCompartidas.Moto moto)
        {
            return true;
        }

        public bool ExisteMoto(string matricula)
        {
            return true;
        }

        public EntidadesCompartidas.Moto BuscarMoto(string matricula)
        {
            return new EntidadesCompartidas.Moto();
        }

        public List<EntidadesCompartidas.Moto> ListarMotos()
        {
            return new List<EntidadesCompartidas.Moto>();
        }

        public bool BajaMoto(string matricula)
        {
            return true;
        }

        public bool ModificarMoto(EntidadesCompartidas.Moto moto)
        {
            return true;
        }
    }
}
