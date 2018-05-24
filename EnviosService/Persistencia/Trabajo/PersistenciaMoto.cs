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
        public bool AltaMoto(EntidadesCompartidas.Motos moto)
        {
            return true;
        }

        public bool ExisteMoto(string matricula)
        {
            return true;
        }

        public EntidadesCompartidas.Motos BuscarMoto(string matricula)
        {
            return new EntidadesCompartidas.Motos();
        }

        public List<EntidadesCompartidas.Motos> ListarMotos()
        {
            return new List<EntidadesCompartidas.Motos>();
        }

        public bool BajaMoto(string matricula)
        {
            return true;
        }

        public bool ModificarMoto(EntidadesCompartidas.Motos moto)
        {
            return true;
        }
    }
}
