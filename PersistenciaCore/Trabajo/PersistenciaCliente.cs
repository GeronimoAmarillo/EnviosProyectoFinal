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
        }*/

        public Cliente BuscarCliente(int rut)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                Cliente clienteResultado = new Cliente();


                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Include("Usuarios").Where(x => x.RUT == rut).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {
                        clienteResultado.Id = clienteEncontrado.IdUsuario;
                        clienteResultado.Nombre = clienteEncontrado.Usuarios.Nombre;
                        clienteResultado.Direccion = clienteEncontrado.Usuarios.Direccion;
                        clienteResultado.Contraseña = clienteEncontrado.Usuarios.Contraseña;
                        clienteResultado.Email = clienteEncontrado.Usuarios.Email;
                        clienteResultado.Mensualidad = clienteEncontrado.Mensualidad;
                        clienteResultado.NombreUsuario = clienteEncontrado.Usuarios.NombreUsuario;
                        clienteResultado.RUT = clienteEncontrado.RUT;
                        clienteResultado.Telefono = clienteEncontrado.Usuarios.Telefono;
                    }
                }
                return clienteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool SetearCodigoRecuperacionContraseña(Cliente cliente)
        {
            try

            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Clientes clienteDesdeBd = dbConnection.Clientes.Include("Usuarios").Where(x => x.RUT == cliente.RUT).FirstOrDefault();


                    if (clienteDesdeBd != null)
                    {
                        clienteDesdeBd.Usuarios.CodigoRecuperacionContraseña = cliente.CodigoRecuperacionContraseña;

                        dbConnection.Clientes.Update(clienteDesdeBd);

                        dbConnection.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Cliente" + ex.Message);
            }
        }

        public bool SetearCodigoModificarEmail(Cliente cliente)
        {
            try

            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Clientes clienteDesdeBd = dbConnection.Clientes.Include("Usuarios").Where(x => x.RUT == cliente.RUT).FirstOrDefault();


                    if (clienteDesdeBd != null)
                    {
                        clienteDesdeBd.Usuarios.CodigoModificarEmail = cliente.CodigoModificarEmail;

                        dbConnection.Clientes.Update(clienteDesdeBd);

                        dbConnection.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Cliente" + ex.Message);
            }
        }

        public Cliente BuscarClienteXEmail(string email)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                Cliente clienteResultado = new Cliente();


                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Include("Usuarios").Where(x => x.Usuarios.Email == email).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {
                        clienteResultado.Id = clienteEncontrado.IdUsuario;
                        clienteResultado.Nombre = clienteEncontrado.Usuarios.Nombre;
                        clienteResultado.Direccion = clienteEncontrado.Usuarios.Direccion;
                        clienteResultado.Contraseña = clienteEncontrado.Usuarios.Contraseña;
                        clienteResultado.Email = clienteEncontrado.Usuarios.Email;
                        clienteResultado.Mensualidad = clienteEncontrado.Mensualidad;
                        clienteResultado.NombreUsuario = clienteEncontrado.Usuarios.NombreUsuario;
                        clienteResultado.RUT = clienteEncontrado.RUT;
                        clienteResultado.Telefono = clienteEncontrado.Usuarios.Telefono;
                    }
                }
                return clienteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool VerificarCodigoContraseña(string email, string codigo)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();
                
                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Include("Usuarios").Where(x => x.Usuarios.Email == email && x.Usuarios.CodigoRecuperacionContraseña == codigo).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool VerificarCodigoEmail(string email, string codigo)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Include("Usuarios").Where(x => x.Usuarios.Email == email && x.Usuarios.CodigoModificarEmail == codigo).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool ExisteClienteXEmail(string email)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                Cliente clienteResultado = new Cliente();


                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Where(x => x.Usuarios.Email == email).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool AltaCliente(Cliente cliente)
        { 
            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();
            
            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {

                Clientes clienteAgregar = new Clientes();

                clienteAgregar.IdUsuario = 0;
                clienteAgregar.Mensualidad = cliente.Mensualidad;
                clienteAgregar.RUT = cliente.RUT;
                clienteAgregar.Usuarios = new Usuarios();
                clienteAgregar.Usuarios.Contraseña = cliente.Contraseña;
                clienteAgregar.Usuarios.Direccion = cliente.Direccion;
                clienteAgregar.Usuarios.Email = cliente.Email;
                clienteAgregar.Usuarios.Id = 0;
                clienteAgregar.Usuarios.Nombre = cliente.Nombre;
                clienteAgregar.Usuarios.NombreUsuario = cliente.NombreUsuario;
                clienteAgregar.Usuarios.Telefono = cliente.Telefono;

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Clientes.Add(clienteAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar agregar el Cliente: " + ex.Message);
            }
        }

        public bool ExisteCliente(long rut)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                Cliente clienteResultado = new Cliente();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var clienteEncontrado = dbConnection.Clientes.Where(x => x.RUT == rut).FirstOrDefault();

                    if (clienteEncontrado != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente." + ex.Message);
            }
        }

        public bool ModificarCliente(Cliente cliente)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);
            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {

                    Clientes clienteDesdeBd = dbConnection.Clientes.Include("Usuarios").Where(x => x.RUT == cliente.RUT).FirstOrDefault();


                    if (clienteDesdeBd != null)
                    {
                        clienteDesdeBd.Usuarios.Nombre = cliente.Nombre;
                        clienteDesdeBd.Usuarios.Direccion = cliente.Direccion;
                        clienteDesdeBd.Usuarios.Telefono = cliente.Telefono;
                        clienteDesdeBd.Usuarios.Email = cliente.Email;
                        clienteDesdeBd.Mensualidad = cliente.Mensualidad;

                        dbConnection.Clientes.Update(clienteDesdeBd);

                        dbConnection.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Cliente" + ex.Message);
            }
        }

        public bool ComprobarUser(string user)
        {
           bool existe= false;

            return existe;           
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
