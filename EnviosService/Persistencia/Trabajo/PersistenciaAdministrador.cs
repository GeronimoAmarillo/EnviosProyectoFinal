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
            Administradores administradorLogueado = new Administradores();
            EnviosEntities dbConexion = new EnviosEntities();
            try
            {

                var adminEncontrado = from admin in dbConexion.Administradores
                                       where admin.Empleados.Usuarios.NombreUsuario == user && admin.Empleados.Usuarios.Contraseña == contraseña
                                       select admin;

                foreach (Administradores a in adminEncontrado)
                {
                    administradorLogueado = a;
                }

                return administradorLogueado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar loguear el Cadete" + ex.Message);
            }
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
