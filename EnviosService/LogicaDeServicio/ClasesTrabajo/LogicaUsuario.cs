using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public class LogicaUsuario
    {
        public bool AltaUsuario(Usuarios unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public bool ExisteCliente(long rut)
        {
            bool existe = false;
            return existe;
        }

        public bool ExisteEmpleado(int cedula)
        {
            bool existe = false;
            return existe;
        }

        public Cadetes SeleccionarCadete(int cedula)
        {
            Cadetes cadete = new Cadetes();
            return cadete;
        }

        public bool ModoficarUsuario(Usuarios unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public List<Empleados> ListarEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            return lista;
        }

        public List<Cadetes> ListarCadetesDisponibles()
        {
            List<Cadetes> lista = new List<Cadetes>();
            return lista;
        }

        public List<Clientes> ListarClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            return clientes;
        }

        public bool BajaUsuario(int cedula)
        {
            bool exito = false;
            return exito;
        }

        public Usuarios Login(string usuario, string password)
        {
            Usuarios usuarioLogeado = new Usuarios();
            return usuarioLogeado;
        }

        public bool ComprobarUser(string user)
        {
            bool exito = false;
            return exito;
        }

        public Empleados BuscarEmpleado(int cedula)
        {
            Empleados empleado = new Empleados();
            return empleado;
        }
    }
}
