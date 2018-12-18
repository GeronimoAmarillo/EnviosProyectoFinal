using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PersistenciaCore
{
    class PersistenciaPalet:IPersistenciaPalet
    {
        public Palet BuscarPalet(int id)
        {
            try
            {
                Palets palet = new Palets();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    palet = dbConnection.Palets.Include("Clientes.Usuarios").Where(a => a.Id == id).FirstOrDefault();
                }

                Palet paletResultado = null;

                if (palet != null)
                {
                    paletResultado = new Palet();

                    paletResultado.Cantidad = palet.Cantidad;
                    paletResultado.Casilla = palet.Casilla;
                    paletResultado.Cliente = palet.Cliente;
                    paletResultado.Clientes = ConvertirCliente(palet.Clientes);
                    paletResultado.Id = palet.Id;
                    paletResultado.Peso = palet.Peso;
                    paletResultado.Producto = palet.Producto;
                    paletResultado.Eliminado = palet.Eliminado;
                    paletResultado.fechaIngreso = palet.fechaIngreso;
                    paletResultado.fechaSalida = palet.fechaSalida;
                }

                return paletResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el palet." + ex.Message);
            }
        }

        public Cliente ConvertirCliente(Clientes c)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente.Direccion = c.Usuarios.Direccion;
                cliente.Email = c.Usuarios.Email;
                cliente.Id = c.Usuarios.Id;
                cliente.IdUsuario = c.IdUsuario;
                cliente.Mensualidad = c.Mensualidad;
                cliente.Nombre = c.Usuarios.Nombre;
                cliente.NombreUsuario = c.Usuarios.NombreUsuario;
                cliente.RUT = c.RUT;
                cliente.Telefono = c.Usuarios.Telefono;

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir el cliente." + ex.Message);
            }
        }

        public bool AltaPalet(EntidadesCompartidasCore.Palet palet)
        {
            try
            {
                PersistenciaCore.Palets paletAgregar = new PersistenciaCore.Palets();

                paletAgregar.Cantidad = palet.Cantidad;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                int codigoCasilla = 0;

                try
                {

                    using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                    {
                        var casilla = dbConnection.Casillas.Where(g => g.Rack == palet.Casilla).Select(c => new {
                            Casilla = c,
                            Palets = c.Palets
                        });

                        bool disponible = false;

                        foreach (var c in casilla)
                        {

                            if (c.Palets.Any())
                            {
                                disponible = false;
                            }
                            else
                            {
                                codigoCasilla = c.Casilla.Codigo;

                                disponible = true;

                                break;
                            }
                        }

                        if (!disponible)
                        {
                            throw new Exception("No hay ninguna casilla disponible en el rack seleccionado");
                        }
                    }
                        
                }
                catch (Exception ex)
                {
                    throw new Exception("Error" + ex.Message);
                }

                paletAgregar.Casilla = codigoCasilla;
                paletAgregar.Cliente = palet.Cliente;
                paletAgregar.Eliminado = false;

                int idPaletNuevo;

                try
                {
                    using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                    {
                        var idPalet = dbConnection.Palets.OrderByDescending(g => g.Id).Select(c => new {
                            Id = c.Id
                        }).FirstOrDefault();

                        if (idPalet == null)
                        {
                            idPaletNuevo = 1;
                        }
                        else
                        {
                            idPaletNuevo = (idPalet.Id + 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al generar el Id del palet");
                }

                paletAgregar.Id = idPaletNuevo;
                paletAgregar.Peso = palet.Peso;
                paletAgregar.Producto = palet.Producto;

                paletAgregar.Eliminado = palet.Eliminado;
                paletAgregar.fechaIngreso = DateTime.Now;
                paletAgregar.fechaSalida = null;

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Palets.Add(paletAgregar);

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el Palet." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Palet> ListarPalets()
        {
            try
            {
                List<Palets> palets = new List<Palets>();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    palets = dbConnection.Palets.Include("Clientes.Usuarios").Include("Casillas.Racks.Sectores").Where(x => x.Eliminado == false).ToList();
                }

                List<Palet> paletsResultado = new List<Palet>();

                foreach (Palets p in palets)
                {
                    Palet paletR = new Palet();

                    paletR.Cantidad = p.Cantidad;
                    paletR.Casilla = p.Casilla;
                    paletR.Clientes = ConvertirCliente(p.Clientes);
                    paletR.Cliente = p.Cliente;
                    paletR.Id = p.Id;
                    paletR.Peso = p.Peso;
                    paletR.Producto = p.Producto;
                    paletR.Eliminado = p.Eliminado;
                    paletR.fechaIngreso = p.fechaIngreso;
                    paletR.fechaSalida = p.fechaSalida;

                    paletsResultado.Add(paletR);
                }

                return paletsResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los palets." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Palet> ListarPaletsTodos()
        {
            try
            {
                List<Palets> palets = new List<Palets>();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    palets = dbConnection.Palets.Include("Clientes.Usuarios").Include("Casillas.Racks.Sectores").ToList();
                }

                List<Palet> paletsResultado = new List<Palet>();

                foreach (Palets p in palets)
                {
                    Palet paletR = new Palet();

                    paletR.Cantidad = p.Cantidad;
                    paletR.Casilla = p.Casilla;
                    paletR.Clientes = ConvertirCliente(p.Clientes);
                    paletR.Cliente = p.Cliente;
                    paletR.Id = p.Id;
                    paletR.Peso = p.Peso;
                    paletR.Producto = p.Producto;
                    paletR.Eliminado = p.Eliminado;
                    paletR.fechaIngreso = p.fechaIngreso;
                    paletR.fechaSalida = p.fechaSalida;

                    paletsResultado.Add(paletR);
                }

                return paletsResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los palets." + ex.Message);
            }
        }


        public EntidadesCompartidasCore.Galpon BuscarGalpon(int id)
        {
            try
            {
                Galpon galponR = null;

                Galpones galponEncontrado = null;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var galpon = dbConnection.Galpones.Where(g => g.Id == id).Select(c => new {
                        Galpon = c,
                        Sectores = c.Sectores
                    }).FirstOrDefault();


                    foreach (var se in galpon.Sectores)
                    {
                        var racksSector = dbConnection.Sectores.Where(s => s.Codigo == se.Codigo).Select(r => new
                        {
                            ListaRacks = r.Racks

                        }).FirstOrDefault();

                        foreach (var r in racksSector.ListaRacks)
                        {
                            se.Racks.Add(r);
                        }

                        foreach (var ra in se.Racks)
                        {
                            var casillasRack = dbConnection.Racks.Where(r => r.Codigo == ra.Codigo).Select(t => new
                            {
                                Casillas = t.Casillas
                            }).FirstOrDefault();

                            foreach (var c in casillasRack.Casillas)
                            {
                                ra.Casillas.Add(c);
                            }

                            foreach (var ca in ra.Casillas)
                            {
                                var paletsCasilla = dbConnection.Casillas.Where(r => r.Codigo == ca.Codigo).Select(t => new
                                {
                                    Palets = t.Palets
                                }).FirstOrDefault();

                                foreach (var p in paletsCasilla.Palets)
                                {
                                    ca.Palets.Add(p);
                                }
                            }
                        }

                    }

                    if (galpon != null && galpon.Galpon is Galpones)
                    {
                        galponR = new Galpon();

                        galponR.Id = galpon.Galpon.Id;
                        galponR.Altura = galpon.Galpon.Altura;
                        galponR.Superficie = galpon.Galpon.Superficie;
                        galponR.Sectores = convertirSectores(galpon.Galpon.Sectores.ToList());

                    }
                }

                return galponR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el galpon." + ex.Message);
            }
        }

        public bool BajaPalet(int id)
        {
            try
            {
                Palets paletBaja = new Palets();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    paletBaja = dbConnection.Palets.Where(a => a.Id == id).FirstOrDefault();
                    paletBaja.fechaSalida = DateTime.Now;
                    paletBaja.Eliminado = true;

                    if (paletBaja != null)
                    {
                        dbConnection.Palets.Update(paletBaja);

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
                throw new Exception("Error al dar de baja el palet." + ex.Message);
            }
        }

        public List<Sector> convertirSectores(List<Sectores> sectores)
        {
            try
            {
                List<Sector> sectoresConvertidos = new List<Sector>();

                foreach (Sectores s in sectores)
                {
                    Sector sector = new Sector();

                    sector.Codigo = s.Codigo;
                    sector.Galpon = s.Galpon;
                    sector.Superficie = s.Superficie;
                    sector.Temperatura = s.Temperatura;

                    List<Rack> racks = new List<Rack>();

                    foreach (Racks r in s.Racks)
                    {
                        Rack rack = new Rack();

                        rack.Altura = r.Altura;
                        rack.Codigo = r.Codigo;
                        rack.Sector = r.Sector;
                        rack.Superficie = r.Superficie;

                        List<Casilla> casillas = new List<Casilla>();

                        foreach (Casillas c in r.Casillas)
                        {
                            Casilla casilla = new Casilla();

                            casilla.Codigo = c.Codigo;
                            casilla.Rack = c.Rack;

                            List<Palet> palets = new List<Palet>();

                            foreach (Palets p in c.Palets)
                            {
                                Palet palet = new Palet();

                                palet.Cantidad = p.Cantidad;
                                palet.Casilla = p.Casilla;
                                palet.Cliente = p.Cliente;
                                palet.Id = p.Id;
                                palet.Peso = p.Peso;
                                palet.Producto = p.Producto;

                                palets.Add(palet);
                            }

                            casilla.Palets = palets;

                            casillas.Add(casilla);
                        }

                        rack.Casillas = casillas;

                        racks.Add(rack);
                    }

                    sector.Racks = racks;

                    sectoresConvertidos.Add(sector);
                }

                return sectoresConvertidos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir los sectores." + ex.Message);
            }
        }
    }
}
