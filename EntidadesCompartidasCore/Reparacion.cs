namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Reparacion
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Descripcion { get; set; }
        [Required]
        [MinLength(2)]
        public string Taller { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        [StringLength(7)]
        public string Vehiculo { get; set; }

        public Vehiculo Vehiculos { get; set; }
    }
}
