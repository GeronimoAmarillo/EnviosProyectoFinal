using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using AutoMapper;

namespace Persistencia
{
    class PersistenciaCliente:IPersistenciaCliente
    {

        public PersistenciaCliente()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Cliente, Clientes>()
                    .ForMember(d => d.RUT, opt => opt.MapFrom(u => u.RUT))
                    .ForMember(d => d.Mensualidad, opt => opt.MapFrom(u => u.Mensualidad))
                    .ForMember(d => d.Palets, opt => opt.MapFrom(u => u.Palets))
                    .ForMember(d => d.Usuarios, opt => opt.MapFrom(u => u.Usuarios))
                    .ForMember(d => d.Paquetes, opt => opt.MapFrom(u => u.Paquetes))
                    .ForMember(d => d.Calificaciones, opt => opt.MapFrom(u => u.Calificaciones))
                ;

                cfg.CreateMap<Usuario, Usuarios>()
                    .ForMember(d => d.Nombre, opt => opt.MapFrom(u => u.Nombre))
                    .ForMember(d => d.NombreUsuario, opt => opt.MapFrom(u => u.NombreUsuario))
                    .ForMember(d => d.Telefono, opt => opt.MapFrom(u => u.Telefono))
                    .ForMember(d => d.Contraseña, opt => opt.MapFrom(u => u.Contraseña))
                    .ForMember(d => d.Direccion, opt => opt.MapFrom(u => u.Direccion))
                    .ForMember(d => d.Email, opt => opt.MapFrom(u => u.Email))
                ;
            });
        }

        public bool AltaCliente(Cliente cliente)
        {
            try
            {
                Clientes ClienteaAgregar = Mapper.Map<Clientes>(cliente);
                using (EnviosContext dbConnection = new EnviosContext())
                {
                    if (dbConnection.Clientes.Any(x => x.RUT.ToString() == cliente.RUT.ToString()))
                    {
                        throw new Exception("Ya existe el rut");
                        //return false;
                    }
                    else
                    {
                        dbConnection.Clientes.Add(ClienteaAgregar);
                        dbConnection.SaveChanges();
                        return true;
                    }
                }   

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar agregar el Cliente: " + ex.Message);
            }

        }

        public bool ExisteCliente(int rut)
        {
            return true;
        }

        public bool ModificarCliente(Usuario usuario)
        {
            return true;
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public List<Cliente> ListarClientes()
        {
            return new List<Cliente>();
        }

        public Cliente Login(string user, string contraseña)
        {
            Cliente clienteResultado = new Cliente();

            EnviosContext dbConexion = new EnviosContext();
            try
            {

                var clienteEncontrado = from cliente in dbConexion.Clientes
                                       where cliente.Usuarios.NombreUsuario == user && cliente.Usuarios.Contraseña == contraseña
                                       select cliente;

                foreach (Clientes c in clienteEncontrado)
                {
                    clienteResultado.Contraseña = c.Usuarios.Contraseña;
                    clienteResultado.Direccion = c.Usuarios.Direccion;
                    clienteResultado.Email = c.Usuarios.Email;
                    clienteResultado.Id = c.Usuarios.Id;
                    clienteResultado.Mensualidad = c.Mensualidad;
                    clienteResultado.Nombre = c.Usuarios.Nombre;
                    clienteResultado.NombreUsuario = c.Usuarios.NombreUsuario;
                    clienteResultado.RUT = c.RUT;
                    clienteResultado.Telefono = c.Usuarios.Telefono;
                }

                return clienteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar loguear el Cliente" + ex.Message);
            }
        }

        public bool BajaCliente(int ci)
        {
            return true;
        }
    }
}
