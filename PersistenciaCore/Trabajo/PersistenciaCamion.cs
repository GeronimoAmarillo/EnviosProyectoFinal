using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return true;
        }

        public EntidadesCompartidasCore.Camion BuscarCamion(string matricula)
        {
            return new EntidadesCompartidasCore.Camion();
        }

        public bool ModificarCamion(EntidadesCompartidasCore.Camion camion)
        {
            return true;
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
