namespace EntidadesCompartidasAndroid
{
    using System;
    using System.Collections.Generic;

    public partial class Cadete:Empleado
    {
        public string TipoLibreta { get; set; }
        
        
        public string Longitud { get; set; }

        public string Latitud { get; set; }

        public int CiEmpleado { get; set; }

        public  Empleado Empleados { get; set; }
        
        public  List<Vehiculo> Vehiculos { get; set; }
    }
}
