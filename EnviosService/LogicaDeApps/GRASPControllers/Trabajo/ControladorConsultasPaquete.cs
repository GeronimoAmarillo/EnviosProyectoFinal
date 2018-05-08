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
        private Locales local;
        private List<Paquetes> paquetes;

        public void SeleccionarLocal()
        {

        }

        public void SetLocal(Locales pLocal)
        {
            local = pLocal;
        }

        public Locales GetLocal()
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

        public void SetPaquetes(List<Paquetes> pPaquetes)
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

        public List<Paquetes> GetPaquetes()
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
