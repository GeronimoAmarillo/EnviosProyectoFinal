namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Entregas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entregas()
        {
            Paquetes = new HashSet<Paquetes>();
            Paquetes1 = new HashSet<Paquetes>();
        }

        [Key]
        public int Codigo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(150)]
        public string NombreReceptor { get; set; }

        public long? ClienteReceptor { get; set; }

        public long? ClienteEmisor { get; set; }

        public int? LocalReceptor { get; set; }

        public int? LocalEmisor { get; set; }

        [Required]
        [StringLength(7)]
        public string Turno { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Clientes Clientes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paquetes> Paquetes { get; set; }

        public virtual Locales Locales { get; set; }

        public virtual Locales Locales1 { get; set; }

        public virtual Turnos Turnos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paquetes> Paquetes1 { get; set; }
    }
}
