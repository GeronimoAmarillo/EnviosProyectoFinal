namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    public partial class Adelantos
    {
        public int Id { get; set; }

        public DateTime fechaExpedido { get; set; }
        
        public int Empleado { get; set; }
        
        public decimal Suma { get; set; }

        public int CantidadCuotas { get; set; }

        public bool Saldado { get; set; }

        public Empleados Empleados { get; set; }
    }
}
