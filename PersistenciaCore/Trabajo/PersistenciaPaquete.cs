using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaPaquete:IPersistenciaPaquete
    {
        public bool AltaPaquete(EntidadesCompartidasCore.Paquete paquete)
        {
            return true;
        }

        public EntidadesCompartidasCore.Paquete BuscarPaquete(int numReferencia)
        {
            try
            {
                Paquetes paquete = new Paquetes();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    paquete = dbConnection.Paquetes.Include("Entregas").Include("Entregas1").Where(x => x.NumReferencia == numReferencia).FirstOrDefault();
                }

                Paquete paqueteResultado = new Paquete();

                if (paquete != null)
                {

                    paqueteResultado.Cliente = paquete.Cliente;
                    paqueteResultado.Entrega = paquete.Entrega;
                    if (paqueteResultado.Entregas != null)
                    {
                        paqueteResultado.Entregas = TransfomarEntrega(paquete.Entregas);
                    }

                    if (paqueteResultado.Entregas1 != null)
                    {
                        paqueteResultado.Entregas1 = TransfomarEntrega(paquete.Entregas1);
                    }
                   
                    paqueteResultado.Estado = paquete.Estado;
                    paqueteResultado.FechaSalida = paquete.FechaSalida;
                    paqueteResultado.NumReferencia = paquete.NumReferencia;
                    paqueteResultado.Ubicacion = paquete.Ubicacion;

                    
                }

                return paqueteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Paquete." + ex.Message);
            }
        }

        public EntidadesCompartidasCore.Paquete BuscarPaqueteIndividual(int numReferencia, int cliente)
        {
            try
            {
                Paquetes paquete = new Paquetes();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    paquete = dbConnection.Paquetes.Include("Entregas").Include("Entregas1").Where(x => x.NumReferencia == numReferencia && x.Cliente == cliente).FirstOrDefault();
                }

                Paquete paqueteResultado = new Paquete();

                if (paquete != null)
                {

                    paqueteResultado.Cliente = paquete.Cliente;
                    paqueteResultado.Entrega = paquete.Entrega;
                    if (paqueteResultado.Entregas != null)
                    {
                        paqueteResultado.Entregas = TransfomarEntrega(paquete.Entregas);
                    }

                    if (paqueteResultado.Entregas1 != null)
                    {
                        paqueteResultado.Entregas1 = TransfomarEntrega(paquete.Entregas1);
                    }

                    paqueteResultado.Estado = paquete.Estado;
                    paqueteResultado.FechaSalida = paquete.FechaSalida;
                    paqueteResultado.NumReferencia = paquete.NumReferencia;
                    paqueteResultado.Ubicacion = paquete.Ubicacion;


                }

                return paqueteResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Paquete." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Paquete> ListarPaquetesEnviadosXCliente(int rut)
        {
            try
            {
                List<Paquetes> paquetes = new List<Paquetes>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    paquetes = dbConnection.Paquetes.Include("Entregas").Include("Entregas1").Where(x => x.Entregas.ClienteEmisor == rut || x.Entregas1.ClienteEmisor == rut).ToList();
                }

                List<Paquete> paquetesResultado = new List<Paquete>();

                foreach (Paquetes p in paquetes)
                {
                    Paquete paqueteR = new Paquete();

                    paqueteR.Cliente = p.Cliente;
                    paqueteR.Entrega = p.Entrega;
                    paqueteR.Entregas = TransfomarEntrega(p.Entregas);
                    paqueteR.Entregas1 = TransfomarEntrega(p.Entregas1);
                    paqueteR.Estado = p.Estado;
                    paqueteR.FechaSalida = p.FechaSalida;
                    paqueteR.NumReferencia = p.NumReferencia;
                    paqueteR.Ubicacion = p.Ubicacion;

                    paquetesResultado.Add(paqueteR);
                }

                return paquetesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los Paquetes." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Paquete> ListarPaquetesRecibidosXCliente(int rut)
        {
            try
            {
                List<Paquetes> paquetes = new List<Paquetes>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    paquetes = dbConnection.Paquetes.Include("Entregas").Include("Entregas1").Where(x => x.Entregas.ClienteReceptor == rut || x.Entregas1.ClienteReceptor == rut).ToList();
                }

                List<Paquete> paquetesResultado = new List<Paquete>();

                foreach (Paquetes p in paquetes)
                {
                    Paquete paqueteR = new Paquete();

                    paqueteR.Cliente = p.Cliente;
                    paqueteR.Entrega = p.Entrega;
                    paqueteR.Entregas = TransfomarEntrega(p.Entregas);
                    paqueteR.Entregas1 = TransfomarEntrega(p.Entregas1);
                    paqueteR.Estado = p.Estado;
                    paqueteR.FechaSalida = p.FechaSalida;
                    paqueteR.NumReferencia = p.NumReferencia;
                    paqueteR.Ubicacion = p.Ubicacion;

                    paquetesResultado.Add(paqueteR);
                }

                return paquetesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los Paquetes." + ex.Message);
            }
        }

        private Entrega TransfomarEntrega(Entregas entrega)
        {
            try
            {
                Entrega entregaTransormada = new Entrega();

                entregaTransormada.ClienteEmisor = entrega.ClienteEmisor;
                entregaTransormada.ClienteReceptor = entrega.ClienteReceptor;
                entregaTransormada.Codigo = entrega.Codigo;
                entregaTransormada.Fecha = entrega.Fecha;
                entregaTransormada.LocalEmisor = entrega.LocalEmisor;
                entregaTransormada.LocalReceptor = entrega.LocalReceptor;
                entregaTransormada.NombreReceptor = entrega.NombreReceptor;

                return entregaTransormada;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los Paquetes." + ex.Message);
            }
        }

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }
        
    }
}
