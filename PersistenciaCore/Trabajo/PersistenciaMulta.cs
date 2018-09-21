using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaMulta:IPersistenciaMulta
    {
        public bool RegistrarMulta(Multa multa)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                Multas multaaAgregar = new Multas()
                {
                    Id= multa.Id,
                    Vehiculo = multa.Vehiculo,
                    Suma = multa.Suma,
                    Fecha = multa.Fecha,
                    Motivo = multa.Motivo
                };

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var ultimoRegistro = dbConnection.Multas.OrderByDescending(x => x.Id).FirstOrDefault();

                    if (ultimoRegistro == null)
                    {
                        multaaAgregar.Id = 1;
                    }
                    else
                    {
                        multaaAgregar.Id = ultimoRegistro.Id + 1;
                    }

                    dbConnection.Multas.Add(multaaAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar agregar la multa: " + ex.Message);
            }
            
        }
    }
}
