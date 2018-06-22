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
                        Galpon = c
                    }).FirstOrDefault();

                    if (galpon != null && galpon.Galpon is Galpones)
                    {
                        galponR = new Galpon();

                        galponR.Id = galpon.Galpon.Id;
                        galponR.Altura = galpon.Galpon.Altura;
                        //TODO completar el llenado del galpon (conviene usar el mapping)
                        galponR.Superficie = galpon.Galpon.Superficie;
                    }
                }

                return galponR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los locales." + ex.Message);
            }
        }

        public bool BajaPalet(EntidadesCompartidasCore.Palet palet)
        {
            return true;
        }
    }
}
