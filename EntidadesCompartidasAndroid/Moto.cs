namespace EntidadesCompartidasAndroid
{
    using System;
    using System.Collections.Generic;

    public partial class Moto:Vehiculo
    {
        public decimal Cilindrada { get; set; }
        
        public string MatriculaMoto { get; set; }

        public virtual Vehiculo Vehiculos { get; set; }
    }
}
