﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorCliente:IControladorCliente
    {
        public bool ExisteCliente(int rut)
        {
            return true;
        }

        
        public EntidadesCompartidas.Clientes BuscarCliente(int rut)
        {
            return new Clientes();
        }

        public bool ModificarCliente(EntidadesCompartidas.Clientes pCliente)
        {
            return true;
        }

        public bool AltaCliente(EntidadesCompartidas.Clientes pCliente)
        {
            return true;
        }
    }
}
