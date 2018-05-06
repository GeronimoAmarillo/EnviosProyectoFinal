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
        public bool altaUsuario(Usuarios unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public bool existeCliente(long rut)
        {
            bool existe = false;
            return existe;
        }

        public bool existeEmpleado(int cedula)
        {
            bool existe = false;
            return existe;
        }

        public Cadetes seleccionarCadete(int cedula)
        {
            Cadetes cadete = new Cadetes();
            return cadete;
        }

        public bool modoficarUsuario(Usuarios unUsuario)
        {
            bool exito = false;
            return exito;
        }

        public List<Empleados> listarEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            return lista;
        }

        public List<Cadetes> listarCadetesDisponibles()
        {
            List<Cadetes> lista = new List<Cadetes>();
            return lista;
        }

        public List<Clientes> listarClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            return clientes;
        }

        public bool bajaUsuario(int cedula)
        {
            bool exito = false;
            return exito;
        }

        public Usuarios login(string usuario, string password)
        {
            Usuarios usuarioLogeado = new Usuarios();
            return usuarioLogeado;
        }

        public bool comprobarUser(string user)
        {
            bool exito = false;
            return exito;
        }

        public Empleados buscarEmpleado(int cedula)
        {
            Empleados empleado = new Empleados();
            return empleado;
        }
    }
}
