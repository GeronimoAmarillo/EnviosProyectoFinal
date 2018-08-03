namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Cadete:Empleado
    {
        [Required]
        [MinLength(1)]
        [MaxLength(3)]
        public string TipoLibreta { get; set; }
        [Required]
        public long IdTelefono { get; set; }
        [Required]
        public int CiEmpleado { get; set; }

        public  Empleado Empleados { get; set; }
        
        public  List<Vehiculo> Vehiculos { get; set; }
    }
}
