using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTReparacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Taller { get; set; }
        public decimal Monto { get; set; }

        public DTVehiculo Vehiculo { get; set; }
    }
}
