namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Palet
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Producto { get; set; }

        [Required]
        [Range(1, 20000)]
        public int Cantidad { get; set; }
        [Required]
        [Range(1, 1500)]
        public decimal Peso { get; set; }
        
        public int Casilla { get; set; }

        public long Cliente { get; set; }

        public Casilla Casillas { get; set; }

        public Cliente Clientes { get; set; }
    }
}
