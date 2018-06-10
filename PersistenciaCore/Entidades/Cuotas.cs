namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Cuotas
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime Vencimiento { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAdelanto { get; set; }

        [Column(TypeName = "money")]
        public decimal Suma { get; set; }

        public bool Pagada { get; set; }
    }
}
