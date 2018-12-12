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
        [MinLength(5, ErrorMessage = "debe ingresar una descripcion un poco mas descriptiva")]
        [MaxLength(500, ErrorMessage = "debe ingresar una descripcion mas simple")]
        public string Descripcion { get; set; }

        [Required]
        public bool Extra { get; set; }

        [Required]
        public decimal Suma { get; set; }
        [Required]
        public DateTime fechaRegistro { get; set; }
    }
}
