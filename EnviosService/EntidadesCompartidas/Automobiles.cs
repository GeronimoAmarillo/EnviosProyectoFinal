namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Automobiles
    {
        public int Puertas { get; set; }
        
        public string MatriculaAuto { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }
    }
}
