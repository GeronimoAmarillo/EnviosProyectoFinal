//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;
    
    public partial class Camiones:Vehiculos
    {
        public decimal Altura { get; set; }
        public string MatriculaCamion { get; set; }
    
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
