namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    [Table("Reclamo")]
    public partial class Reclamo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Comentario { get; set; }
        
        public int Paquete { get; set; }
        
        public virtual Paquetes Paquetes { get; set; }
        
        public virtual Paquetes Paquetes1 { get; set; }
    }
}
