using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorConsultasPaquete
    {
        void SeleccionarLocal();

        void SetLocal(Local pLocal);

        Local GetLocal();

        List<DTLocal> ListarLocales();

        List<DTPaquete> ListarPaquetesEnviadosXCliente(int cedula);

        void SetPaquetes(List<Paquete> pPaquetes);

        List<DTPaquete> FiltrarPaquetesEnviados(string estado, DateTime fechaEnvio);

        List<DTPaquete> FiltrarPaquetesRecibidos(string estado, DateTime fechaEnvio);

        List<Paquete> GetPaquetes();

        List<DTPaquete> ListarPaquetesRecibidosXCliente(int cedula);

        DTPaquete ConsultarEstado(int numReferencia);

    }
}
