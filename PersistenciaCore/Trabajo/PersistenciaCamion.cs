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

                camionAgregar.Vehiculos = vehiculoAgregar;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
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
                    camion = dbConnection.Camiones.Include("Vehiculos.Reparaciones").Include("Vehiculos.Multas").Where(a => a.MatriculaCamion == matricula).FirstOrDefault();
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

                    List<Reparacion> reparaciones = new List<Reparacion>();

                    foreach (Reparaciones r in camion.Vehiculos.Reparaciones)
                    {
                        Reparacion nR = new Reparacion();

                        nR.Id = r.Id;
                        nR.Monto = r.Monto;
                        nR.Taller = r.Taller;
                        nR.Vehiculo = r.Vehiculo;

                        reparaciones.Add(nR);
                    }

                    List<Multa> multas = new List<Multa>();

                    foreach (Multas r in camion.Vehiculos.Multas)
                    {
                        Multa nR = new Multa();

                        nR.Id = r.Id;
                        nR.Fecha = r.Fecha;
                        nR.Suma = r.Suma;
                        nR.Motivo = r.Motivo;
                        nR.Vehiculo = r.Vehiculo;

                        multas.Add(nR);
                    }

                    camionResultado.Multas = multas;

                    camionResultado.Reparaciones = reparaciones;
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
            Vehiculos vehiculoaModificar = new Vehiculos()
            {
                Matricula = camion.Matricula,
                Marca = camion.Marca,
                Modelo = camion.Modelo,
                Capacidad = camion.Capacidad,
                Estado = camion.Estado,
                Cadete = camion.Cadete
            };

            Camiones camionaModificar = new Camiones()
            {
                Altura = camion.Altura,
                MatriculaCamion = camion.Matricula,
                Vehiculos = vehiculoaModificar
            };
            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    int vehiculoDesdeDB = (dbConnection.Vehiculos.Where(x => x.Matricula == camion.Matricula)).Count();
                    int camionDesdeDb = (dbConnection.Camiones.Where(x => x.MatriculaCamion == camion.Matricula)).Count();

                    if (vehiculoDesdeDB == 1 && camionDesdeDb == 1)
                    {
                        dbConnection.Camiones.Update(camionaModificar);

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
