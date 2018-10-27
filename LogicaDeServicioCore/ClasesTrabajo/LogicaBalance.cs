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
        public List<Balance> ObtenerBalancesAnuales(int anio)
        {
            List<Balance> balancesdelAnio = new List<Balance>();
            return balancesdelAnio;
        }

        public EntidadesCompartidasCore.Balance BuscarBalance(int mes, int anio)
        {
            Balance balance = new Balance();
            return balance;
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

                        if (i.Descripcion.Substring(0, 5) != "Extra")
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
                        if (g.Descripcion.Substring(0, 5) != "Extra")
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
                        mesesIncluidos.Add(Convert.ToDateTime("1/" + indice + "/" + añoInicial));

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
                            mesesIncluidos.Add(Convert.ToDateTime("1/" + indiceMes + "/" + indiceAño));

                            finalAlcanzado = true;
                        }
                        else
                        {
                            mesesIncluidos.Add(Convert.ToDateTime("1/" + indiceMes + "/" + indiceAño));

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

                            if (i.Descripcion.Substring(0, 5) != "Extra")
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
                            if (g.Descripcion.Substring(0, 5) != "Extra")
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
