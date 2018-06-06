using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorUsuario
    {
        bool EnviarMail(Usuario usuario);

        Usuario BuscarUsuario(string mail);

        Usuario Login(string user, string pass);

        bool ModificarNombreUsuario(string user);

        bool ComprobarUser(string user);

        bool RecuperarContraseña(string email);

        bool ModificarUsuario(Usuario pUsuario);
    }
}
