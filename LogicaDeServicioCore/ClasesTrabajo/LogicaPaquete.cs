using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaPaquete
    {
        public bool AltaPaquete(Paquete unPaquete)
        {
            bool exito = false;
            return exito;
        }

        public static Paquete BuscarPaqueteXreferencia(int numeroReferencia)
        {
            try
            {
                Paquete paquete = FabricaPersistencia.GetPersistenciaPaquete().BuscarPaquete(numeroReferencia);

                return paquete;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el paquete." + ex.Message);
            }
        }

        public Paquete BuscarPaqueteXcodigo(int codigo)
        {
            Paquete paquete = new Paquete();
            return paquete;
        }

        public static List<Paquete> ListarPaquetesEnviadosXcliente(int rut)
        {
            try
            {
                List<Paquete> lista = FabricaPersistencia.GetPersistenciaPaquete().ListarPaquetesEnviadosXCliente(rut);

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los paquetes." + ex.Message);
            }
        }

        public List<Paquete> ListarPaquetesRecibidosXcliente(int cedula)
        {
            List<Paquete> lista = new List<Paquete>();
            return lista;
        }

        public bool RealizarReclamo(string descripcion)
        {
            bool exito = false;
            return exito;
        }
    }
}
