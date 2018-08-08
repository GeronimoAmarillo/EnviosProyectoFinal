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
            try
            {
                PersistenciaCore.Motos motoAgregar = new PersistenciaCore.Motos();
                PersistenciaCore.Vehiculos vehiculoAgregar = new Vehiculos();

                vehiculoAgregar.Matricula = moto.Matricula;
                vehiculoAgregar.Marca = moto.Marca;
                vehiculoAgregar.Modelo = moto.Modelo;
                vehiculoAgregar.Capacidad = moto.Capacidad;
                vehiculoAgregar.Cadete = moto.Cadete;
                vehiculoAgregar.Estado = moto.Estado;


                motoAgregar.Cilindrada = moto.Cilindrada;
                motoAgregar.MatriculaMoto = moto.Matricula;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Vehiculos.Add(vehiculoAgregar);
                    dbConnection.Motos.Add(motoAgregar);

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta la Moto.");
            }
        }

        public bool ExisteMoto(string matricula)
        {
            try
            {
                bool existe = false;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var moto = dbConnection.Motos.Where(l => l.MatriculaMoto == matricula).Select(c => new {
                        Moto = c
                    }).FirstOrDefault();

                    if (moto != null && moto.Moto is Motos)
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

        public EntidadesCompartidasCore.Moto BuscarMoto(string matricula)
        {
            try
            {
                Motos moto = new Motos();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    moto = dbConnection.Motos.Include("Vehiculos").Where(a => a.MatriculaMoto == matricula).FirstOrDefault();
                }

                Moto motoResultado = new Moto();

                if (moto != null)
                {

                    motoResultado.Cadete = moto.Vehiculos.Cadete;
                    motoResultado.Capacidad = moto.Vehiculos.Capacidad;
                    motoResultado.Cilindrada = moto.Cilindrada;
                    motoResultado.Estado = moto.Vehiculos.Estado;
                    motoResultado.Marca = moto.Vehiculos.Marca;
                    motoResultado.Matricula = moto.Vehiculos.Matricula;
                    motoResultado.MatriculaMoto = moto.Vehiculos.Matricula;
                    motoResultado.Modelo = moto.Vehiculos.Modelo;
                }

                return motoResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la moto." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Moto> ListarMotos()
        {
            try
            {
                List<Motos> motos = new List<Motos>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    motos = dbConnection.Motos.Include("Vehiculos").ToList();
                }

                List<Moto> motosResultado = new List<Moto>();

                foreach (Motos m in motos)
                {
                    Moto motoR = new Moto();

                    motoR.Matricula = m.Vehiculos.Matricula;
                    motoR.Marca = m.Vehiculos.Marca;
                    motoR.Modelo = m.Vehiculos.Modelo;
                    motoR.Capacidad = m.Vehiculos.Capacidad;
                    motoR.Cadete = m.Vehiculos.Cadete;
                    motoR.Estado = m.Vehiculos.Estado;
                    motoR.Cilindrada = m.Cilindrada;
                    motoR.MatriculaMoto = m.MatriculaMoto;

                    motosResultado.Add(motoR);
                }

                return motosResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las motos." + ex.Message);
            }
        }

        public bool BajaMoto(string matricula)
        {
            try
            {
                Motos moto = new Motos();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    moto = dbConnection.Motos.Include("Vehiculos").Where(a => a.MatriculaMoto == matricula).FirstOrDefault();

                    if (moto != null)
                    {
                        dbConnection.Motos.Remove(moto);

                        dbConnection.Vehiculos.Remove(moto.Vehiculos);

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
                throw new Exception("Error al eliminar la moto." + ex.Message);
            }
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
