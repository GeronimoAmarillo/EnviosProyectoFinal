using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace AdministradoresApp.Models
{
    public class DTAdelanto
    {
        public int Id { get; set; }
        public decimal Suma { get; set; }
        public int CantidadCuotas { get; set; }
        public bool Saldado { get; set; }

        public DTEmpleado Empleado { get; set; }
    }
}
