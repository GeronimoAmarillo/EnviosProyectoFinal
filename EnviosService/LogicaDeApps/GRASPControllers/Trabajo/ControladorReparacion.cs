﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorReparacion : IControladorReparacion
    {
        private Reparaciones reparacion;

        public Reparaciones GetReparacion()
        {
            return reparacion;
        }

        public void SetReparacion(Reparaciones pReparacion)
        {
            reparacion = pReparacion;
        }

        public bool RegistrarReparacion(DTReparacion reparacion)
        {
            return true;
        }

        public List<DTVehiculo> ListarVehiculos()
        {
            return new List<DTVehiculo>();
        }

        public DTVehiculo SeleccionarVehiculo(string matricula)
        {
            return new DTVehiculo();
        }

        public void IniciarRegistroReparacion()
        {

        }
    }
}
