namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Ingresos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Suma { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime fechaRegistro { get; set; }

        public long? RUT { get; set; }
        
        [ForeignKey("RUT")]
        public virtual Clientes Clientes { get; set; }
    }
}
