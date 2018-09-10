namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Balance
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Mes { get; set; }
        [Required]
        [Range(1900, 3000)]
        public int Año { get; set; }
        [Required]
        public bool Abierto { get; set; }
        
        public List<Registro> Registros { get; set; }
    }
}
