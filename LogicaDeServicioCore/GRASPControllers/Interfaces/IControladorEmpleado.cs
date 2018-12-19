﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorEmpleado
    {
        Geolocalizacion ConsultarLocalizacion(int numReferencia, long rut);

        bool ExisteEmpleado(int ci);

        Empleado BuscarEmpleado(int ci);

        bool ModificarEmpleado(EntidadesCompartidasCore.Empleado pEmpleado);

        EntidadesCompartidasCore.Empleado BuscarEmpleadoActuaizado(int ci);

        bool BajaEmpleado(int ci);

        bool AltaEmpleado(Empleado pEmpleado);

        List<Empleado> Listar();

        List<EntidadesCompartidasAndroid.Cadete> ListarCadetes();
    }
}
