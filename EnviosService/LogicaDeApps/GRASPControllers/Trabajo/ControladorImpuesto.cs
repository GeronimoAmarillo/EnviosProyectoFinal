using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorImpuesto: IControladorImpuesto
    {
        private Impuestos impuesto;

        public Impuestos GetImpuesto()
        {
            return impuesto;
        }

        public void SetImpuesto(Impuestos pImpuesto)
        {
            impuesto = pImpuesto;
        }

        public bool RegistrarImpuesto(DTImpuesto impuesto)
        {
            return true;
        }

        public void IniciarReigstroImpuesto()
        {

        }
    }
}
