using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasAndroid;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorUsuario : IControladorUsuario
    {
        public bool AltaUsuario(EntidadesCompartidasCore.Usuario unUsuario)
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
        public bool BajaUsuario(int ci)
        {
            try
            {
                return LogicaUsuario.BajaUsuario(ci);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SetearCodigoRecuperarContraseña(EntidadesCompartidasCore.Usuario unUsuario)
        {
            try
            {
                return LogicaUsuario.SetearCodigoRecuperarContraseña(unUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SetearCodigoModificarEmail(EntidadesCompartidasCore.Usuario unUsuario)
        {
            try
            {
                return LogicaUsuario.SetearCodigoModificarEmail(unUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool VerificarCodigoContraseña(string email, string codigo)
        {
            try
            {
                bool correcto = false;

                correcto = LogicaUsuario.VerificarCodigoContraseña(email, codigo);

                return correcto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool VerificarCodigoEmail(string email, string codigo)
        {
            try
            {
                bool correcto = false;

                correcto = LogicaUsuario.VerificarCodigoEmail(email, codigo);

                return correcto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool EnviarMail(EntidadesCompartidasCore.Usuario usuario)
        {
            return true;
        }

        public EntidadesCompartidasCore.Usuario BuscarUsuario(string mail)
        {
            return new EntidadesCompartidasCore.Usuario();
        }

        public EntidadesCompartidasCore.Usuario Login(string user, string pass)
        {
            EntidadesCompartidasCore.Usuario usuarioLogueado = new EntidadesCompartidasCore.Usuario();
            try
            {
                usuarioLogueado = LogicaUsuario.Login(user, pass);

                return usuarioLogueado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al loguear el Usuario" + ex.Message);
            }
        }

        public EntidadesCompartidasAndroid.Usuario LoginDroid(string user, string pass)
        {
            try
            {
                return LogicaUsuario.LoginDroid(user, pass);
            }
            catch (Exception ex)
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
            try
            {
                return LogicaUsuario.ComprobarUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
        }
        public bool RecuperarContraseña(string email)
        {
            return true;
        }

        public bool ModificarUsuario(EntidadesCompartidasCore.Usuario pUsuario)
        {
            try
            {
                bool exito = LogicaUsuario.ModificarUsuario(pUsuario);
                return exito;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ModificarContrasenia(Usuario unUsuario)
        {
            return LogicaUsuario.ModificarContrasenia(unUsuario);
        }
    }
}
