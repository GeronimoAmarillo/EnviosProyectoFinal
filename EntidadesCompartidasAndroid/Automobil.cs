namespace EntidadesCompartidasAndroid
{
    using System;
    using System.Collections.Generic;

    public partial class Automobil:Vehiculo
    {
        public int Puertas { get; set; }
        
        public string MatriculaAuto { get; set; }

        public virtual Vehiculo Vehiculos { get; set; }
    }
}
