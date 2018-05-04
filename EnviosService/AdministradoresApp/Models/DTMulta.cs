using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTMulta
    {
        public int Id { get; set; }
        public decimal Suma { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }

        public DTVehiculo Vehiculo { get; set; }
    }
}
