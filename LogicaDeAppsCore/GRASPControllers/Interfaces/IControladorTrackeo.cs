using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorTrackeo
    {
        Paquete ObtenerPaquete(int numReferencia);

        void SetPaquete(Paquete pPaquete);

        //Mapa ObtenerUbicacion();

        string GetRuta(int idTelefono);

        string GetCooDefault();

        Paquete GetPaquete();

    }
}
