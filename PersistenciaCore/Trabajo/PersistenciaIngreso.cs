using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaIngreso:IPersistenciaIngreso
    {
        public List<EntidadesCompartidasCore.Ingreso> ListarIngresos()
        {
            try
            {
                List<Ingresos> ingresos = new List<Ingresos>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    ingresos = dbConnection.Ingresos.ToList();
                }

                List<Ingreso> ingresosResultado = new List<Ingreso>();

                foreach (Ingresos g in ingresos)
                {
                    Ingreso ingresoR = new Ingreso();

                    ingresoR.Id = g.Id;
                    ingresoR.Suma = g.Suma;
                    ingresoR.Descripcion = g.Descripcion;

                    ingresosResultado.Add(ingresoR);
                }

                return ingresosResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los ingresos." + ex.Message);
            }
        }

        public bool RegistrarIngreso(EntidadesCompartidasCore.Ingreso ingreso)
        {
            try
            {
                Ingresos ingresoAgregar = new Ingresos();

                ingresoAgregar.Suma = ingreso.Suma;
                ingresoAgregar.Descripcion = ingreso.Descripcion;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Ingresos.Add(ingresoAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el ingreso.");
            }
        }
    }
}
