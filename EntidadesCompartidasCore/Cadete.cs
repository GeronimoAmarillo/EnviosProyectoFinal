namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Cadete:Empleado
    {
        public string TipoLibreta { get; set; }

        public long IdTelefono { get; set; }

        public  Empleado Empleados { get; set; }
        
        public  List<Vehiculo> Vehiculos { get; set; }
    }
}
