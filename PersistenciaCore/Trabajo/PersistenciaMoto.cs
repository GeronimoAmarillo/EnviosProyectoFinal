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

                motoAgregar.Vehiculos = vehiculoAgregar;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
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
                    moto = dbConnection.Motos.Include("Vehiculos.Reparaciones").Include("Vehiculos.Multas").Where(a => a.MatriculaMoto == matricula).FirstOrDefault();
                }

                Moto motoResultado = null;

                if (moto != null)
                {

                    motoResultado = new Moto();

                    motoResultado.Cadete = moto.Vehiculos.Cadete;
                    motoResultado.Capacidad = moto.Vehiculos.Capacidad;
                    motoResultado.Cilindrada = moto.Cilindrada;
                    motoResultado.Estado = moto.Vehiculos.Estado;
                    motoResultado.Marca = moto.Vehiculos.Marca;
                    motoResultado.Matricula = moto.Vehiculos.Matricula;
                    motoResultado.MatriculaMoto = moto.Vehiculos.Matricula;
                    motoResultado.Modelo = moto.Vehiculos.Modelo;

                    List<Reparacion> reparaciones = new List<Reparacion>();

                    foreach (Reparaciones r in moto.Vehiculos.Reparaciones)
                    {
                        Reparacion nR = new Reparacion();

                        nR.Id = r.Id;
                        nR.Monto = r.Monto;
                        nR.Taller = r.Taller;
                        nR.Vehiculo = r.Vehiculo;

                        reparaciones.Add(nR);
                    }


                    List<Multa> multas = new List<Multa>();

                    foreach (Multas r in moto.Vehiculos.Multas)
                    {
                        Multa nR = new Multa();

                        nR.Id = r.Id;
                        nR.Fecha = r.Fecha;
                        nR.Suma = r.Suma;
                        nR.Motivo = r.Motivo;
                        nR.Vehiculo = r.Vehiculo;

                        multas.Add(nR);
                    }

                    motoResultado.Multas = multas;

                    motoResultado.Reparaciones = reparaciones;
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

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            Vehiculos vehiculoaModificar = new Vehiculos()
            {
                Matricula = moto.Matricula,
                Marca = moto.Marca,
                Modelo = moto.Modelo,
                Capacidad = moto.Capacidad,
                Estado = moto.Estado,
                Cadete = moto.Cadete
            };

            Motos motoaModificar = new Motos()
            {
                Cilindrada = moto.Cilindrada,
                MatriculaMoto = moto.Matricula,
                Vehiculos = vehiculoaModificar
            };

            try
            {
                
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    int vehiculoDesdeDB = (dbConnection.Vehiculos.Where(x => x.Matricula == moto.Matricula)).Count();
                    int motoDesdeDb = (dbConnection.Motos.Where(x => x.MatriculaMoto == moto.Matricula)).Count();
                    if (vehiculoDesdeDB == 1 && motoDesdeDb == 1)
                    {
                        dbConnection.Motos.Update(motoaModificar);

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
