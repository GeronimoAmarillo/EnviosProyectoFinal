using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorEntrega:IControladorEntrega
    {
        
        public List<EntidadesCompartidas.Entrega> ListarEntregas()
        {
            return new List<EntidadesCompartidas.Entrega>();
        }


        public bool Entregar(List<EntidadesCompartidas.Entrega> entregasSeleccionadas)
        {
            return true;
        }

        public List<EntidadesCompartidas.Cliente> ListarClientes()
        {
            return new List<EntidadesCompartidas.Cliente>();
        }

        public List<EntidadesCompartidas.Cadete> ListarCadetesDisponibles()
        {
            return new List<EntidadesCompartidas.Cadete>();
        }
        
        public List<EntidadesCompartidas.Turno> ListarTurnos()
        {
            return new List<EntidadesCompartidas.Turno>();
        }

        public List<EntidadesCompartidas.Local> ListarLocales()
        {
            return new List<EntidadesCompartidas.Local>();
        }

        public bool AltaEntrega(EntidadesCompartidas.Entrega pEntrega)
        {
            return true;
        }
    }
}
