namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Impuesto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Descripcion { get; set; }
        [Required]
        public decimal Porcentaje { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Nombre { get; set; }
        [Required]
        public DateTime fechaRegistro { get; set; }
    }
}
