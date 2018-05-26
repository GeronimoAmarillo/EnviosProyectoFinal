namespace Persistencia
{
    using System;
    using System.Collections.Generic;

    public partial class Adelantos
    {
        public int Id { get; set; }
        
        public int Empleado { get; set; }
        
        public decimal Suma { get; set; }

        public int CantidadCuotas { get; set; }

        public bool Saldado { get; set; }

        public Empleados Empleados { get; set; }
    }
}
