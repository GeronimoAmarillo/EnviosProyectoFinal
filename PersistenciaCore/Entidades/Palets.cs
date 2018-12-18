namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Palets
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Producto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Peso { get; set; }
        [Required]
        public int Casilla { get; set; }
        [Key]
        [Required]
        public long Cliente { get; set; }
        [Required]
        public bool Eliminado { get; set; }
        public DateTime? fechaIngreso { get; set; }
        public DateTime? fechaSalida { get; set; }

        public virtual Casillas Casillas { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
