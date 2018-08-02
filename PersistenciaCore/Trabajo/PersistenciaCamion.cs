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
            return true;
        }

        public List<EntidadesCompartidasCore.Camion> ListarCamiones()
        {
            return new List<EntidadesCompartidasCore.Camion>();
        }

        public bool BajaCamion(string matricula)
        {
            return true;
        }

        public EntidadesCompartidasCore.Camion BuscarCamion(string matricula)
        {
            return new EntidadesCompartidasCore.Camion();
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
            return true;
        }
    }
}
