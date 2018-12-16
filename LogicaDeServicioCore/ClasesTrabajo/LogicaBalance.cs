using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public class LogicaBalance
    {
        public static List<Balance> ObtenerBalancesAnuales(int anio)
        {
            bool abierto = anio < DateTime.Today.Year ? false : true;
            List<Balance> balancesdelAnio = new List<Balance>();
            DateTime fechaInicio = new DateTime(anio, 1, 1);
            DateTime fechaFinal = anio == DateTime.Today.Year ? new DateTime(anio, DateTime.Today.Month - 1, DateTime.DaysInMonth(anio, DateTime.Today.Month - 1)) : new DateTime(anio, 12, 31);

            List<Registro> RegistrosDelBalance = ObtenerRegistros(fechaInicio, fechaFinal);

            //for (int i = 1; i <= fechaFinal.Month; i++)
            //{
            //    balancesdelAnio.Add(BuscarBalance(i, anio));
            //}

            return balancesdelAnio;
        }

        public static Balance ObtenerBalanceAnual(DateTime fechaDesde, DateTime FechaHasta)
        {
            List<Registro> RegistrosDelBalance = ObtenerRegistros(fechaDesde, FechaHasta);
            decimal utilidadBrutaTotal = 0;
            decimal utilidadOperacionalTotal = 0;
            decimal ingresos = 0;
            decimal ingresosExtra = 0;
            decimal gastos = 0;
            decimal gastosExtra = 0;
            decimal utilidadSinimpuestosTotal = 0;
            decimal utilidadEjercicioTotal = 0;

            foreach (Registro registro in RegistrosDelBalance)
            {
                utilidadBrutaTotal += registro.UtilidadBruta;
                utilidadEjercicioTotal += registro.UtilidadEjercicio;
                utilidadOperacionalTotal += registro.UtilidadOperacional;
                utilidadSinimpuestosTotal += registro.UtilidadSinImpuestos;
                foreach (Ingreso ingreso in registro.Ingresos)
                {
                    if (!(ingreso.Extra))
                    {
                        ingresosExtra += ingreso.Suma;
                    }
                    else
                    {
                        ingresos += ingreso.Suma;
                    }
                }
                foreach (Gasto gasto in registro.Gastos)
                {
                    if (!(gasto.Extra))
                    {
                        gastosExtra += gasto.Suma;
                    }
                    else
                    {
                        gastos += gasto.Suma;
                    }
                }
            }

            Balance balance = new Balance()
            {
                Mes = FechaHasta.Month,
                Año = FechaHasta.Year,
                Abierto = true,
                UtilidadBrutaTotal = utilidadBrutaTotal,
                UtilidadOperacionalTotal = utilidadOperacionalTotal,
                Ingresos = ingresos,
                IngresosExtra = ingresosExtra,
                Gastos = gastos,
                GastosExtra = gastosExtra,
                UtilidadSinimpuestosTotal = utilidadSinimpuestosTotal,
                UtilidadEjercicioTotal = utilidadEjercicioTotal,
                Registros = RegistrosDelBalance
            };

            return balance;

        }

        public static Balance BuscarBalance(string mes, int anio)
        {
            try
            {
                int numeroMes = 0;
                Dictionary<string, int> Meses = new Dictionary<string, int>();

                Meses.Add("enero", 1);
                Meses.Add("febrero", 2);
                Meses.Add("marzo", 3);
                Meses.Add("abril", 4);
                Meses.Add("mayo", 5);
                Meses.Add("junio", 6);
                Meses.Add("julio", 7);
                Meses.Add("agosto", 8);
                Meses.Add("septiembre", 9);
                Meses.Add("octubre", 10);
                Meses.Add("noviembre", 11);
                Meses.Add("diciembre", 12);

                if (Meses.ContainsKey(mes.ToLower()))
                {
                    numeroMes = Meses[mes.ToLower()];
                }
                
                DateTime fechaInicio = Convert.ToDateTime(numeroMes + "/1/" + anio);
                DateTime fechaFinal = new DateTime(fechaInicio.Year, fechaInicio.Month, DateTime.DaysInMonth(fechaInicio.Year, fechaInicio.Month));
                List<Registro> RegistrosDelBalance = ObtenerRegistros(fechaInicio, fechaFinal);
                decimal utilidadBrutaTotal = 0;
                decimal utilidadOperacionalTotal = 0;
                decimal ingresos = 0;
                decimal ingresosExtra = 0;
                decimal gastos = 0;
                decimal gastosExtra = 0;
                decimal utilidadSinimpuestosTotal = 0;
                decimal utilidadEjercicioTotal = 0;

                foreach (Registro registro in RegistrosDelBalance)
                {
                    utilidadBrutaTotal += registro.UtilidadBruta;
                    utilidadEjercicioTotal += registro.UtilidadEjercicio;
                    utilidadOperacionalTotal += registro.UtilidadOperacional;
                    utilidadSinimpuestosTotal += registro.UtilidadSinImpuestos;
                    foreach (Ingreso ingreso in registro.Ingresos)
                    {
                        if(!ingreso.Extra)
                        {
                            ingresosExtra += ingreso.Suma;
                        }
                        else
                        {
                            ingresos += ingreso.Suma;
                        }
                    }
                    foreach(Gasto gasto in registro.Gastos)
                    {
                        if(!gasto.Extra)
                        {
                            gastosExtra += gasto.Suma;
                        }
                        else
                        {
                            gastos += gasto.Suma;
                        }
                    }
                }

                Balance balance = new Balance()
                {
                    Mes = numeroMes,
                    Año = anio,
                    Abierto = true,
                    UtilidadBrutaTotal = utilidadBrutaTotal,
                    UtilidadOperacionalTotal = utilidadOperacionalTotal,
                    Ingresos = ingresos,
                    IngresosExtra = ingresosExtra,
                    Gastos = gastos,
                    GastosExtra = gastosExtra,
                    UtilidadSinimpuestosTotal = utilidadSinimpuestosTotal,
                    UtilidadEjercicioTotal = utilidadEjercicioTotal,
                    Registros = RegistrosDelBalance
                };

                return balance;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el balance del mes, " + ex.Message);
            }

        }

        public static Registro ObtenerRegistro(DateTime fecha)
        {
            try
            {
                Registro registro = new Registro();
                List<Ingreso> ingresos = new List<Ingreso>();
                List<Gasto> gastos = new List<Gasto>();
                List<Impuesto> impuestos = new List<Impuesto>();

                

                ingresos = LogicaValor.ListarIngresos();
                gastos = LogicaValor.ListarGastos();
                impuestos = LogicaValor.ListarImpuestos();

                List<Ingreso> ingresosR = new List<Ingreso>();
                List<Gasto> gastosR = new List<Gasto>();
                List<Impuesto> impuestosR = new List<Impuesto>();

                decimal utilidadbruta = 0;
                decimal utilidadoperacional = 0;
                decimal ingresosextras = 0;
                decimal gastosextras = 0;
                decimal utilidadsinimpuestos = 0;
                decimal utilidadEjercicio = 0;

                foreach (Ingreso i in ingresos)
                {
                    if ((i.fechaRegistro.Month == fecha.Month && i.fechaRegistro.Year == fecha.Year))
                    {
                        ingresosR.Add(i);

                        if (!(i.Extra))
                        {
                            utilidadbruta += i.Suma;
                            utilidadoperacional = utilidadbruta;
                        }
                        else
                        {
                            ingresosextras += i.Suma;
                        }
                    }
                }

                

                foreach (Gasto g in gastos)
                {
                    if ((g.fechaRegistro.Month == fecha.Month && g.fechaRegistro.Year == fecha.Year))
                    {
                        gastosR.Add(g);
                        if (!(g.Extra))
                        {
                            utilidadoperacional -= g.Suma;
                        }
                        else
                        {
                            gastosextras += g.Suma;
                        }
                    }
                }

                utilidadsinimpuestos = (utilidadoperacional + ingresosextras - gastosextras);

                List<decimal> montosimpuestoaplicados = new List<decimal>();

                foreach (Impuesto i in impuestos)
                {
                    if ((i.fechaRegistro.Month < fecha.Month && i.fechaRegistro.Year == fecha.Year))
                    {
                        impuestosR.Add(i);
                        montosimpuestoaplicados.Add((utilidadsinimpuestos * i.Porcentaje) / 100);
                    }
                }

                utilidadEjercicio = utilidadsinimpuestos;

                foreach (decimal d in montosimpuestoaplicados)
                {
                    utilidadEjercicio -= d;
                }

                registro.UtilidadBruta = utilidadbruta;
                registro.UtilidadEjercicio = utilidadEjercicio;
                registro.UtilidadOperacional = utilidadoperacional;
                registro.UtilidadSinImpuestos = utilidadsinimpuestos;
                registro.Fecha = fecha;
                registro.Ingresos = ingresosR;
                registro.Gastos = gastosR;
                registro.Impuestos = impuestosR;

                return registro;

            }
            catch(Exception ex)
            {
                throw new Exception("Error al obtener el registro del mes, " + ex.Message);
            }
        }

        public static List<Registro> ObtenerRegistros(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                List<Registro> registros = new List<Registro>();

                List<DateTime> mesesIncluidos = new List<DateTime>();

                int mesInicial = fechaInicio.Month;
                int añoInicial = fechaInicio.Year;
                int mesFinal = fechaFinal.Month;
                int añoFinal = fechaFinal.Year;

                if (añoFinal == añoInicial)
                {
                    int indice = mesInicial;

                    while (indice <= mesFinal)
                    {
                        mesesIncluidos.Add(Convert.ToDateTime(indice + "/1/" + añoInicial));

                        indice++;
                    }
                }
                else
                {
                    bool finalAlcanzado = false;
                    int indiceMes = mesInicial;
                    int indiceAño = añoInicial;

                    while (finalAlcanzado == false)
                    {
                        if (indiceMes == mesFinal && indiceAño == añoFinal)
                        {
                            mesesIncluidos.Add(Convert.ToDateTime(indiceMes + "/1/" + indiceAño));

                            finalAlcanzado = true;
                        }
                        else
                        {
                            mesesIncluidos.Add(Convert.ToDateTime(indiceMes + "/1/" + indiceAño));

                            if (indiceMes == 12)
                            {
                                indiceAño++;
                                indiceMes = 0;
                            }

                            indiceMes++;
                        }
                    }
                }


                List<Ingreso> ingresos = new List<Ingreso>();
                List<Gasto> gastos = new List<Gasto>();
                List<Impuesto> impuestos = new List<Impuesto>();

                ingresos = LogicaValor.ListarIngresos();
                gastos = LogicaValor.ListarGastos();
                impuestos = LogicaValor.ListarImpuestos();


                foreach (DateTime d in mesesIncluidos)
                {
                    Registro registro = new Registro();

                    List<Ingreso> ingresosR = new List<Ingreso>();
                    List<Gasto> gastosR = new List<Gasto>();
                    List<Impuesto> impuestosR = new List<Impuesto>();

                    decimal utilidadbruta = 0;
                    decimal utilidadoperacional = 0;
                    decimal ingresosextras = 0;
                    decimal gastosextras = 0;
                    decimal utilidadsinimpuestos = 0;
                    decimal utilidadEjercicio = 0;

                    foreach (Ingreso i in ingresos)
                    {
                        if ((i.fechaRegistro.Month == d.Month && i.fechaRegistro.Year == d.Year))
                        {
                            ingresosR.Add(i);

                            if (!(i.Extra))
                            {
                                utilidadbruta += i.Suma;
                                utilidadoperacional = utilidadbruta;
                            }
                            else
                            {
                                ingresosextras += i.Suma;
                            }
                        }
                    }



                    foreach (Gasto g in gastos)
                    {
                        if ((g.fechaRegistro.Month == d.Month && g.fechaRegistro.Year == d.Year))
                        {
                            gastosR.Add(g);
                            if (!(g.Extra))
                            {
                                utilidadoperacional -= g.Suma;
                            }
                            else
                            {
                                gastosextras += g.Suma;
                            }
                        }
                    }

                    utilidadsinimpuestos = (utilidadoperacional + ingresosextras - gastosextras);

                    List<decimal> montosimpuestoaplicados = new List<decimal>();

                    foreach (Impuesto i in impuestos)
                    {
                        if ((i.fechaRegistro.Month < d.Month && i.fechaRegistro.Year == d.Year))
                        {
                            impuestosR.Add(i);
                            montosimpuestoaplicados.Add((utilidadsinimpuestos * i.Porcentaje) / 100);
                        }
                    }

                    utilidadEjercicio = utilidadsinimpuestos;

                    foreach (decimal de in montosimpuestoaplicados)
                    {
                        utilidadEjercicio -= de;
                    }

                    registro.UtilidadBruta = utilidadbruta;
                    registro.UtilidadEjercicio = utilidadEjercicio;
                    registro.UtilidadOperacional = utilidadoperacional;
                    registro.UtilidadSinImpuestos = utilidadsinimpuestos;
                    registro.Fecha = d;
                    registro.Ingresos = ingresosR;
                    registro.Gastos = gastosR;
                    registro.Impuestos = impuestosR;

                    registros.Add(registro);
                }

                return registros;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los registros en el rango, " + ex.Message);
            }
        }
    }
}
