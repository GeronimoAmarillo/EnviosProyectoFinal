namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Multa
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Vehiculo { get; set; }
        [Required]
        [Range(100, Double.MaxValue)]
        public decimal Suma { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [MinLength(4)]
        public string Motivo { get; set; }

        public Vehiculo Vehiculos { get; set; }
    }
}
