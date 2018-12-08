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

        public string Longitud { get; set; }

        public string Latitud { get; set; }

        [Required]
        [Range(1000000, 99999999)]
        public int CiEmpleado { get; set; }

        public  Empleado Empleados { get; set; }
        
        public  List<Vehiculo> Vehiculos { get; set; }
    }
}
