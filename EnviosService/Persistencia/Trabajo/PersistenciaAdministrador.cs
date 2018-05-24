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

        public bool AltaAdministrador(EntidadesCompartidas.Administrador administrador)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public List<EntidadesCompartidas.Administrador> ListarAdministradores()
        {
            return new List<EntidadesCompartidas.Administrador>();
        }

        public bool ModificarAdmin(EntidadesCompartidas.Administrador admin)
        {
            return true;
        }

        public EntidadesCompartidas.Administrador Login(string user, string contraseña)
        {
            /*EntidadesCompartidas.Administradores administradorLogueado = new EntidadesCompartidas.Administradores();
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
            }*/

            return new EntidadesCompartidas.Administrador();
        }

        public bool BajaAdministrador(int ci)
        {
            return true;
        }

        public EntidadesCompartidas.Administrador BusxarAdministrador(int ci)
        {
            return new EntidadesCompartidas.Administrador();
        }
    }
}
