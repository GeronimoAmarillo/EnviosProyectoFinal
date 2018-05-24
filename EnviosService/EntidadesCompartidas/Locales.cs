namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Locales
    {

        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public string Direccion { get; set; }
        
        public  List<Entregas> Entregas { get; set; }
        
        public  List<Entregas> Entregas1 { get; set; }
    }
}
