namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Camion:Vehiculo
    {
        public decimal Altura { get; set; }
        
        public string MatriculaCamion { get; set; }

        public  Vehiculo Vehiculos { get; set; }
    }
}
