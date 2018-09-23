namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Usuario
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string NombreUsuario { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        public string Contraseña { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(350)]
        public string Direccion { get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(15)]
        public string Telefono { get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(5)]
        public string CodigoRecuperacionContraseña { get; set; }

        [StringLength(5)]
        public string CodigoModificarEmail { get; set; }

        public List<Cliente> Clientes { get; set; }
        
        public List<Empleado> Empleados { get; set; }
    }
}
