﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;


namespace LogicaDeAppsCore
{
    public interface IControladorImpuesto
    {
        Impuesto GetImpuesto();

        void SetImpuesto(Impuesto pImpuesto);

        bool RegistrarImpuesto(Impuesto impuesto);

        void IniciarReigstroImpuesto();

        Task<List<Impuesto>> ListarImpuestos();

    }
}
