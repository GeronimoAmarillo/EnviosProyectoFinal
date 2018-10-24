namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Gasto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Descripcion { get; set; }
        [Required]
        public decimal Suma { get; set; }
        [Required]
        public DateTime fechaRegistro { get; set; }
    }
}
