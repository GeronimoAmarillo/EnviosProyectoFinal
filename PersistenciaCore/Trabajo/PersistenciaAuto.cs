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
            return true;
        }

        public List<EntidadesCompartidasCore.Automobil> ListarAutos()
        {
            return new List<EntidadesCompartidasCore.Automobil>();
        }

        public bool BajaAuto(string matricula)
        {
            return true;
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
            return new EntidadesCompartidasCore.Automobil();
        }

        public bool ExisteAuto(string matricula)
        {
            return true;
        }
    }
}
