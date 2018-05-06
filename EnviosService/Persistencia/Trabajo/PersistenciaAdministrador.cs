using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaAdministrador:IPersistenciaAdministrador
    {
        public bool ExisteAdmin(int ci)
        {
            return true;
        }

        public bool AltaAdministrador(Administradores administrador)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public List<Administradores> ListarAdministradores()
        {
            return new List<Administradores>();
        }

        public bool ModificarAdmin(Administradores admin)
        {
            return true;
        }

        public Administradores Login(string user, string contraseña)
        {
            return new Administradores();
        }

        public bool BajaAdministrador(int ci)
        {
            return true;
        }

        public Administradores BusxarAdministrador(int ci)
        {
            return new Administradores();
        }
    }
}
