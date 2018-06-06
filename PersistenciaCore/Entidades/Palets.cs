namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Palets
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal Peso { get; set; }

        public int Casilla { get; set; }

        public long Cliente { get; set; }

        public virtual Casillas Casillas { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
