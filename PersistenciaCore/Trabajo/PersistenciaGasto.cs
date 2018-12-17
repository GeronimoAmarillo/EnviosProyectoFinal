using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaGasto:IPersistenciaGasto
    {
        public bool RegistrarGasto(EntidadesCompartidasCore.Gasto gasto)
        {
            try
            {
                Gastos gastoAgregar = new Gastos();

                gastoAgregar.Suma = gasto.Suma;
                gastoAgregar.Descripcion = gasto.Descripcion;
                gastoAgregar.fechaRegistro = DateTime.Now;
                gastoAgregar.Extra = gasto.Extra;
                gastoAgregar.Extra = gastoAgregar.Extra;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Gastos.Add(gastoAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el gasto.");
            }
        }

        public List<EntidadesCompartidasCore.Gasto> ListarGastos()
        {
            try
            {
                List<Gastos> gastos = new List<Gastos>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    gastos = dbConnection.Gastos.ToList();
                }

                List<Gasto> gastosResultado = new List<Gasto>();

                foreach (Gastos g in gastos)
                {
                    Gasto gastoR = new Gasto();

                    gastoR.Id = g.Id;
                    gastoR.Suma = g.Suma;
                    gastoR.Descripcion = g.Descripcion;
                    gastoR.fechaRegistro = g.fechaRegistro;
                    gastoR.Extra = g.Extra;

                    gastosResultado.Add(gastoR);
                }

                return gastosResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los gastos." + ex.Message);
            }
        }
    }
}
