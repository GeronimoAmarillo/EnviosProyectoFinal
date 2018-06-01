using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;


namespace LogicaDeApps
{
    public interface IControladorImpuesto
    {
        Impuesto GetImpuesto();

        void SetImpuesto(Impuesto pImpuesto);

        bool RegistrarImpuesto(DTImpuesto impuesto);

        void IniciarReigstroImpuesto();

    }
}
