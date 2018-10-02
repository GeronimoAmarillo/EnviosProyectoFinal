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
            try
            {
                return LogicaUsuario.ListarClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los clientes." + ex.Message);
            }
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
            try
            {
                return LogicaLocal.ListarLocales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los locales." + ex.Message);
            }
        }

        public Entrega BuscarEntrega(int codigo)
        {
            try
            {
                return LogicaEntrega.BuscarEntrega(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la entrega." + ex.Message);
            }
        }

        public bool AltaEntrega(EntidadesCompartidasCore.Entrega pEntrega)
        {
            try
            {
                return LogicaEntrega.AltaEntega(pEntrega);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar dar de alta la entrega." + ex);
            }
        }
    }
}
