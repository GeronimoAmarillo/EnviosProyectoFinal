using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorCliente:IControladorCliente
    {
        public bool ExisteCliente(int rut)
        {
            return true;
        }

        
        public EntidadesCompartidasCore.Cliente BuscarCliente(int rut)
        {
            Cliente cliente;

            try
            {
                cliente = LogicaUsuario.BuscarCliente(rut);

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Cliente" + ex.Message);
            }
        }

        public bool ModificarCliente(EntidadesCompartidasCore.Cliente pCliente)
        {
            try
            {
                if (pCliente != null)
                {
                    return LogicaUsuario.ModificarUsuario(pCliente);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el Cliente." + ex.Message);
            }
        }

        public bool AltaCliente(EntidadesCompartidasCore.Cliente pCliente)
        {
            return true;
        }
        
    }
}
