namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Balances
    {
        public int Id { get; set; }
        
        public string Mes { get; set; }

        public int Año { get; set; }

        public bool Abierto { get; set; }
        
        public List<Registros> Registros { get; set; }
    }
}
