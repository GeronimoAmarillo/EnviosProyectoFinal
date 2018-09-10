namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Registro
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal UtilidadBruta { get; set; }
        [Required]
        public decimal UtilidadOperacional { get; set; }
        [Required]
        public decimal UtilidadSinImpuestos { get; set; }
        [Required]
        public decimal UtilidadEjercicio { get; set; }
        [Required]
        public int BalanceId { get; set; }

        public Balance Balances { get; set; }
    }
}
