using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace PersistenciaCore
{
    class PersistenciaCliente:IPersistenciaCliente
    {
        /*public PersistenciaCliente()
        {
            
        }*/

        public bool AltaCliente(Cliente cliente)
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

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                Usuarios UsuarioaAgregar = Mapper.Map<Usuarios>(cliente);
                Clientes ClienteaAgregar = Mapper.Map<Clientes>(cliente);
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    if (dbConnection.Clientes.Any(x => x.RUT.ToString() == cliente.RUT.ToString()))
                    {
                        //throw new Exception("Ya existe el rut");
                        return false;
                    }
                    else
                    {
                        dbConnection.Usuarios.Add(UsuarioaAgregar);
                        ClienteaAgregar.IdUsuario = UsuarioaAgregar.Id;
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

        public bool ModificarCliente(Cliente cliente)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);
            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    Usuarios usuarioDesdeBd = dbConnection.Usuarios.Single(x => x.Nombre.ToString() == cliente.Nombre.ToString());
                    Clientes clienteDesdeBd = dbConnection.Clientes.Single(x => x.RUT.ToString() == cliente.RUT.ToString());
                    if (usuarioDesdeBd != null && clienteDesdeBd != null)
                    {
                        usuarioDesdeBd.Nombre = cliente.Nombre;
                        usuarioDesdeBd.Direccion = cliente.Direccion;
                        usuarioDesdeBd.Telefono = cliente.Telefono;
                        usuarioDesdeBd.Email = cliente.Email;
                        clienteDesdeBd.Mensualidad = cliente.Mensualidad;
                        dbConnection.SaveChanges();
                        return true;
                    }
                    return false;
                    

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Cliente" + ex.Message);
            }
        }

        public bool ComprobarUser(string user)
        {
            return true;
        }

        public List<Cliente> ListarClientes()
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                List<Cliente> clientesResultado = new List<Cliente>();


                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Select(c => new {
                        Cliente = c,
                        Usuario = c.Usuarios
                    });

                    foreach (var c in clienteEncontrado)
                    {
                        Cliente clienteR = new Cliente();

                        clienteR.Id = c.Cliente.IdUsuario;
                        clienteR.Nombre = c.Usuario.Nombre;
                        clienteR.Direccion = c.Usuario.Direccion;
                        clienteR.Contraseña = c.Usuario.Contraseña;
                        clienteR.Email = c.Usuario.Email;
                        clienteR.Mensualidad = c.Cliente.Mensualidad;
                        clienteR.NombreUsuario = c.Usuario.NombreUsuario;
                        clienteR.RUT = c.Cliente.RUT;
                        clienteR.Telefono = c.Usuario.Telefono;

                        clientesResultado.Add(clienteR);
                    }
                }
                return clientesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes." + ex.Message);
            }
        }

        public Cliente Login(string user, string contraseña)
        {
            Cliente clienteResultado = null;

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Where(c => c.Usuarios.NombreUsuario == user && c.Usuarios.Contraseña == contraseña).Select(c => new {
                        Cliente = c,
                        Usuario = c.Usuarios
                    }).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {

                        if (clienteEncontrado.Usuario != null && clienteEncontrado.Cliente != null)
                        {
                            clienteResultado = new Cliente();


                            clienteResultado.Contraseña = clienteEncontrado.Usuario.Contraseña;
                            clienteResultado.Direccion = clienteEncontrado.Usuario.Direccion;
                            clienteResultado.Email = clienteEncontrado.Usuario.Email;
                            clienteResultado.Id = clienteEncontrado.Usuario.Id;
                            clienteResultado.Mensualidad = clienteEncontrado.Cliente.Mensualidad;
                            clienteResultado.Nombre = clienteEncontrado.Usuario.Nombre;
                            clienteResultado.NombreUsuario = clienteEncontrado.Usuario.NombreUsuario;
                            clienteResultado.RUT = clienteEncontrado.Cliente.RUT;
                            clienteResultado.Telefono = clienteEncontrado.Usuario.Telefono;
                        }
                        
                    }

                    return clienteResultado;
                }

                    
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
