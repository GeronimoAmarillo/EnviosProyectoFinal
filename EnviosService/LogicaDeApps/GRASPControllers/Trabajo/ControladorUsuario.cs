using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorUsuario: IControladorUsuario
    {
        private string contraseña;
        private Usuarios usuario;

        public bool EnviarMail(DTUsuario usuario)
        {
            return true;
        }

        public Usuarios BuscarUsuario(string mail)
        {
            return new Usuarios();
        }

        public string GetContraseña()
        {
            return contraseña;
        }

        public void SetContraseña(string pContraseña)
        {
            contraseña = pContraseña;
        }

        public bool Login(string user, string pass)
        {
            return true;
        }

        public bool ModificarNombreUsuario(string user)
        {
            return true;
        }

        public bool ComprobarNombreUsuario(string user)
        {
            return true; 
        }

        public void SetUsuario(Usuarios pUsuario)
        {
            usuario = pUsuario;
        }


        public Usuarios ModificarContraseña(string contraseñaNueva)
        {
            return new Usuarios();
        }

        public Usuarios ModificarEmail(DTUsuario pUsuario)
        {
            return new Usuarios();
        }

        public Usuarios GetUsuario()
        {
            return usuario;
        }

        public bool ComprobarContraseña(string contraseña)
        {
            return true;
        }

        public bool RecuperarContraseña(string email)
        {
            return true;
        }

        public bool Logout()
        {
            return true;
        }

        public bool ModificarUsuario(DTUsuario pUsuario)
        {
            return true;
        }
    }
}
