namespace Persistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Automobiles
    {
        public int Puertas { get; set; }

        [Key]
        [StringLength(10)]
        public string MatriculaAuto { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }
    }
}
