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
        public bool AltaPalet(EntidadesCompartidasCore.Palet palet)
        {
            try
            {
                PersistenciaCore.Palets paletAgregar = new PersistenciaCore.Palets();

                paletAgregar.Cantidad = palet.Cantidad;
                paletAgregar.Casilla = palet.Casilla;
                paletAgregar.Cliente = palet.Cliente;
                paletAgregar.Id = palet.Id;
                paletAgregar.Peso = palet.Peso;
                paletAgregar.Producto = palet.Producto;
             

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Palets.Add(paletAgregar);

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el Palet.");
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
                    palets = dbConnection.Palets.ToList();
                }

                List<Palet> paletsResultado = new List<Palet>();

                foreach (Palets p in palets)
                {
                    Palet paletR = new Palet();

                    paletR.Cantidad = p.Cantidad;
                    paletR.Casilla = p.Casilla;
                    paletR.Cliente = p.Cliente;
                    paletR.Id = p.Id;
                    paletR.Peso = p.Peso;
                    paletR.Producto = p.Producto;

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
                        Sectores = c.Sectores,
                        Racks = c.Sectores
                    }).FirstOrDefault();

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

        public bool BajaPalet(EntidadesCompartidasCore.Palet palet)
        {
            return true;
        }

        public List<Sector> convertirSectores(List<Sectores> sectores)
        {
            try
            {
                List<Sector> sectoresConvertidos = null;

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
