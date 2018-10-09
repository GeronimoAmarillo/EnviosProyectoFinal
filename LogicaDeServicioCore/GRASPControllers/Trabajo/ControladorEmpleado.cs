﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorEmpleado:IControladorEmpleado
    {
        public bool ExisteEmpleado(int ci)
        {
            try
            {
                return LogicaUsuario.ExisteEmpleado(ci);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
        }

        public EntidadesCompartidasCore.Empleado BuscarEmpleado(int ci)
        {
            try
            {
                EntidadesCompartidasCore.Empleado usu= (Empleado)LogicaUsuario.BuscarUsuario(ci);

                return usu;
            }
            catch
            {
                throw new Exception("Error al buscar el empleado.");
            }
            
        }

        public bool ModificarEmpleado(EntidadesCompartidasCore.Empleado pEmpleado)
        {
            try
            {
                return LogicaUsuario.ModificarUsuario(pEmpleado);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }

        public bool BajaEmpleado(int ci)
        {
            try
            {
                return LogicaUsuario.BajaUsuario(ci);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }

        public bool AltaEmpleado(EntidadesCompartidasCore.Empleado pEmpleado)
        {
            try
            {
                return LogicaUsuario.AltaUsuario(pEmpleado);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }
        public List<Empleado> Listar()
        {
            try
            {
                return LogicaUsuario.ListarEmpleados();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los Empleados." + ex.Message);
            }
        }
    }
}
