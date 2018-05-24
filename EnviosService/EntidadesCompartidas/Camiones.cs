namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Camiones
    {
        public decimal Altura { get; set; }
        
        public string MatriculaCamion { get; set; }

        public  Vehiculos Vehiculos { get; set; }
    }
}
