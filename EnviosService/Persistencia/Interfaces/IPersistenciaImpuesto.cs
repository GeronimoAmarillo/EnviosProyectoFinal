﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaImpuesto
    {
        bool RegistrarImpuesto(EntidadesCompartidas.Impuestos impuesto);
    }
}
