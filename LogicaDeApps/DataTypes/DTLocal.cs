using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogicaDeApps.Models
{
    public class DTLocal
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(200)]
        public string Direccion { get; set; }

        public List<DTEntrega> EntregasEnviadas { get; set; }
        public List<DTEntrega> EntregasRecibidas { get; set; }
    }
}
