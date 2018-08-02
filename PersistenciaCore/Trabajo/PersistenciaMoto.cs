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
    class PersistenciaMoto:IPersistenciaMoto
    {
        public bool AltaMoto(EntidadesCompartidasCore.Moto moto)
        {
            return true;
        }

        public bool ExisteMoto(string matricula)
        {
            return true;
        }

        public EntidadesCompartidasCore.Moto BuscarMoto(string matricula)
        {
            return new EntidadesCompartidasCore.Moto();
        }

        public List<EntidadesCompartidasCore.Moto> ListarMotos()
        {
            return new List<EntidadesCompartidasCore.Moto>();
        }

        public bool BajaMoto(string matricula)
        {
            return true;
        }

        public bool ModificarMoto(EntidadesCompartidasCore.Moto moto)
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

                cfg.CreateMap<Moto, Motos>()
                    .ForMember(c => c.Cilindrada, opt => opt.MapFrom(u => u.Cilindrada))
                    .ForMember(c => c.MatriculaMoto, opt => opt.MapFrom(u => u.MatriculaMoto))
                    .ForMember(c => c.Vehiculos, opt => opt.MapFrom(u => u.Vehiculos))
                ;
            });

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                Vehiculos vehiculoaModificar = Mapper.Map<Vehiculos>(moto);
                Motos motoaModificar = Mapper.Map<Motos>(moto);
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    Vehiculos vehiculoDesdeDB = dbConnection.Vehiculos.FirstOrDefault(x => x.Matricula == moto.Matricula);
                    Motos motoDesdeDb = dbConnection.Motos.FirstOrDefault(x => x.MatriculaMoto == moto.Matricula);
                    if (vehiculoDesdeDB != null && motoDesdeDb != null)
                    {
                        dbConnection.Update(vehiculoaModificar);
                        dbConnection.Update(motoaModificar);
                        dbConnection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se encontro la moto a modificar.");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar la moto: " + ex.Message);
            }
        }
    }
}
