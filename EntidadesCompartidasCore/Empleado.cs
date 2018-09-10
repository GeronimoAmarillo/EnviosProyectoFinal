namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Empleado:Usuario
    {
        [Required]
        [Range(1000, Double.MaxValue)]
        public decimal Sueldo { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        [Range(1000000, 99999999)]
        public int Ci { get; set; }
        
        public  List<Adelanto> Adelantos { get; set; }

        public Cadete Cadetes { get; set; }
        
        public List<Administrador> Administradores { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
