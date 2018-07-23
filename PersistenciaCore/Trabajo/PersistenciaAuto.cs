using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaAuto:IPersistenciaAuto
    {
        public bool AltaAuto(EntidadesCompartidasCore.Automobil automobiles)
        {
            try
            {
                PersistenciaCore.Automobiles autoAgregar = new PersistenciaCore.Automobiles();
                PersistenciaCore.Vehiculos vehiculoAgregar = new Vehiculos();

                vehiculoAgregar.Matricula = automobiles.Matricula;
                vehiculoAgregar.Marca = automobiles.Marca;
                vehiculoAgregar.Modelo = automobiles.Modelo;
                vehiculoAgregar.Capacidad = automobiles.Capacidad;
                vehiculoAgregar.Cadete = automobiles.Cadete;
                vehiculoAgregar.Estado = automobiles.Estado;


                autoAgregar.Puertas = automobiles.Puertas;
                autoAgregar.MatriculaAuto = automobiles.Matricula;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Vehiculos.Add(vehiculoAgregar);
                    dbConnection.Automobiles.Add(autoAgregar);

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el Auto.");
            }
        }

        public List<EntidadesCompartidasCore.Automobil> ListarAutos()
        {
            try
            {
                List<Automobiles> autos = new List<Automobiles>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    autos = dbConnection.Automobiles.Include("Vehiculos").ToList();
                }

                List<Automobil> autosResultado = new List<Automobil>();

                foreach (Automobiles m in autos)
                {
                    Automobil autoR = new Automobil();

                    autoR.Matricula = m.Vehiculos.Matricula;
                    autoR.Marca = m.Vehiculos.Marca;
                    autoR.Modelo = m.Vehiculos.Modelo;
                    autoR.Capacidad = m.Vehiculos.Capacidad;
                    autoR.Cadete = m.Vehiculos.Cadete;
                    autoR.Estado = m.Vehiculos.Estado;
                    autoR.Puertas = m.Puertas;

                    autosResultado.Add(autoR);
                }

                return autosResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los autos." + ex.Message);
            }
        }

        public bool BajaAuto(string matricula)
        {
            return true;
        }

        public bool ModificarAuto(EntidadesCompartidasCore.Automobil auto)
        {
            return true;
        }

        public EntidadesCompartidasCore.Automobil BuscarAuto(string matricula)
        {
            return new EntidadesCompartidasCore.Automobil();
        }

        public bool ExisteAuto(string matricula)
        {
            try
            {
                bool existe = false;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var auto = dbConnection.Automobiles.Where(l => l.MatriculaAuto == matricula).Select(c => new {
                        Auto = c
                    }).FirstOrDefault();

                    if (auto != null && auto.Auto is Automobiles)
                    {
                        existe = true;
                    }
                }

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el vehiculo." + ex.Message);
            }
        }
    }
}
