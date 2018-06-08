using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
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

        public List<Local> ListarLocales()
        {
            return new List<Local>();
        }

        public List<Paquete> ListarPaquetesEnviadosXCliente(int cedula)
        {
            return new List<Paquete>();
        }

        public void SetPaquetes(List<Paquete> pPaquetes)
        {
            paquetes = pPaquetes;
        }

        public List<Paquete> FiltrarPaquetesEnviados(string estado, DateTime fechaEnvio)
        {
            return new List<Paquete>();
        }

        public List<Paquete> FiltrarPaquetesRecibidos(string estado, DateTime fechaEnvio)
        {
            return new List<Paquete>();
        }

        public List<Paquete> GetPaquetes()
        {
            return paquetes;
        }

        public List<Paquete> ListarPaquetesRecibidosXCliente(int cedula)
        {
            return new List<Paquete>();
        }

        public Paquete ConsultarEstado(int numReferencia)
        {
            return new Paquete();
        }
    }
}
