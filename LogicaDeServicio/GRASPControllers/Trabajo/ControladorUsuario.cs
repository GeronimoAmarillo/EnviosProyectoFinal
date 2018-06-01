using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorUsuario:IControladorUsuario
    {
        public bool EnviarMail(Usuario usuario)
        {
            return true;
        }

        public Usuario BuscarUsuario(string mail)
        {
            return new Usuario();
        }
        
        public Usuario Login(string user, string pass)
        {
            Usuario usuarioLogueado = new Usuario();
            try
            {
                usuarioLogueado = LogicaUsuario.Login(user, pass);

                return usuarioLogueado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al loguear el Usuario" + ex.Message);
            }
        }

        public bool ModificarNombreUsuario(string user)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }
        public bool RecuperarContraseña(string email)
        {
            return true;
        }
        
        public bool ModificarUsuario(Usuario pUsuario)
        {
            return true;
        }
    }
}
