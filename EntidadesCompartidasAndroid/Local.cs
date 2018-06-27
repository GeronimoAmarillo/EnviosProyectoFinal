namespace EntidadesCompartidasAndroid
{
    using System;
    using System.Collections.Generic;

    public partial class Local
    {

        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public string Direccion { get; set; }
        
        public  List<Entrega> Entregas { get; set; }
        
        public  List<Entrega> Entregas1 { get; set; }
    }
}
