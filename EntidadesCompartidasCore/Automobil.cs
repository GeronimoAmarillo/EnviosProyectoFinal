namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Automobil:Vehiculo
    {
        [Required]
        [Range(2,6)]
        public int Puertas { get; set; }
        [Required]
        [StringLength(7)]
        public string MatriculaAuto { get; set; }

        public virtual Vehiculo Vehiculos { get; set; }
    }
}
