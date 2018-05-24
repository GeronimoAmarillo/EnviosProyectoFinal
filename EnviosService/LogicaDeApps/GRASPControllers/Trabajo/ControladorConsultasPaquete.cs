using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorConsultasPaquete:IControladorConsultasPaquete
    {
        private Local local;
        private List<Paquete> paquetes;

        public void SeleccionarLocal()
        {

        }

        public void SetLocal(Local pLocal)
        {
            local = pLocal;
        }

        public Local GetLocal()
        {
            return local;
        }

        public List<DTLocal> ListarLocales()
        {
            return new List<DTLocal>();
        }

        public List<DTPaquete> ListarPaquetesEnviadosXCliente(int cedula)
        {
            return new List<DTPaquete>();
        }

        public void SetPaquetes(List<Paquete> pPaquetes)
        {
            paquetes = pPaquetes;
        }

        public List<DTPaquete> FiltrarPaquetesEnviados(string estado, DateTime fechaEnvio)
        {
            return new List<DTPaquete>();
        }

        public List<DTPaquete> FiltrarPaquetesRecibidos(string estado, DateTime fechaEnvio)
        {
            return new List<DTPaquete>();
        }

        public List<Paquete> GetPaquetes()
        {
            return paquetes;
        }

        public List<DTPaquete> ListarPaquetesRecibidosXCliente(int cedula)
        {
            return new List<DTPaquete>();
        }

        public DTPaquete ConsultarEstado(int numReferencia)
        {
            return new DTPaquete();
        }
    }
}
