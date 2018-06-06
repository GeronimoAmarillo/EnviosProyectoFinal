using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public class LogicaPaquete
    {
        public bool AltaPaquete(Paquete unPaquete)
        {
            bool exito = false;
            return exito;
        }

        public Paquete BuscarPaqueteXreferencia(int numeroReferencia)
        {
            Paquete paquete = new Paquete();
            return paquete;
        }

        public Paquete BuscarPaqueteXcodigo(int codigo)
        {
            Paquete paquete = new Paquete();
            return paquete;
        }

        public List<Paquete> ListarPaquetesEnviadosXcliente(int cedula)
        {
            List<Paquete> lista = new List<Paquete>();
            return lista;
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
