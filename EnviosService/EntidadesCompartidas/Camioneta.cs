namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Camioneta:Vehiculo
    {
        public string Cabina { get; set; }
        
        public string MatriculaCamioneta { get; set; }

        public Vehiculo Vehiculos { get; set; }
    }
}
