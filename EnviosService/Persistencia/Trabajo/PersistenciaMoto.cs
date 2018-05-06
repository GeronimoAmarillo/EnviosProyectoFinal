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
        public bool AltaMoto(Motos moto)
        {
            return true;
        }

        public bool ExisteMoto(string matricula)
        {
            return true;
        }

        public Motos BuscarMoto(string matricula)
        {
            return new Motos();
        }

        public List<Motos> ListarMotos()
        {
            return new List<Motos>();
        }

        public bool BajaMoto(string matricula)
        {
            return true;
        }

        public bool ModificarMoto(Motos moto)
        {
            return true;
        }
    }
}
