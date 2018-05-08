using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorPaquete:IControladorPaquete
    {
        private Reclamo reclamo;
        private Paquetes paquete;

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }

        public Paquetes GetPaquete()
        {
            return paquete;
        }

        public DTPaquete BuscarPaquete(int codigo)
        {
            return new DTPaquete();
        }

        public void SetPaquete(Paquetes pPaquete)
        {
            paquete = pPaquete;
        }

    }
}
