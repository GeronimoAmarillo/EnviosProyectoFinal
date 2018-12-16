using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministradoresApp.Controllers
{
    public class RegistrosController : Controller
    {


        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "C")
                {
                    descargarMensaje();

                    List<SelectListItem> itemsAños = new List<SelectListItem>();
                    List<SelectListItem> itemsMeses = new List<SelectListItem>();

                    int añoCero = 1990;
                    int mesCero = 1;

                    while (añoCero <= DateTime.Now.Year)
                    {
                        itemsAños.Add(new SelectListItem() { Text = añoCero.ToString(), Value = añoCero.ToString() });
                        añoCero++;
                    }

                    while (mesCero <= 12)
                    {
                        itemsMeses.Add(new SelectListItem() { Text = mesCero.ToString(), Value = mesCero.ToString() });
                        mesCero++;
                    }

                    ViewBag.Años = itemsAños;
                    ViewBag.Meses = itemsMeses;

                    return View();
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


        [HttpPost]
        public async Task<ActionResult> ConsultarRegistro([FromForm] string Año, [FromForm] string Mes)
        {
            try
            {
                if (ComprobarLogin() == "C")
                {
                    IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();

                    DateTime fecha = Convert.ToDateTime(Mes+"/1/"+Año);

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

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    ViewBag.Ingresos = itemsIngresos;
                    ViewBag.Gastos = itemsGastos;
                    ViewBag.Impuestos = itemsImpuestos;

                    descargarMensaje();

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



        [HttpPost]
        public async Task<ActionResult> ConsultarRegistros([FromForm] string AñoInicial, [FromForm] string MesInicial, [FromForm] string AñoFinal, [FromForm] string MesFinal)
        {
            try
            {
                if (ComprobarLogin() == "C")
                {
                    int añoi = Convert.ToInt32(AñoInicial);
                    int añof = Convert.ToInt32(AñoFinal);
                    int mesi = Convert.ToInt32(MesInicial);
                    int mesf = Convert.ToInt32(MesFinal);


                    if (añoi == añof)
                    {
                        if (mesi < mesf)
                        {
                            IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();

                            DateTime fechaInicial = Convert.ToDateTime(MesInicial+"/1/"+ AñoInicial);
                            DateTime fechaFinal = Convert.ToDateTime(MesFinal + "/1/" + AñoFinal);

                            List<Registro> registros = await controladorBalance.ConsultarRegistros(fechaInicial, fechaFinal);

                            descargarMensaje();
                            return View(registros);
                        }
                        else
                        {
                            //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No puede seleccionar una combinacion mas antigua en el tiempo que la combinacion Inicial.");

                            TempData["Mensaje"] = "No puede seleccionar una combinacion mas antigua en el tiempo que la combinacion Inicial.";

                            return RedirectToAction("Index", "Registros", new { area = "" });
                        }
                    }
                    else if (añof < añoi)
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No puede seleccionar como año final un valor inferior al año inicial.");

                        TempData["Mensaje"] = "No puede seleccionar como año final un valor inferior al año inicial.";

                        return RedirectToAction("Index", "Registros", new { area = "" });
                    }
                    else
                    {
                        IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();

                        DateTime fechaInicial = Convert.ToDateTime("1/" + MesInicial + "/" + AñoInicial);
                        DateTime fechaFinal = Convert.ToDateTime("1/" + MesFinal + "/" + AñoFinal);

                        List<Registro> registros = await controladorBalance.ConsultarRegistros(fechaInicial, fechaFinal);

                        descargarMensaje();

                        return View(registros);
                    }
                    
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


        public async Task<ActionResult> Detalles(int mes, int año)
        {
            try
            {
                if (ComprobarLogin() == "C")
                {
                    IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();

                    DateTime fecha = Convert.ToDateTime(mes+"/1/"+año);

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

        public void cargarMensaje(string mensaje)
        {
            try
            {
                TempData["Mensaje"] = mensaje;
            }
            catch
            {
                throw new Exception("Error al cargar el mensaje.");
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
    }
}