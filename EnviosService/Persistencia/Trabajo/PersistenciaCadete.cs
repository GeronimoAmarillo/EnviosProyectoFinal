using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaCadete:IPersistenciaCadete
    {
        public bool AltaCadete(EntidadesCompartidas.Cadete cadete)
        {
            try
            {
                Cadetes cadeteNuevo = new Cadetes();
                cadeteNuevo.Id = cadete.Id;
                cadeteNuevo.NombreUsuario = cadete.NombreUsuario;
                cadeteNuevo.Sueldo = cadete.Sueldo;
                cadeteNuevo.Telefono = cadete.Telefono;
                cadeteNuevo.Ci = cadete.Ci;
                cadeteNuevo.TipoLibreta = cadete.TipoLibreta;
                cadeteNuevo.IdTelefono = cadete.IdTelefono;
                cadeteNuevo.Contraseña = cadete.Contraseña;
                cadeteNuevo.Contraseña = cadete.Contraseña;

                using (EnviosContext dbConnection = new EnviosContext())
                {
                    dbConnection.Cadetes.Add(cadeteNuevo);
                    dbConnection.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el administrador");
            }
        }

        public bool ExisteCadete(int ci)
        {

            EnviosContext dbConexion = new EnviosContext();

            var cadeteEncontrado = from cadete in dbConexion.Cadetes
                                   where cadete.Empleados.Cadetes.Ci==ci
                                   select cadete;

            if (cadeteEncontrado != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<EntidadesCompartidas.Cadete> ListarCadetes()
        {
            return new List<EntidadesCompartidas.Cadete>();
        }

        public EntidadesCompartidas.Cadete Login(string user, string contraseña)
        {
            Cadete cadeteResultado = new Cadete();

            EnviosContext dbConexion = new EnviosContext();

            try
            {

                var cadeteEncontrado = from cadete in dbConexion.Cadetes
                                 where cadete.Empleados.Usuarios.NombreUsuario == user && cadete.Empleados.Usuarios.Contraseña == contraseña
                                 select cadete;

                foreach (Cadetes c in cadeteEncontrado)
                {
                    cadeteResultado.Contraseña = c.Empleados.Usuarios.Contraseña;
                    cadeteResultado.Direccion = c.Empleados.Usuarios.Direccion;
                    cadeteResultado.Email = c.Empleados.Usuarios.Email;
                    cadeteResultado.Id = c.Empleados.Usuarios.Id;
                    cadeteResultado.Ci = c.CiEmpleado;
                    cadeteResultado.Nombre = c.Empleados.Usuarios.Nombre;
                    cadeteResultado.NombreUsuario = c.Empleados.Usuarios.NombreUsuario;
                    cadeteResultado.Sueldo = c.Empleados.Sueldo;
                    cadeteResultado.Telefono = c.Empleados.Usuarios.Telefono;
                    cadeteResultado.TipoLibreta = c.TipoLibreta;
                    
                    //Tal vez corresponde tambien asignarle el vehiculo, esto va a necesitar de un cambio en el script de la base de datos, debido a que el 
                    //cadete de momento puede tener varios vehiculos, y me parece que eso no representa la realidad, no lo recuerdo.
                }

                return cadeteResultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar loguear el Cadete" + ex.Message);
            }


        }

        public bool ModificarCadete(EntidadesCompartidas.Cadete cadete)
        {
            return true;
        }

        public List<EntidadesCompartidas.Cadete> ListarCadetesDisponibles()
        {
            return new List<EntidadesCompartidas.Cadete>();
        }

        public bool BajaCadete(int ci)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public EntidadesCompartidas.Cadete BuscarCadete(int ci)
        {
            return new EntidadesCompartidas.Cadete();
        }
    }
}
