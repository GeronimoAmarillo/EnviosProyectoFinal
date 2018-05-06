using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaCadete:IPersistenciaCadete
    {
        public bool AltaCadete(Cadetes cadete)
        {
            return true;
        }

        public bool ExisteCadete(int ci)
        {
            return true;
        }

        public List<Cadetes> ListarCadetes()
        {
            return new List<Cadetes>();
        }

        public Cadetes Login(string user, string contraseña)
        {
            return new Cadetes();
        }

        public bool ModificarCadete(Cadetes cadete)
        {
            return true;
        }

        public List<Cadetes> ListarCadetesDisponibles()
        {
            return new List<Cadetes>();
        }

        public bool BajaCadete(int ci)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public Cadetes BuscarCadete(int ci)
        {
            return new Cadetes();
        }
    }
}
