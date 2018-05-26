using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorUsuario
    {
        bool EnviarMail(DTUsuario usuario);

        Usuario BuscarUsuario(string mail);

        string GetContraseña();

        void SetContraseña(string pContraseña);

        Task<DTUsuario> Login(string user, string pass);

        bool ModificarNombreUsuario(string user);

        bool ComprobarNombreUsuario(string user);

        void SetUsuario(Usuario pUsuario);

        Usuario ModificarContraseña(string contraseñaNueva);

        Usuario ModificarEmail(DTUsuario pUsuario);

        Usuario GetUsuario();

        bool ComprobarContraseña(string contraseña);

        bool RecuperarContraseña(string email);

        bool Logout();

        bool ModificarUsuario(DTUsuario pUsuario);

    }
}
