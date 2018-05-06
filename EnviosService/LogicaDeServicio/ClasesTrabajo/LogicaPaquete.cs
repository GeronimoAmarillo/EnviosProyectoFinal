using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public class LogicaPaquete
    {
        public bool altaPaquete(Paquetes unPaquete)
        {
            bool exito = false;
            return exito;
        }

        public Paquetes buscarPaqueteXreferencia(int numeroReferencia)
        {
            Paquetes paquete = new Paquetes();
            return paquete;
        }

        public Paquetes buscarPaqueteXcodigo(int codigo)
        {
            Paquetes paquete = new Paquetes();
            return paquete;
        }

        public List<Paquetes> listarPaquetesEnviadosXcliente(int cedula)
        {
            List<Paquetes> lista = new List<Paquetes>();
            return lista;
        }

        public List<Paquetes> listarPaquetesRecibidosXcliente(int cedula)
        {
            List<Paquetes> lista = new List<Paquetes>();
            return lista;
        }

        public bool realizarReclamo(string descripcion)
        {
            bool exito = false;
            return exito;
        }
    }
}
