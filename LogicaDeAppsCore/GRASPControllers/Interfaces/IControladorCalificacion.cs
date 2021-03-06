﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorCalificacion
    {
        bool Calificar(Calificacion cal);
        Task<List<Calificacion>> ListarCalificaciones();
    }
}
