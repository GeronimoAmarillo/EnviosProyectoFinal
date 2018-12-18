namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Paquetes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paquetes()
        {
            Reclamo = new HashSet<Reclamo>();
            Reclamo1 = new HashSet<Reclamo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumReferencia { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; }

        [Required]
        [StringLength(15)]
        public string Estado { get; set; }

        [Required]
        [StringLength(100)]
        public string Ubicacion { get; set; }

        public int? Entrega { get; set; }

        public long? Cliente { get; set; }

        
        public virtual Clientes Clientes { get; set; }
        
        public virtual Clientes Clientes1 { get; set; }

        public virtual Entregas Entregas { get; set; }

        public virtual Entregas Entregas1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamo> Reclamo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamo> Reclamo1 { get; set; }
    }
}
