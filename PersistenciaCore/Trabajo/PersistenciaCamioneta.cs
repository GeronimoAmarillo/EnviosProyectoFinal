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
            try
            {
                PersistenciaCore.Camionetas camionetaAgregar = new PersistenciaCore.Camionetas();
                PersistenciaCore.Vehiculos vehiculoAgregar = new Vehiculos();

                vehiculoAgregar.Matricula = camioneta.Matricula;
                vehiculoAgregar.Marca = camioneta.Marca;
                vehiculoAgregar.Modelo = camioneta.Modelo;
                vehiculoAgregar.Capacidad = camioneta.Capacidad;
                vehiculoAgregar.Cadete = camioneta.Cadete;
                vehiculoAgregar.Estado = camioneta.Estado;


                camionetaAgregar.Cabina = camioneta.Cabina;
                camionetaAgregar.MatriculaCamioneta = camioneta.Matricula;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Vehiculos.Add(vehiculoAgregar);
                    dbConnection.Camionetas.Add(camionetaAgregar);

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta la Camioneta.");
            }
        }

        public List<EntidadesCompartidasCore.Camioneta> ListarCamionetas()
        {
            try
            {
                List<Camionetas> camionetas = new List<Camionetas>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    camionetas = dbConnection.Camionetas.Include("Vehiculos").ToList();
                }

                List<Camioneta> camionetasResultado = new List<Camioneta>();

                foreach (Camionetas m in camionetas)
                {
                    Camioneta camionetaR = new Camioneta();

                    camionetaR.Matricula = m.Vehiculos.Matricula;
                    camionetaR.Marca = m.Vehiculos.Marca;
                    camionetaR.Modelo = m.Vehiculos.Modelo;
                    camionetaR.Capacidad = m.Vehiculos.Capacidad;
                    camionetaR.Cadete = m.Vehiculos.Cadete;
                    camionetaR.Estado = m.Vehiculos.Estado;
                    camionetaR.Cabina = m.Cabina;
                    camionetaR.MatriculaCamioneta = m.MatriculaCamioneta;

                    camionetasResultado.Add(camionetaR);
                }

                return camionetasResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las camionetas." + ex.Message);
            }
        }

        public bool BajaCamioneta(string matricula)
        {
            return true;
        }

        public bool ModificarCamioneta(EntidadesCompartidasCore.Camioneta camioneta)
        {
            

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                Vehiculos vehiculoaModificar = new Vehiculos()
                {
                    Matricula = camioneta.Matricula,
                    Marca = camioneta.Marca,
                    Modelo = camioneta.Modelo,
                    Capacidad = camioneta.Capacidad,
                    Estado = camioneta.Estado,
                    Cadete = camioneta.Cadete
                };

                Camionetas camionetaaModificar = new Camionetas()
                {
                    Cabina = camioneta.Cabina,
                    MatriculaCamioneta = camioneta.Matricula,
                    Vehiculos = vehiculoaModificar
                };

                camionetaaModificar.Vehiculos = vehiculoaModificar;
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    int vehiculoDesdeDB = (dbConnection.Vehiculos.Where(x => x.Matricula == camioneta.Matricula)).Count();
                    int camionetaDesdeDb = (dbConnection.Camionetas.Where(x => x.MatriculaCamioneta == camioneta.Matricula)).Count();
                    if (vehiculoDesdeDB == 1 && camionetaDesdeDb == 1)
                    {
                        dbConnection.Camionetas.Update(camionetaaModificar);
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
            try
            {
                bool existe = false;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var camioneta = dbConnection.Camionetas.Where(l => l.MatriculaCamioneta == matricula).Select(c => new {
                        Camioneta = c
                    }).FirstOrDefault();

                    if (camioneta != null && camioneta.Camioneta is Camionetas)
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
