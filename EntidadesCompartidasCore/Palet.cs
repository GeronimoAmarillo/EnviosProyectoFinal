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
        [MinLength(2, ErrorMessage = "debe ingresar una descripcion un poco mas descriptiva")]
        [MaxLength(100, ErrorMessage = "debe ingresar una descripcion un poco mas simple")]
        public string Producto { get; set; }

        [Required]
        [Range(1, 20000)]
        public int Cantidad { get; set; }
        [Required]
        [Range(1, 1500)]
        public decimal Peso { get; set; }
        
        public int Casilla { get; set; }

        public long Cliente { get; set; }
        public bool Eliminado { get; set; }
        public DateTime? fechaIngreso { get; set; }
        public DateTime? fechaSalida { get; set; }
        public Casilla Casillas { get; set; }

        public Cliente Clientes { get; set; }
    }
}
