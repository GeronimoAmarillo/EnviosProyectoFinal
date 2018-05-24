namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Balance
    {
        public int Id { get; set; }
        
        public string Mes { get; set; }

        public int Año { get; set; }

        public bool Abierto { get; set; }
        
        public List<Registro> Registros { get; set; }
    }
}
