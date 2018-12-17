using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AdministradoresApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Balances")]
    public class BalancesController : Controller
    {
        public static string LOG_USER = "UsuarioLogueado";

        public static string SESSION_MENSAJE = "Mensaje";

        [HttpGet]
        public ActionResult ConsultarBalance()
        {
            try
            {
                Administrador adminLogueado = HttpContext.Session.Get<Administrador>(LOG_USER);
                if (adminLogueado != null)
                {
                    if (adminLogueado.Tipo == "C")
                    {
                        if (TempData["Mensaje"] != null)
                        {
                            string mensaje = TempData["Mensaje"].ToString();
                            TempData["Mensaje"] = mensaje;
                        }

                        return View();
                    }
                    else
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Para consultar balances el tipo de administrador debe ser contable.");

                        TempData["Mensaje"] = "No hay un usuario Contable logueado.";

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No estas logueado en el sistema.");

                    TempData["Mensaje"] = "No estas logueado en el sistema.";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }

        [HttpPost("ConsultarBalanceMensual")]
        public async Task<ActionResult> ConsultarBalanceMensual([FromForm]String mes, int anio)
        {
            try
            {
                IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();
                Balance balanceARetornar = await controladorBalance.ConsultarBalanceMensual(mes, anio);
                if (balanceARetornar != null)
                {
                    if (TempData["Mensaje"] != null)
                    {
                        string mensaje = TempData["Mensaje"].ToString();
                        TempData["Mensaje"] = mensaje;
                    }

                    return View(balanceARetornar);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                    TempData["Mensaje"] = "Error al consultar el balance.";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                TempData["Mensaje"] = "Error al consultar el balance.";

                return RedirectToAction("ConsultarBalance", "Balances", new { area = "" });
            }
        }

        [HttpPost("ConsultarBalanceAnual")]
        public async Task<ActionResult> ConsultarBalanceAnual([FromForm]DateTime fDesde, DateTime fHasta)
        {
            try
            {

                IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();
                Balance balanceARetornar = await controladorBalance.ObtenerBalanceAnual(fDesde, fHasta);

                if (balanceARetornar != null)
                {
                    if (TempData["Mensaje"] != null)
                    {
                        string mensaje = TempData["Mensaje"].ToString();
                        TempData["Mensaje"] = mensaje;
                    }

                    List<DateTime> mesesIncluidos = new List<DateTime>();

                    int mesInicial = fDesde.Month;
                    int añoInicial = fDesde.Year;
                    int mesFinal = fHasta.Month;
                    int añoFinal = fHasta.Year;

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


                    List<UtilidadesBrutasTotales> ubt = new List<UtilidadesBrutasTotales>();
                    List<UtilidadesOperacionalesTotales> uot = new List<UtilidadesOperacionalesTotales>();
                    List<UtilidadesSinImpuestosTotales> usit = new List<UtilidadesSinImpuestosTotales>();
                    List<UtilidadesDelEjercicioTotales> udet = new List<UtilidadesDelEjercicioTotales>();

                    var jsonUbt = "";
                    var jsonUot = "";
                    var jsonUsit = "";
                    var jsonUdet = "";

                    foreach (DateTime d in mesesIncluidos)
                    {

                        jsonUbt += "[";

                        List<Registro> registrosDelMes = balanceARetornar.Registros.Where(x => x.Fecha.Month == d.Month && x.Fecha.Year == d.Year).ToList();

                        foreach (Registro r in registrosDelMes)
                        {

                            UtilidadesBrutasTotales uti = new UtilidadesBrutasTotales
                            {
                                fecha = ("x" + d.ToShortDateString().Substring(2)),
                                suma = r.UtilidadBruta
                            };

                            ubt.Add(uti);

                            UtilidadesOperacionalesTotales utio = new UtilidadesOperacionalesTotales()
                            {
                                fecha = ("x" + d.ToShortDateString().Substring(2)),
                                suma = r.UtilidadOperacional
                            };

                            uot.Add(utio);

                            UtilidadesSinImpuestosTotales utisi = new UtilidadesSinImpuestosTotales
                            {
                                fecha = ("x" + d.ToShortDateString().Substring(2)),
                                suma = r.UtilidadSinImpuestos
                            };

                            usit.Add(utisi);

                            UtilidadesDelEjercicioTotales utie = new UtilidadesDelEjercicioTotales
                            {
                                fecha = ("x" + d.ToShortDateString().Substring(2)),
                                suma = r.UtilidadEjercicio
                            };

                            udet.Add(utie);

                        }
                        
                    }


                    var utilidadesBrutas = JsonConvert.SerializeObject(ubt);
                    var utilidadesOp = JsonConvert.SerializeObject(uot);
                    var utilidadesSImp = JsonConvert.SerializeObject(usit);
                    var utilidadesEjercicio = JsonConvert.SerializeObject(udet);


                    TempData["UBT"] = utilidadesBrutas;
                    TempData["UOT"] = utilidadesOp;
                    TempData["USIT"] = utilidadesSImp;
                    TempData["UDET"] = utilidadesEjercicio;
                    ViewBag.UB = utilidadesBrutas;

                    return View(balanceARetornar);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                    TempData["Mensaje"] = "Error al consultar el balance.";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                TempData["Mensaje"] = "Error al consultar el balance.";

                return RedirectToAction("ConsultarBalance", "Balances", new { area = "" });
            }
        }

        public async Task<ActionResult> Detalles(int mes, int año)
        {
            try
            {
                if (ComprobarLogin() == "C")
                {
                    IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();

                    DateTime fecha = Convert.ToDateTime(mes + "/1/" + año);

                    Registro registro = await controladorBalance.ConsultarRegistro(fecha);

                    List<SelectListItem> itemsIngresos = new List<SelectListItem>();
                    List<SelectListItem> itemsGastos = new List<SelectListItem>();
                    List<SelectListItem> itemsImpuestos = new List<SelectListItem>();

                    foreach (Ingreso i in registro.Ingresos)
                    {
                        itemsIngresos.Add(new SelectListItem() { Text = "Descripcion: " + i.Descripcion + " - Suma: " + i.Suma.ToString() + " - Fecha Registrado: " + i.fechaRegistro.ToString(), Value = i.Id.ToString() });
                    }

                    foreach (Gasto i in registro.Gastos)
                    {
                        itemsGastos.Add(new SelectListItem() { Text = "Descripcion: " + i.Descripcion + " - Suma: " + i.Suma.ToString() + " - Fecha Registrado: " + i.fechaRegistro.ToString(), Value = i.Id.ToString() });
                    }

                    foreach (Impuesto i in registro.Impuestos)
                    {
                        itemsImpuestos.Add(new SelectListItem() { Text = "Nombre: " + i.Nombre + " - Porcentaje: " + i.Porcentaje.ToString() + " - Fecha Registrado: " + i.fechaRegistro.ToString(), Value = i.Id.ToString() });
                    }

                    descargarMensaje();

                    ViewBag.Ingresos = itemsIngresos;
                    ViewBag.Gastos = itemsGastos;
                    ViewBag.Impuestos = itemsImpuestos;

                    return View(registro);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Contable logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario");

                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public string ComprobarLogin()
        {
            try
            {
                Administrador administrador = HttpContext.Session.Get<Administrador>(LOG_USER);

                if (administrador != null)
                {

                    if (administrador.Tipo.ToUpper() == "G")
                    {
                        return "G";
                    }
                    else if (administrador.Tipo.ToUpper() == "C")
                    {
                        return "C";
                    }
                    else if (administrador.Tipo.ToUpper() == "L")
                    {
                        return "L";
                    }
                    else
                    {
                        return "Valor invalido.";
                    }
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                throw new Exception("Error al comprobar el logueo.");
            }
        }

        public void descargarMensaje()
        {
            try
            {
                if (TempData["Mensaje"] != null)
                {
                    string mensaje = TempData["Mensaje"].ToString();
                    TempData["Mensaje"] = mensaje;
                }
            }
            catch
            {
                throw new Exception("Error al descargar el mensaje.");
            }
        }



        //CLASES PARA EL JSON DE CHARTS.JS----------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------


        public class UtilidadesBrutasTotales
        {
            public string fecha { get; set; }
            public decimal suma { get; set; }
        }

        public class UtilidadesOperacionalesTotales
        {
            public string fecha { get; set; }
            public decimal suma { get; set; }
        }

        public class UtilidadesSinImpuestosTotales
        {
            public string fecha { get; set; }
            public decimal suma { get; set; }
        }

        public class UtilidadesDelEjercicioTotales
        {
            public string fecha { get; set; }
            public decimal suma { get; set; }
        }

    }
}