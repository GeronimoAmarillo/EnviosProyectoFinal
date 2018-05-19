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
        public bool EnviarMail(Usuarios usuario)
        {
            return true;
        }

        public bool AltaUsuario(Usuarios unUsuario)
        {
            try
            {
                return LogicaUsuario.AltaUsuario(unUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuarios BuscarUsuario(string mail)
        {
            return new Usuarios();
        }
        
        public Usuarios Login(string user, string pass)
        {
            Usuarios usuarioLogueado = new Usuarios();
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
        
        public bool ModificarUsuario(Usuarios pUsuario)
        {
            return true;
        }
    }
}
