using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorUsuario
    {
        bool EnviarMail(Usuario usuario);

        Usuario BuscarUsuario(string mail);

        string GetContraseña();

        Task<bool> AltaUsuario(Usuario unUsuario);

        void SetContraseña(string pContraseña);

        Task<Usuario> Login(string user, string pass);

        bool ModificarNombreUsuario(string user);

        bool ComprobarNombreUsuario(string user);

        void SetUsuario(Usuario pUsuario);

        Usuario ModificarContraseña(string contraseñaNueva);

        Usuario ModificarEmail(Usuario pUsuario);

        Usuario GetUsuario();

        bool ComprobarContraseña(string contraseña);

        bool RecuperarContraseña(string email);

        bool Logout();

        bool ModificarUsuario(Usuario pUsuario);

    }
}
