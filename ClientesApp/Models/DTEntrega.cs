using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.Models
{
    public class DTEntrega
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreReceptor { get; set; }

        public  DTCliente ClienteEmisor { get; set; }
        public DTCliente ClientesReceptor { get; set; }
        public DTLocal LocalEmisor { get; set; }
        public DTLocal LocalReceptor { get; set; }
        public DTTurno Turno { get; set; }


        public  List<DTPaquete> Paquetes { get; set; }
    }
}
