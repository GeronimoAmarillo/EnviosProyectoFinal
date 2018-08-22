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
    class PersistenciaCamion:IPersistenciaCamion
    {
        public bool AltaCamion(EntidadesCompartidasCore.Camion camion)
        {
            try
            {
                PersistenciaCore.Camiones camionAgregar = new PersistenciaCore.Camiones();
                PersistenciaCore.Vehiculos vehiculoAgregar = new Vehiculos();

                vehiculoAgregar.Matricula = camion.Matricula;
                vehiculoAgregar.Marca = camion.Marca;
                vehiculoAgregar.Modelo = camion.Modelo;
                vehiculoAgregar.Capacidad = camion.Capacidad;
                vehiculoAgregar.Cadete = camion.Cadete;
                vehiculoAgregar.Estado = camion.Estado;


                camionAgregar.Altura = camion.Altura;
                camionAgregar.MatriculaCamion = camion.Matricula;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Vehiculos.Add(vehiculoAgregar);
                    dbConnection.Camiones.Add(camionAgregar);

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el Camion.");
            }
        }

        public List<EntidadesCompartidasCore.Camion> ListarCamiones()
        {
            try
            {
                List<Camiones> camiones = new List<Camiones>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    camiones = dbConnection.Camiones.Include("Vehiculos").ToList();
                }

                List<Camion> camionesResultado = new List<Camion>();

                foreach (Camiones m in camiones)
                {
                    Camion camionR = new Camion();

                    camionR.Matricula = m.Vehiculos.Matricula;
                    camionR.Marca = m.Vehiculos.Marca;
                    camionR.Modelo = m.Vehiculos.Modelo;
                    camionR.Capacidad = m.Vehiculos.Capacidad;
                    camionR.Cadete = m.Vehiculos.Cadete;
                    camionR.Estado = m.Vehiculos.Estado;
                    camionR.Altura = m.Altura;
                    camionR.MatriculaCamion = m.MatriculaCamion;

                    camionesResultado.Add(camionR);
                }

                return camionesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los camiones." + ex.Message);
            }
        }

        public bool BajaCamion(string matricula)
        {
            try
            {
                Camiones camion = new Camiones();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    camion = dbConnection.Camiones.Include("Vehiculos").Where(a => a.MatriculaCamion == matricula).FirstOrDefault();

                    if (camion != null)
                    {
                        dbConnection.Camiones.Remove(camion);

                        dbConnection.Vehiculos.Remove(camion.Vehiculos);

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
                throw new Exception("Error al buscar el camion." + ex.Message);
            }
        }

        public EntidadesCompartidasCore.Camion BuscarCamion(string matricula)
        {
            try
            {
                Camiones camion = new Camiones();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    camion = dbConnection.Camiones.Include("Vehiculos").Where(a => a.MatriculaCamion == matricula).FirstOrDefault();
                }

                Camion camionResultado = null;

                if (camion != null)
                {
                    camionResultado = new Camion();
                    camionResultado.Cadete = camion.Vehiculos.Cadete;
                    camionResultado.Capacidad = camion.Vehiculos.Capacidad;
                    camionResultado.Altura = camion.Altura;
                    camionResultado.Estado = camion.Vehiculos.Estado;
                    camionResultado.Marca = camion.Vehiculos.Marca;
                    camionResultado.Matricula = camion.Vehiculos.Matricula;
                    camionResultado.MatriculaCamion = camion.Vehiculos.Matricula;
                    camionResultado.Modelo = camion.Vehiculos.Modelo;
                }

                return camionResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el camion." + ex.Message);
            }
        }

        public bool ModificarCamion(EntidadesCompartidasCore.Camion camion)
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

                cfg.CreateMap<Camion, Camiones>()
                    .ForMember(c => c.Altura, opt => opt.MapFrom(u => u.Altura))
                    .ForMember(c => c.MatriculaCamion, opt => opt.MapFrom(u => u.MatriculaCamion))
                    .ForMember(c => c.Vehiculos, opt => opt.MapFrom(u => u.Vehiculos))
                ;
            });

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                Vehiculos vehiculoaModificar = Mapper.Map<Vehiculos>(camion);
                Camiones camionaModificar = Mapper.Map<Camiones>(camion);
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    Vehiculos vehiculoDesdeDB = dbConnection.Vehiculos.FirstOrDefault(x => x.Matricula == camion.Matricula);
                    Camiones camionDesdeDb = dbConnection.Camiones.FirstOrDefault(x => x.MatriculaCamion == camion.Matricula);
                    if (vehiculoDesdeDB != null && camionDesdeDb != null)
                    {
                        dbConnection.Update(vehiculoaModificar);
                        dbConnection.Update(camionaModificar);
                        dbConnection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se encontro el camion a modificar.");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el camion: " + ex.Message);
            }
        }

        public bool ExisteCamion(string matricula)
        {
            try
            {
                bool existe = false;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var camion = dbConnection.Camiones.Where(l => l.MatriculaCamion == matricula).Select(c => new {
                        Camion = c
                    }).FirstOrDefault();

                    if (camion != null && camion.Camion is Camiones)
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
