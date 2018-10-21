using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaEntrega:IPersistenciaEntrega
    {
        public bool Entregar(EntidadesCompartidasCore.Entrega entrega)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                PersistenciaCore.Entregas entregaAgregar = new PersistenciaCore.Entregas();

                entregaAgregar.ClienteEmisor = entrega.ClienteEmisor;
                entregaAgregar.ClienteReceptor = entrega.ClienteReceptor;
                entregaAgregar.Codigo = entrega.Codigo;
                entregaAgregar.Fecha = entrega.Fecha;
                entregaAgregar.LocalEmisor = entrega.LocalEmisor;
                entregaAgregar.LocalReceptor = entrega.LocalReceptor;
                entregaAgregar.NombreReceptor = entrega.NombreReceptor;

                List<Paquetes> paquetes = TransformarPaquetes(entrega.Paquetes);
                List<Paquetes> paquetes1 = TransformarPaquetes(entrega.Paquetes1);

                entregaAgregar.Codigo = entrega.Codigo;

                entregaAgregar.Turno = entrega.Turno;

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    if (paquetes != null || paquetes.Count > 0)
                    {
                        foreach (Paquetes p in paquetes)
                        {
                            p.Estado = "Entregado";
                            dbConnection.Paquetes.Update(p);
                        }
                    }

                    dbConnection.Entregas.Update(entregaAgregar);
                    
                    /*if (paquetes1 != null || paquetes1.Count > 0)
                    {
                        foreach (Paquetes p in paquetes1)
                        {
                            dbConnection.Paquetes.Update(p);
                        }
                    }*/

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la entrega." + ex);
            }
        }

        public Entrega BuscarEntrega(int codigo)
        {
            try
            {
                Entrega entregaResultado = null;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var entrega = dbConnection.Entregas.Include("Paquetes").Include("Paquetes1").Where(x => x.Codigo == codigo).FirstOrDefault();

                    if (entrega != null)
                    {
                        entregaResultado = new Entrega();

                        entregaResultado.ClienteEmisor = entrega.ClienteEmisor;
                        entregaResultado.ClienteReceptor = entrega.ClienteReceptor;
                        entregaResultado.Codigo = entrega.Codigo;
                        entregaResultado.Fecha = entrega.Fecha;
                        entregaResultado.LocalEmisor = entrega.LocalEmisor;
                        entregaResultado.LocalReceptor = entrega.LocalReceptor;
                        entregaResultado.NombreReceptor = entrega.NombreReceptor;
                        entregaResultado.Paquetes = TransformarPaquetesInversa(entrega.Paquetes);
                        entregaResultado.Paquetes1 = TransformarPaquetesInversa(entrega.Paquetes1);
                        entregaResultado.Turno = entrega.Turno;
                    }
                }

                return entregaResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la entrega." + ex.Message);
            }
        }

        private List<Paquete> TransformarPaquetesInversa(ICollection<Paquetes> pPaquetes)
        {
            try
            {
                List<Paquete> paquetesR = new List<Paquete>();

                foreach (Paquetes p in pPaquetes)
                {
                    Paquete pN = new Paquete();

                    pN.Cliente = p.Cliente;
                    pN.Entrega = p.Entrega;
                    pN.Estado = p.Estado;
                    pN.FechaSalida = p.FechaSalida;
                    pN.NumReferencia = p.NumReferencia;
                    pN.Ubicacion = p.Ubicacion;

                    paquetesR.Add(pN);
                }

                return paquetesR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al transformar los paquetes.");
            }
        }

        public List<EntidadesCompartidasCore.Entrega> ListarEntregas()
        {
            try
            {
                List<Entrega> entregasResultado = new List<Entrega>();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var entregas = dbConnection.Entregas.Include("Paquetes").Include("Paquetes1").Include("Locales").Include("Locales1").Include("Clientes.Usuarios").Include("Clientes1.Usuarios").Where(x=> x.Paquetes.FirstOrDefault().Estado == "Levantado" || x.Paquetes1.FirstOrDefault().Estado == "Levantado").ToList();

                    Entrega entregaResultado = null;

                    if (entregas != null)
                    {
                        foreach (Entregas e in entregas)
                        {
                            entregaResultado = new Entrega();

                            entregaResultado.ClienteEmisor = e.ClienteEmisor;
                            entregaResultado.ClienteReceptor = e.ClienteReceptor;
                            entregaResultado.Codigo = e.Codigo;
                            entregaResultado.Fecha = e.Fecha;
                            entregaResultado.LocalEmisor = e.LocalEmisor;
                            entregaResultado.LocalReceptor = e.LocalReceptor;
                            if (e.Locales != null)
                            {
                                entregaResultado.Locales = TransformarLocal(e.Locales);
                            }
                            if (e.Locales1 != null)
                            {
                                entregaResultado.Locales1 = TransformarLocal(e.Locales1);
                            }
                            if (e.Clientes != null)
                            {
                                entregaResultado.Clientes = TransformarCliente(e.Clientes);
                            }
                            if (e.Clientes1 != null)
                            {
                                entregaResultado.Clientes1 = TransformarCliente(e.Clientes1);
                            }
                            
                            entregaResultado.NombreReceptor = e.NombreReceptor;

                            if (e.Paquetes != null)
                            {
                                entregaResultado.Paquetes = TransformarPaquetesInversa(e.Paquetes);
                            }
                            if (e.Paquetes1 != null)
                            {
                                entregaResultado.Paquetes1 = TransformarPaquetesInversa(e.Paquetes1);
                            }

                            entregaResultado.Turno = e.Turno;

                            entregasResultado.Add(entregaResultado);
                        }
                    }
                }

                return entregasResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las entregas." + ex.Message);
            }
        }

        public List<Paquetes> TransformarPaquetes(List<Paquete> pPaquetes)
        {
            try
            {
                List<Paquetes> paquetesR = new List<Paquetes>();

                foreach (Paquete p in pPaquetes)
                {
                    Paquetes pN = new Paquetes();

                    pN.Cliente = p.Cliente;
                    pN.Entrega = p.Entrega;
                    pN.Estado = p.Estado;
                    pN.FechaSalida = p.FechaSalida;
                    pN.NumReferencia = p.NumReferencia;
                    pN.Ubicacion = p.Ubicacion;

                    paquetesR.Add(pN);
                }

                return paquetesR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al transformar los paquetes.");
            }
        }
        public Local TransformarLocal(Locales pLocal)
        {
            try
            {
                Local localR = new Local();


                localR.Direccion = pLocal.Direccion;
                localR.Id = pLocal.Id;
                localR.Nombre = pLocal.Nombre;

                return localR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al transformar el Local.");
            }
        }

        public Cliente TransformarCliente(Clientes pCliente)
        {
            try
            {
                Cliente clienteR = new Cliente();


                clienteR.Direccion = pCliente.Usuarios.Direccion;
                clienteR.Email = pCliente.Usuarios.Email;
                clienteR.Id = pCliente.Usuarios.Id;
                clienteR.Mensualidad = pCliente.Mensualidad;
                clienteR.Nombre = pCliente.Usuarios.Nombre;
                clienteR.NombreUsuario = pCliente.Usuarios.NombreUsuario;
                clienteR.RUT = pCliente.RUT;
                clienteR.Telefono = pCliente.Usuarios.Telefono;

                return clienteR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al transformar el cliente.");
            }
        }

        public bool AltaEntrega(EntidadesCompartidasCore.Entrega entrega)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                PersistenciaCore.Entregas entregaAgregar = new PersistenciaCore.Entregas();

                entregaAgregar.ClienteEmisor = entrega.ClienteEmisor;
                entregaAgregar.ClienteReceptor = entrega.ClienteReceptor;
                entregaAgregar.Codigo = entrega.Codigo;
                entregaAgregar.Fecha = entrega.Fecha;
                entregaAgregar.LocalEmisor = entrega.LocalEmisor;
                entregaAgregar.LocalReceptor = entrega.LocalReceptor;
                entregaAgregar.NombreReceptor = "";

                List<Paquetes> paquetes = TransformarPaquetes(entrega.Paquetes);


                int codigo = 0;

                entregaAgregar.Codigo = codigo;

                /*using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    bool existe = true;

                    while (existe == true)
                    {
                        codigo = GenerarCodigo();

                        existe = dbConnection.Entregas.Where(x => x.Codigo == codigo).Any();
                    }

                }*/

                DateTime fechaActual = DateTime.Now;

                var culture = new System.Globalization.CultureInfo("es-ES");
                string dia = culture.DateTimeFormat.GetDayName(fechaActual.DayOfWeek);

                string horaString = fechaActual.ToShortTimeString();

                string horaStringInt = horaString.Substring(0, 2) + horaString.Substring(3, 2);

                int hora = Convert.ToInt32(horaStringInt);

                Turnos turnoCandidato = FabricaPersistencia.GetPersistenciaTurno().IdentificarTurno(dia, hora);
                
                string turno = turnoCandidato.Codigo;

                entregaAgregar.Turno = turno;

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    using (var transaction = dbConnection.Database.BeginTransaction())
                    {
                        try
                        {
                            dbConnection.Entregas.Add(entregaAgregar);
                            dbConnection.SaveChanges();

                            var ultimoRegistro = dbConnection.Entregas.OrderByDescending(x => x.Codigo).FirstOrDefault();

                            codigo = ultimoRegistro.Codigo;

                            if (entrega.Paquetes != null)
                            {
                                foreach (Paquete p in entrega.Paquetes)
                                {
                                    p.Entrega = codigo;
                                }

                                paquetes = TransformarPaquetes(entrega.Paquetes);
                            }

                            foreach (Paquetes p in paquetes)
                            {
                                dbConnection.Paquetes.Add(p);
                            }

                            dbConnection.SaveChanges();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta la entrega." + ex);
            }
        }

        public int GenerarCodigo()
        {
            try
            {
                const string valid = "1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                int charNum = 1;
                while (charNum < 11)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                    charNum++;
                }

                return Convert.ToInt32(res.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede convertir el codigo generado.");
            }
        }
    }
}
