namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Moto:Vehiculo
    {
        [Required]
        [Range(50, 1000)]
        public decimal Cilindrada { get; set; }
        [Required]
        [StringLength(7)]
        public string MatriculaMoto { get; set; }

        public virtual Vehiculo Vehiculos { get; set; }
    }
}
