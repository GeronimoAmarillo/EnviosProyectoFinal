namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cuota
    {
        [Required]
        public DateTime Vencimiento { get; set; }
        [Required]
        public int IdAdelanto { get; set; }
        [Required]
        public decimal Suma { get; set; }
        [Required]
        public bool Pagada { get; set; }
    }
}
