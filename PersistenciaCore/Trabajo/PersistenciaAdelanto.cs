using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    public class PersistenciaAdelanto:IPersistenciaAdelanto
    {
        public bool RealizarAdelanto(EntidadesCompartidasCore.Adelanto adelanto)
        {
            try
            {
                PersistenciaCore.Adelantos adelantoAgregar = new PersistenciaCore.Adelantos();

                adelantoAgregar.CantidadCuotas = adelanto.CantidadCuotas;
                adelantoAgregar.Empleado = adelanto.Empleado;
                adelantoAgregar.Id = adelanto.Id;
                adelantoAgregar.Saldado = adelanto.Saldado;
                adelantoAgregar.Suma = adelanto.Suma;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Adelantos.Add(adelantoAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el Adelanto.");
            }
        }

        public bool VerificarAdelantoSaldado(int cedula)
        {
            try
            {
                bool adelantoSaldado = true;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var adelanto = dbConnection.Adelantos.Include("Empleados.Usuarios").Where(a => a.Empleado == cedula).FirstOrDefault();

                    int mesActual = DateTime.Now.Month;
                    int anioActual = DateTime.Now.Year;

                    int mesCalculado;
                    int anioCalculado;

                    int mesExpedido = adelanto.fechaExpedido.Month;
                    int anioExpedido = adelanto.fechaExpedido.Year;

                    int cuotas = adelanto.CantidadCuotas;

                    if ((mesExpedido + cuotas) >= 12)
                    {
                        mesCalculado = (mesExpedido + cuotas) - 12;
                        anioCalculado = anioExpedido + 1;
                    }
                    else
                    {
                        mesCalculado = mesExpedido + cuotas;
                        anioCalculado = anioExpedido;
                    }

                    if (mesActual < mesCalculado && anioActual == anioCalculado)
                    {
                        adelantoSaldado = false;
                    }

                    return adelantoSaldado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la habilitacion para solicitar Adelanto.");
            }
        }

        public List<Adelanto> ListarAdelantos()
        {
            try
            {
                List<Adelantos> adelantos = new List<Adelantos>();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    adelantos = dbConnection.Adelantos.Include("Empleados.Usuarios").ToList();
                }

                List<Adelanto> adelantosResultado = new List<Adelanto>();

                foreach (Adelantos a in adelantos)
                {
                    Adelanto adelantoR = new Adelanto();

                    adelantoR.Id = a.Id;
                    adelantoR.CantidadCuotas = a.CantidadCuotas;
                    adelantoR.Empleado = a.Empleado;
                    adelantoR.Empleados = ConvertirEmpleado(a.Empleados);
                    adelantoR.Saldado = a.Saldado;
                    adelantoR.Suma = a.Suma;


                    adelantosResultado.Add(adelantoR);
                }

                return adelantosResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los adelantos." + ex.Message);
            }
        }

        public Empleado ConvertirEmpleado(Empleados emp)
        {
            try
            {
                Empleado empR = new Empleado();

                empR.Ci = emp.Ci;
                empR.Direccion = emp.Usuarios.Direccion;
                empR.Email = emp.Usuarios.Email;
                empR.Id = emp.Usuarios.Id;
                empR.Nombre = emp.Usuarios.Nombre;
                empR.NombreUsuario = emp.Usuarios.NombreUsuario;
                empR.Sueldo = emp.Sueldo;
                empR.Telefono = emp.Usuarios.Telefono;

                return empR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir el Empleado." + ex.Message);
            }
        }
    }
}
