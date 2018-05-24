namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Registros
    {
        public int Id { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public decimal UtilidadBruta { get; set; }
        
        public decimal UtilidadOperacional { get; set; }
        
        public decimal UtilidadSinImpuestos { get; set; }
        
        public decimal UtilidadEjercicio { get; set; }

        public int BalanceId { get; set; }

        public Balances Balances { get; set; }
    }
}
