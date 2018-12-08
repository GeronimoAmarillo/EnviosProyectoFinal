namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Balance
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        [Range(1900, 3000)]
        public int Año { get; set; }
        [Required]
        public bool Abierto { get; set; }

        public decimal UtilidadBrutaTotal { get; set; }

        public decimal UtilidadOperacionalTotal { get; set; }

        public decimal Ingresos { get; set; }

        public decimal IngresosExtra { get; set; }

        public decimal Gastos { get; set; }

        public decimal GastosExtra { get; set; }

        public decimal UtilidadSinimpuestosTotal { get; set; }

        public decimal UtilidadEjercicioTotal { get; set; }

        public List<Registro> Registros { get; set; }
    }
}
