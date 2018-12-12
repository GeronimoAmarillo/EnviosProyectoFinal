namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Adelanto
    {
        [Required]
        public int Id { get; set; }

        public DateTime fechaExpedido { get; set; }

        [Required]
        public int Empleado { get; set; }

        [Required]
        [Range(100, Double.MaxValue)]
        public decimal Suma { get; set; }

        [Required]
        [Range(1, 12)]
        public int CantidadCuotas { get; set; }

        [Required]
        public bool Saldado { get; set; }

        public  Empleado Empleados { get; set; }
    }
}
