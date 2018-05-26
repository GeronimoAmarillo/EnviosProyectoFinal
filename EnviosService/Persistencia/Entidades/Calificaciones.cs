namespace Persistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Calificaciones
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        public int Puntaje { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RutCliente { get; set; }

        [Required]
        [StringLength(250)]
        public string Comentario { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
