namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Camioneta:Vehiculo
    {
        [Required]
        public string Cabina { get; set; }
        [Required]
        [StringLength(7, ErrorMessage = "la matricula debe poseer 7 caracteres")]
        public string MatriculaCamioneta { get; set; }

        public Vehiculo Vehiculos { get; set; }
    }
}
