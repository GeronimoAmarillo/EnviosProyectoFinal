using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorPalet:IControladorPalet
    {
        

        public bool AltaPalet(Palet palet)
        {
            try
            {
                return LogicaPalet.AltaPalet(palet);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Palet.");
            }
        }

        public List<Cliente> ListarClientes()
        {
            try
            {
                return LogicaUsuario.ListarClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los clientes." + ex.Message);
            }
        }

        public Galpon BuscarGalpon(int id)
        {
            try
            {
                return LogicaPalet.BuscarGalpon(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el galpon." + ex.Message);
            }
        }

        public Palet BuscarPalet(int id)
        {
            return new Palet();
        }

        public bool BajaPalet(Palet palet)
        {
            return true;
        }
    }
}
