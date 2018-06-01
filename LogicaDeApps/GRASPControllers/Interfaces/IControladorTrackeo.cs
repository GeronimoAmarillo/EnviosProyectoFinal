using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorTrackeo
    {
        DTPaquete ObtenerPaquete(int numReferencia);

        void SetPaquete(Paquete pPaquete);

        //Mapa ObtenerUbicacion();

        string GetRuta(int idTelefono);

        string GetCooDefault();

        Paquete GetPaquete();

    }
}
