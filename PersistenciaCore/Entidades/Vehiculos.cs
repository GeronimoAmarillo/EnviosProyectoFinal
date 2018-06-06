namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculos()
        {
            Multas = new HashSet<Multas>();
            Reparaciones = new HashSet<Reparaciones>();
        }

        [Key]
        [StringLength(10)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(25)]
        public string Marca { get; set; }

        [Required]
        [StringLength(25)]
        public string Modelo { get; set; }

        public decimal Capacidad { get; set; }

        [Required]
        [StringLength(150)]
        public string Estado { get; set; }

        public int Cadete { get; set; }

        public virtual Automobiles Automobiles { get; set; }

        public virtual Cadetes Cadetes { get; set; }

        public virtual Camiones Camiones { get; set; }

        public virtual Camionetas Camionetas { get; set; }

        public virtual Motos Motos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Multas> Multas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reparaciones> Reparaciones { get; set; }
    }
}
