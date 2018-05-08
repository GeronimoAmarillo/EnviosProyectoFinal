using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorTrackeo:IControladorTrackeo
    {
        private Paquetes paquete;

        public DTPaquete ObtenerPaquete(int numReferencia)
        {
            return new DTPaquete();
        }

        public void SetPaquete(Paquetes pPaquete)
        {
            paquete = pPaquete;
        }

        /*public Mapa ObtenerUbicacion()
        {

        }*/

        public string GetRuta(int idTelefono)
        {
            return "";
        }

        public string GetCooDefault()
        {
            return "";
        }

        public Paquetes GetPaquete()
        {
            return paquete;
        }
    }
}
