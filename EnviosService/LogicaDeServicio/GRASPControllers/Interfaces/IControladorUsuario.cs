using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorUsuario
    {
        bool EnviarMail(Usuarios usuario);

        Usuarios BuscarUsuario(string mail);

        Usuarios Login(string user, string pass);

        bool ModificarNombreUsuario(string user);

        bool ComprobarUser(string user);

        bool RecuperarContraseña(string email);

        bool ModificarUsuario(Usuarios pUsuario);
    }
}
