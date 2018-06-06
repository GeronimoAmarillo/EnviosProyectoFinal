using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorEntrega:IControladorEntrega
    {
        
        public List<EntidadesCompartidasCore.Entrega> ListarEntregas()
        {
            return new List<EntidadesCompartidasCore.Entrega>();
        }


        public bool Entregar(List<EntidadesCompartidasCore.Entrega> entregasSeleccionadas)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Cliente> ListarClientes()
        {
            return new List<EntidadesCompartidasCore.Cliente>();
        }

        public List<EntidadesCompartidasCore.Cadete> ListarCadetesDisponibles()
        {
            return new List<EntidadesCompartidasCore.Cadete>();
        }
        
        public List<EntidadesCompartidasCore.Turno> ListarTurnos()
        {
            return new List<EntidadesCompartidasCore.Turno>();
        }

        public List<EntidadesCompartidasCore.Local> ListarLocales()
        {
            return new List<EntidadesCompartidasCore.Local>();
        }

        public bool AltaEntrega(EntidadesCompartidasCore.Entrega pEntrega)
        {
            return true;
        }
    }
}
