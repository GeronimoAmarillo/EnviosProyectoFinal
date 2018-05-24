namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Cadetes
    {
        public string TipoLibreta { get; set; }

        public long IdTelefono { get; set; }
        
        public int CiEmpleado { get; set; }

        public  Empleados Empleados { get; set; }
        
        public  List<Vehiculos> Vehiculos { get; set; }
    }
}
