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
        public bool AltaCadete(EntidadesCompartidas.Cadete cadete)
        {
            return true;
        }

        public bool ExisteCadete(int ci)
        {
            return true;
        }

        public List<EntidadesCompartidas.Cadete> ListarCadetes()
        {
            return new List<EntidadesCompartidas.Cadete>();
        }

        public EntidadesCompartidas.Cadete Login(string user, string contraseña)
        {
            /*EntidadesCompartidas.Cadetes cadeteLogueado = new EntidadesCompartidas.Cadetes();

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
            }*/

            return new EntidadesCompartidas.Cadete();


        }

        public bool ModificarCadete(EntidadesCompartidas.Cadete cadete)
        {
            return true;
        }

        public List<EntidadesCompartidas.Cadete> ListarCadetesDisponibles()
        {
            return new List<EntidadesCompartidas.Cadete>();
        }

        public bool BajaCadete(int ci)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public EntidadesCompartidas.Cadete BuscarCadete(int ci)
        {
            return new EntidadesCompartidas.Cadete();
        }
    }
}
