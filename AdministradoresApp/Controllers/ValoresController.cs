using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdministradoresApp.Models;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdministradoresApp.Controllers
{

    public class ValoresController : Controller
    {
        public static string SESSSION_ALTA = "AltaValor";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";
        public static string SESSION_LISTA_ACTUAL = "ListaView";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    SortedList<string, string> listaActual = HttpContext.Session.Get<SortedList<string, string>>(SESSION_LISTA_ACTUAL);
                    HttpContext.Session.Set<SortedList<string, string>>(SESSION_LISTA_ACTUAL, null);

                    if (listaActual == null)
                    {
                        IControladorGasto controladorGasto = FabricaApps.GetControladorGasto();

                        SortedList<string, string> gastosSorted = new SortedList<string, string>();

                        List<Gasto> gastos = await controladorGasto.ListarGastos();

                        gastosSorted.Add("Gasto", JsonConvert.SerializeObject(gastos));

                        return View(gastosSorted);
                    }
                    else
                    {
                        return View(listaActual);
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch(Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los gastos registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }


        public ActionResult RegistrarGasto()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorGasto controladorGasto = FabricaApps.GetControladorGasto();

                controladorGasto.IniciarRegistroGasto();

                HttpContext.Session.Set<Gasto>(SESSSION_ALTA, controladorGasto.GetGasto());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        

        [HttpPost]
        public ActionResult RegistrarGasto([FromForm]Gasto gasto)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Gasto gastoAlta = HttpContext.Session.Get<Gasto>(SESSSION_ALTA);

                    gastoAlta.Suma = gasto.Suma;
                    gastoAlta.Descripcion = gasto.Descripcion;
                    gastoAlta.Id = 0;

                    IControladorGasto controladorGasto = FabricaApps.GetControladorGasto();

                    controladorGasto.SetGasto(gastoAlta);

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorGasto.RegistrarGasto(gastoAlta);

                        if (exito)
                        {
                            controladorGasto.SetGasto(null);
                            mensaje = "El gasto se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el gasto!.";
                        }
                    }

                    if (mensaje != "")
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);
                    }

                    return RedirectToAction("Index");

                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }


            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }

        public ActionResult RegistrarImpuesto()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorImpuesto controladorImpuesto = FabricaApps.GetControladorImpuesto();

                controladorImpuesto.IniciarReigstroImpuesto();

                HttpContext.Session.Set<Impuesto>(SESSSION_ALTA, controladorImpuesto.GetImpuesto());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult RegistrarImpuesto([FromForm]Impuesto impuesto)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Impuesto impuestoAlta = HttpContext.Session.Get<Impuesto>(SESSSION_ALTA);

                    impuestoAlta.Nombre = impuesto.Nombre;
                    impuestoAlta.Descripcion = impuesto.Descripcion;
                    impuestoAlta.Id = 0;
                    impuestoAlta.Porcentaje = impuesto.Porcentaje;

                    IControladorImpuesto controladorImpuesto = FabricaApps.GetControladorImpuesto();

                    controladorImpuesto.SetImpuesto(impuestoAlta);

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorImpuesto.RegistrarImpuesto(impuestoAlta);

                        if (exito)
                        {
                            controladorImpuesto.SetImpuesto(null);
                            mensaje = "El impuesto se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el impuesto!.";
                        }
                    }

                    if (mensaje != "")
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);
                    }

                    return RedirectToAction("Index");

                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }


            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }

        public ActionResult RegistrarIngreso()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorIngreso controladorIngreso = FabricaApps.GetControladorIngreso();

                controladorIngreso.IniciarRegistroIngreso();

                HttpContext.Session.Set<Ingreso>(SESSSION_ALTA, controladorIngreso.GetIngreso());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }



        [HttpPost]
        public ActionResult RegistrarIngreso([FromForm]Ingreso ingreso)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Ingreso ingresoAlta = HttpContext.Session.Get<Ingreso>(SESSSION_ALTA);

                    ingresoAlta.Suma = ingreso.Suma;
                    ingresoAlta.Descripcion = ingreso.Descripcion;
                    ingresoAlta.Id = 0;

                    IControladorIngreso controladorIngreso = FabricaApps.GetControladorIngreso();

                    controladorIngreso.SetIngreso(ingresoAlta);

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorIngreso.ReigstrarIngreso(ingresoAlta);

                        if (exito)
                        {
                            controladorIngreso.SetIngreso(null);
                            mensaje = "El ingreso se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el ingreso!.";
                        }
                    }

                    if (mensaje != "")
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);
                    }

                    return RedirectToAction("Index");

                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }


            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }



        public async Task<ActionResult> ListarGastos()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorGasto controladorGasto = FabricaApps.GetControladorGasto();

                SortedList<string, string> gastosSorted = new SortedList<string, string>();

                List<Gasto> gastos = await controladorGasto.ListarGastos();

                gastosSorted.Add("Gasto", JsonConvert.SerializeObject(gastos));

                HttpContext.Session.Set<SortedList<string, string>>(SESSION_LISTA_ACTUAL, gastosSorted);

                return RedirectToAction("Index", "Valores", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
        public async Task<ActionResult> ListarImpuestos()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorImpuesto controladorImpuesto = FabricaApps.GetControladorImpuesto();

                    SortedList<string, string> impuestosSorted = new SortedList<string, string>();

                    List<Impuesto> impuestos = await controladorImpuesto.ListarImpuestos();

                    impuestosSorted.Add("Impuesto", JsonConvert.SerializeObject(impuestos));

                    HttpContext.Session.Set<SortedList<string, string>>(SESSION_LISTA_ACTUAL, impuestosSorted);

                    return RedirectToAction("Index", "Valores", new { area = "" });
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }



        public async Task<ActionResult> ListarIngresos()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorIngreso controladorIngreso = FabricaApps.GetControladorIngreso();

                SortedList<string, string> ingresosSorted = new SortedList<string, string>();

                List<Ingreso> ingresos = await controladorIngreso.ListarIngresos();

                ingresosSorted.Add("Ingreso", JsonConvert.SerializeObject(ingresos));

                HttpContext.Session.Set<SortedList<string, string>>(SESSION_LISTA_ACTUAL, ingresosSorted);

                return RedirectToAction("Index", "Valores", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

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
    }
}