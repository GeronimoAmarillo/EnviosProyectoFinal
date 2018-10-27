using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorPaquete:IControladorPaquete
    {
        public bool RealizarReclamo(EntidadesCompartidasCore.Reclamo reclamo)
        {
            try
            {
                return LogicaPaquete.RealizarReclamo(reclamo);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Reclamo.");
            }
        }
      
        public Paquete BuscarPaquete(int numReferencia)
        {
            try
            {
                Paquete paquete = LogicaPaquete.BuscarPaqueteXreferencia(numReferencia);

                return paquete;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el paquete." + ex.Message);
            }
        }
        public Paquete BuscarPaqueteIndividual(int numReferencia, int cliente)
        {
            try
            {
                Paquete paquete = LogicaPaquete.BuscarPaqueteIndividual(numReferencia, cliente);

                return paquete;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el paquete." + ex.Message);
            }
        }

        public List<Local> ListarLocales()
        {
            return new List<Local>();
        }

        public List<Paquete> ListarPaquetesEnviadosXCliente(int rut)
        {
            try
            {
                List<Paquete> lista = LogicaPaquete.ListarPaquetesEnviadosXcliente(rut);

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los paquetes." + ex.Message);
            }
        }
        

        public List<Paquete> ListarPaquetesRecibidosXCliente(int rut)
        {
            try
            {
                List<Paquete> lista = LogicaPaquete.ListarPaquetesRecibidosXcliente(rut);

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los paquetes." + ex.Message);
            }
        }

        public Local BuscarLocal(string nombre)
        {
            return new Local();
        }
        //Reclamos

        public List<EntidadesCompartidasCore.Reclamo> ListarReclamos()
        {
            try
            {
                return LogicaPaquete.LisarReclamos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los reclamos." + ex.Message);
            }
        }
    }
}
