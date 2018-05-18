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

        Usuarios BuscarUsuario(string mail);

        string GetContraseña();

        void SetContraseña(string pContraseña);

        Task<DTUsuario> Login(string user, string pass);

        bool ModificarNombreUsuario(string user);

        bool ComprobarNombreUsuario(string user);

        void SetUsuario(Usuarios pUsuario);

        Usuarios ModificarContraseña(string contraseñaNueva);

        Usuarios ModificarEmail(DTUsuario pUsuario);

        Usuarios GetUsuario();

        bool ComprobarContraseña(string contraseña);

        bool RecuperarContraseña(string email);

        bool Logout();

        bool ModificarUsuario(DTUsuario pUsuario);

    }
}
