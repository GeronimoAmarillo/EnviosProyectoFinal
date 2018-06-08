using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorImpuesto: IControladorImpuesto
    {
        private Impuesto impuesto;

        public Impuesto GetImpuesto()
        {
            return impuesto;
        }

        public void SetImpuesto(Impuesto pImpuesto)
        {
            impuesto = pImpuesto;
        }

        public bool RegistrarImpuesto(Impuesto impuesto)
        {
            return true;
        }

        public void IniciarReigstroImpuesto()
        {

        }
    }
}
