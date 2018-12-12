namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Camion : Vehiculo
    {
        [Required]
        public decimal Altura { get; set; }
        [Required]
        [StringLength(7, ErrorMessage = "la matricula debe poseer 7 caracteres")]
        public string MatriculaCamion { get; set; }

        public  Vehiculo Vehiculos { get; set; }
    }
}
