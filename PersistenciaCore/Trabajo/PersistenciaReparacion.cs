using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaReparacion:IPersistenciaReparacion
    {
        public bool RegistrarReparacion(Reparacion reparacion)
        {
            try
            {
                Reparaciones reparacionAgregar = new Reparaciones();

                reparacionAgregar.Descripcion = reparacion.Descripcion;
                reparacionAgregar.Id = reparacion.Id;
                reparacionAgregar.Monto = reparacion.Monto;
                reparacionAgregar.Taller = reparacion.Taller;
                reparacionAgregar.Vehiculo = reparacion.Vehiculo;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Reparaciones.Add(reparacionAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la reparación." + ex.Message);
            }
        }
    }
}
