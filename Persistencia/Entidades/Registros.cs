namespace Persistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registros
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "money")]
        public decimal UtilidadBruta { get; set; }

        [Column(TypeName = "money")]
        public decimal UtilidadOperacional { get; set; }

        [Column(TypeName = "money")]
        public decimal UtilidadSinImpuestos { get; set; }

        [Column(TypeName = "money")]
        public decimal UtilidadEjercicio { get; set; }

        public int BalanceId { get; set; }

        public virtual Balances Balances { get; set; }
    }
}
