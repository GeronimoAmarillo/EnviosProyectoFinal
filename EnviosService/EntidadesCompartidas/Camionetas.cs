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
    
    public partial class Camionetas:Vehiculos
    {
        public string Cabina { get; set; }
        public string MatriculaCamioneta { get; set; }
    
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
