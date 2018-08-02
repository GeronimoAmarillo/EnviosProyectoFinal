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
    class PersistenciaCamioneta : IPersistenciaCamioneta
    {
        public bool AltaCamioneta(EntidadesCompartidasCore.Camioneta camioneta)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Camioneta> ListarCamionetas()
        {
            return new List<EntidadesCompartidasCore.Camioneta>();
        }

        public bool BajaCamioneta(string matricula)
        {
            return true;
        }

        public bool ModificarCamioneta(EntidadesCompartidasCore.Camioneta camioneta)
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

                cfg.CreateMap<Camioneta, Camionetas>()
                    .ForMember(c => c.Cabina, opt => opt.MapFrom(u => u.Cabina))
                    .ForMember(c => c.MatriculaCamioneta, opt => opt.MapFrom(u => u.MatriculaCamioneta))
                    .ForMember(c => c.Vehiculos, opt => opt.MapFrom(u => u.Vehiculos))
                ;
            });

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                Vehiculos vehiculoaModificar = Mapper.Map<Vehiculos>(camioneta);
                Camionetas camionetaaModificar = Mapper.Map<Camionetas>(camioneta);
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    Vehiculos vehiculoDesdeDB = dbConnection.Vehiculos.FirstOrDefault(x => x.Matricula == camioneta.Matricula);
                    Camionetas camionetaDesdeDb = dbConnection.Camionetas.FirstOrDefault(x => x.MatriculaCamioneta == camioneta.Matricula);
                    if (vehiculoDesdeDB != null && camionetaDesdeDb != null)
                    {
                        dbConnection.Update(vehiculoaModificar);
                        dbConnection.Update(camionetaaModificar);
                        dbConnection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se encontro la camioneta a modificar.");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar la camioneta: " + ex.Message);
            }
        }

        public EntidadesCompartidasCore.Camioneta BuscarCamioneta(string matricula)
        {
            return new EntidadesCompartidasCore.Camioneta();
        }

        public bool ExisteCamioneta(string matricula)
        {
            return true;
        }
    }
}
