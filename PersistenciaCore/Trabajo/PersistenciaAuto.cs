using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
                autoAgregar.Vehiculos = vehiculoAgregar;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
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
                    autoR.MatriculaAuto = m.MatriculaAuto;

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
            try
            {
                Automobiles auto = new Automobiles();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    auto = dbConnection.Automobiles.Include("Vehiculos").Where(a => a.MatriculaAuto == matricula).FirstOrDefault();

                    if (auto != null)
                    {
                        dbConnection.Automobiles.Remove(auto);

                        dbConnection.Vehiculos.Remove(auto.Vehiculos);

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
                throw new Exception("Error al buscar la moto." + ex.Message);
            }
        }

        public bool ModificarAuto(EntidadesCompartidasCore.Automobil auto)
        {
            Vehiculos vehiculoaModificar = new Vehiculos()
            {
                Matricula = auto.Matricula,
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                Capacidad = auto.Capacidad,
                Estado = auto.Estado,
                Cadete = auto.Cadete
            };

            Automobiles autoaModificar = new Automobiles()
            {
                Puertas = auto.Puertas,
                MatriculaAuto = auto.Matricula,
                Vehiculos = vehiculoaModificar
            };

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    int vehiculoDesdeDB = (dbConnection.Vehiculos.Where(x => x.Matricula == auto.Matricula)).Count();
                    int autoDesdeDb = (dbConnection.Automobiles.Where(x => x.MatriculaAuto == auto.Matricula)).Count();
                    if (vehiculoDesdeDB == 1 && autoDesdeDb == 1)
                    {
                        dbConnection.Automobiles.Update(autoaModificar);
                        dbConnection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se encontro el auto a modificar.");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Auto: " + ex.Message);
            }
            
        }

        public EntidadesCompartidasCore.Automobil BuscarAuto(string matricula)
        {
            try
            {
                Automobiles auto = new Automobiles();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    auto = dbConnection.Automobiles.Include("Vehiculos.Reparaciones").Include("Vehiculos.Multas").Where(a => a.MatriculaAuto == matricula).FirstOrDefault();
                }

                Automobil autoResultado = null;

                if (auto != null)
                {
                    autoResultado = new Automobil();

                    autoResultado.Cadete = auto.Vehiculos.Cadete;
                    autoResultado.Capacidad = auto.Vehiculos.Capacidad;
                    autoResultado.Puertas = auto.Puertas;
                    autoResultado.Estado = auto.Vehiculos.Estado;
                    autoResultado.Marca = auto.Vehiculos.Marca;
                    autoResultado.Matricula = auto.Vehiculos.Matricula;
                    autoResultado.MatriculaAuto = auto.Vehiculos.Matricula;
                    autoResultado.Modelo = auto.Vehiculos.Modelo;

                    List<Reparacion> reparaciones = new List<Reparacion>();

                    foreach (Reparaciones r in auto.Vehiculos.Reparaciones)
                    {
                        Reparacion nR = new Reparacion();

                        nR.Id = r.Id;
                        nR.Monto = r.Monto;
                        nR.Taller = r.Taller;
                        nR.Vehiculo = r.Vehiculo;

                        reparaciones.Add(nR);
                    }

                    List<Multa> multas = new List<Multa>();

                    foreach (Multas r in auto.Vehiculos.Multas)
                    {
                        Multa nR = new Multa();

                        nR.Id = r.Id;
                        nR.Fecha = r.Fecha;
                        nR.Suma = r.Suma;
                        nR.Motivo = r.Motivo;
                        nR.Vehiculo = r.Vehiculo;

                        multas.Add(nR);
                    }

                    autoResultado.Reparaciones = reparaciones;
                    autoResultado.Multas = multas;
                }

                return autoResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el auto." + ex.Message);
            }
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
