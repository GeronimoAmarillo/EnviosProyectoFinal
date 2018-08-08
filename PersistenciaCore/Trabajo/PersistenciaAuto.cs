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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Vehiculo, Vehiculos>()
                    .ForMember(v => v.Matricula, opt => opt.MapFrom(u => u.Matricula))
                    .ForMember(v => v.Marca, opt => opt.MapFrom(u => u.Marca))
                    .ForMember(v => v.Modelo, opt => opt.MapFrom(u => u.Modelo))
                    .ForMember(v => v.Capacidad, opt => opt.MapFrom(u => u.Capacidad))
                    .ForMember(v => v.Estado, opt => opt.MapFrom(u => u.Estado))
                    .ForMember(v => v.Cadete, opt => opt.MapFrom(u => u.Cadete))
                    .ForMember(v => v.Automobiles, opt => opt.MapFrom(u => u.Automobiles))
                    .ForMember(v => v.Cadetes, opt => opt.MapFrom(u => u.Cadetes))
                    .ForMember(v => v.Camiones, opt => opt.MapFrom(u => u.Camiones))
                    .ForMember(v => v.Camionetas, opt => opt.MapFrom(u => u.Camionetas))
                    .ForMember(v => v.Motos, opt => opt.MapFrom(u => u.Motos))
                    .ForMember(v => v.Multas, opt => opt.MapFrom(u => u.Multas))
                    .ForMember(v => v.Reparaciones, opt => opt.MapFrom(u => u.Reparaciones))
                ;

                cfg.CreateMap<Automobil, Automobiles>()
                    .ForMember(a => a.Puertas, opt => opt.MapFrom(u => u.Puertas))
                    .ForMember(a => a.MatriculaAuto, opt => opt.MapFrom(u => u.MatriculaAuto))
                    .ForMember(a => a.Vehiculos, opt => opt.MapFrom(u => u.Vehiculos))
                ;
            });

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                Vehiculos vehiculoaModificar = Mapper.Map<Vehiculos>(auto);
                Automobiles autoaModificar = Mapper.Map<Automobiles>(auto);
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    Vehiculos vehiculoDesdeDB = dbConnection.Vehiculos.FirstOrDefault(x => x.Matricula == auto.Matricula);
                    Automobiles autoDesdeDb = dbConnection.Automobiles.FirstOrDefault(x => x.MatriculaAuto == auto.Matricula);
                    if (vehiculoDesdeDB != null && autoDesdeDb != null)
                    {
                        dbConnection.Update(vehiculoaModificar);
                        dbConnection.Update(autoaModificar);
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
                    auto = dbConnection.Automobiles.Include("Vehiculos").Where(a => a.MatriculaAuto == matricula).FirstOrDefault();
                }

                Automobil autoResultado = new Automobil();

                if (auto != null)
                {

                    autoResultado.Cadete = auto.Vehiculos.Cadete;
                    autoResultado.Capacidad = auto.Vehiculos.Capacidad;
                    autoResultado.Puertas = auto.Puertas;
                    autoResultado.Estado = auto.Vehiculos.Estado;
                    autoResultado.Marca = auto.Vehiculos.Marca;
                    autoResultado.Matricula = auto.Vehiculos.Matricula;
                    autoResultado.MatriculaAuto = auto.Vehiculos.Matricula;
                    autoResultado.Modelo = auto.Vehiculos.Modelo;
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
