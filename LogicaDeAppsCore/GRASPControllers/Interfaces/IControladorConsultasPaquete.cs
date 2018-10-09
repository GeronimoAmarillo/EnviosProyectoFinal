using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorConsultasPaquete
    {
        void SeleccionarLocal();

        void SetLocal(Local pLocal);

        Local GetLocal();

        List<Local> ListarLocales();

        Task<Paquete> BuscarPaquete(int numReferencia);

        Task<Paquete> BuscarPaqueteIndividual(int numReferencia, long cliente);

        Task<List<Paquete>> ListarPaquetesEnviadosXCliente(long rut);

        void SetPaquetes(List<Paquete> pPaquetes);

        List<Paquete> FiltrarPaquetesEnviados(string estado, DateTime fechaEnvio);

        List<Paquete> FiltrarPaquetesRecibidos(string estado, DateTime fechaEnvio);

        List<Paquete> GetPaquetes();

        List<Paquete> ListarPaquetesRecibidosXCliente(int cedula);


        Paquete ConsultarEstado(int numReferencia);

    }
}
