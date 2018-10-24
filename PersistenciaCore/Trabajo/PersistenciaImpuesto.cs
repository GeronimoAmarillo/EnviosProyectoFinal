using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaImpuesto:IPersistenciaImpuesto
    {
        public bool RegistrarImpuesto(EntidadesCompartidasCore.Impuesto impuesto)
        {
            try
            {
                Impuestos impuestoAgregar = new Impuestos();

                impuestoAgregar.Nombre = impuesto.Nombre;
                impuestoAgregar.Descripcion = impuesto.Descripcion;
                impuestoAgregar.Porcentaje = impuesto.Porcentaje;
                impuestoAgregar.Id = 0;
                impuestoAgregar.fechaRegistro = impuesto.fechaRegistro;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Impuestos.Add(impuestoAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el impuesto.");
            }
        }

        public List<EntidadesCompartidasCore.Impuesto> ListarImpuestos()
        {
            try
            {
                List<Impuestos> impuestos = new List<Impuestos>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    impuestos = dbConnection.Impuestos.ToList();
                }

                List<Impuesto> impustosResultado = new List<Impuesto>();

                foreach (Impuestos g in impuestos)
                {
                    Impuesto impuestoR = new Impuesto();

                    impuestoR.Id = g.Id;
                    impuestoR.Nombre = g.Nombre;
                    impuestoR.Descripcion = g.Descripcion;
                    impuestoR.Porcentaje = g.Porcentaje;
                    impuestoR.fechaRegistro = g.fechaRegistro;

                    impustosResultado.Add(impuestoR);
                }

                return impustosResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los impuestos." + ex.Message);
            }
        }
    }
}
