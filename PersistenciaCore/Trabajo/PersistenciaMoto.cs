using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return new EntidadesCompartidasCore.Moto();
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
            return true;
        }

        public bool ModificarMoto(EntidadesCompartidasCore.Moto moto)
        {
            return true;
        }
    }
}
