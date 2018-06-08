using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorPaquete:IControladorPaquete
    {
        private Reclamo reclamo;
        private Paquete paquete;

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }

        public Paquete GetPaquete()
        {
            return paquete;
        }

        public Paquete BuscarPaquete(int codigo)
        {
            return new Paquete();
        }

        public void SetPaquete(Paquete pPaquete)
        {
            paquete = pPaquete;
        }

    }
}
