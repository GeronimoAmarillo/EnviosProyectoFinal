namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Automobiles
    {
        public int Puertas { get; set; }

        [Key]
        [StringLength(10)]
        public string MatriculaAuto { get; set; }
        [ForeignKey("MatriculaAuto")]
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
