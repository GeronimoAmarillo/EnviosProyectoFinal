namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Ingreso
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Descripcion { get; set; }
        [Required]
        public decimal Suma { get; set; }
    }
}
