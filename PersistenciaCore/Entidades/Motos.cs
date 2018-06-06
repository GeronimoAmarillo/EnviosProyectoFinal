namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Motos
    {
        public decimal Cilindrada { get; set; }

        [Key]
        [StringLength(10)]
        public string MatriculaMoto { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }
    }
}
