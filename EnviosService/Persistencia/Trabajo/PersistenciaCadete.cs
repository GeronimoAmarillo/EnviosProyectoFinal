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
            Cadetes cadeteLogueado = new Cadetes();
            EnviosEntities dbConexion = new EnviosEntities();
            try
            {

                var cadeteEncontrado = from cadete in dbConexion.Cadetes
                                 where cadete.Empleados.Usuarios.NombreUsuario == user && cadete.Empleados.Usuarios.Contraseña == contraseña
                                 select cadete;

                foreach (Cadetes c in cadeteEncontrado)
                {
                    cadeteLogueado = c;
                }
                   
                return cadeteLogueado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar loguear el Cadete" + ex.Message);
            }
           
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
