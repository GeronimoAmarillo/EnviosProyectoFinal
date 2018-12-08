namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Registro
    {
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
        

        public List<Ingreso> Ingresos { get; set; }

        public List<Gasto> Gastos { get; set; }

        public List<Impuesto> Impuestos { get; set; }
    }
}
