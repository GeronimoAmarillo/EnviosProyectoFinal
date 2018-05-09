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

        public Usuarios BuscarUsuario(string mail)
        {
            return new Usuarios();
        }
        
        public bool Login(string user, string pass)
        {
            return true;
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
