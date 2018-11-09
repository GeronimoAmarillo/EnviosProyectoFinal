using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.Controllers
{
    public class PaquetesController : Controller
    {
        public static string SESSION_PAQUETES = "Paquetes";
        public static string SESSION_FILTRADOS = "Filtrados";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin())
                {
                    IControladorConsultasPaquete controladorPaquete = FabricaApps.GetControladorConsultasPaquete();

                    HttpContext.Session.Set<List<Paquete>>(SESSION_PAQUETES, null);

                    Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                    List<Local> localesDDL = new List<Local>();

                    IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                    try
                    {
                        localesDDL = await controladorLocal.ListarLocales();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar los locales para filtrar.");
                    }

                    List<Paquete> paquetes = await controladorPaquete.ListarPaquetesEnviadosXCliente(cliente.RUT);

                    HttpContext.Session.Set<List<Paquete>>(SESSION_PAQUETES, paquetes);

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    List<Paquete> filtrados = HttpContext.Session.Get<List<Paquete>>(SESSION_FILTRADOS);

                    ViewBag.Locales = localesDDL;

                    List<object> estados = new List<object>();
                    estados.Add(new {Value = "Levantado", Text = "Levantado" });
                    estados.Add(new { Value = "Entregado", Text = "Entregado" });
                    estados.Add(new { Value = "Extraviado", Text = "Extraviado" });

                    ViewBag.Estados = estados;

                    if (filtrados != null)
                    {
                        HttpContext.Session.Set<List<Paquete>>(SESSION_FILTRADOS, null);

                        return View(filtrados);
                    }
                    else
                    {
                        return View(paquetes);
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult IniciarReclamo()
        {
            try
            {
                if (ComprobarLogin())
                {
                    return View();
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<ActionResult> IniciarReclamo([FromForm]int numReferencia)
        {
            try
            {
                if (ComprobarLogin())
                {
                    IControladorPaquete controladorPaquete = FabricaApps.GetControladorPaquete();

                    Paquete pPaquete = await controladorPaquete.BuscarPaquete(numReferencia);

                    if (pPaquete != null)
                    {

                        return RedirectToAction("IngresarReclamo", "Paquetes", new { numReferencia = pPaquete.NumReferencia });

                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                        return RedirectToAction("IniciarReclamo", "Paquetes", new { area = "" });
                    }

                    return View();
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        

        public async Task<ActionResult> IngresarReclamo(int numReferencia)
        {
            try
            {
                if (ComprobarLogin())
                {

                    IControladorPaquete controladorPaquete = FabricaApps.GetControladorPaquete();

                    Paquete pPaquete = await controladorPaquete.BuscarPaquete(numReferencia);

                    return View(pPaquete);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult IngresarReclamo([FromForm]string descripcion, [FromForm]int numReferencia)
        {
            try
            {
                if (ComprobarLogin())
                {
                    Reclamo reclamoAgregar = new Reclamo();

                    reclamoAgregar.Id = 0;
                    reclamoAgregar.Comentario = descripcion;
                    reclamoAgregar.Paquete = numReferencia;

                    IControladorPaquete controladorPaquete = FabricaApps.GetControladorPaquete();
                    

                    if (controladorPaquete.RealizarReclamo(reclamoAgregar))
                    {

                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Se registro su reclamo de forma exitosa.");

                        return RedirectToAction("Index", "Home", new { area = "" });

                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "Ocurrio un error al intentar ingresar el reclamo.");

                        return RedirectToAction("IniciarReclamo", "Paquetes", new { area = "" });
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public async Task<ActionResult> ListarRecibidos()
        {
            try
            {
                if (ComprobarLogin())
                {
                    IControladorConsultasPaquete controladorPaquete = FabricaApps.GetControladorConsultasPaquete();

                    HttpContext.Session.Set<List<Paquete>>(SESSION_PAQUETES, null);

                    Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                    List<Local> localesDDL = new List<Local>();

                    IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                    try
                    {
                        localesDDL = await controladorLocal.ListarLocales();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar los locales para filtrar.");
                    }

                    List<Paquete> paquetes = await controladorPaquete.ListarPaquetesRecibidosXCliente(cliente.RUT);

                    HttpContext.Session.Set<List<Paquete>>(SESSION_PAQUETES, paquetes);

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    List<Paquete> filtrados = HttpContext.Session.Get<List<Paquete>>(SESSION_FILTRADOS);

                    ViewBag.Locales = localesDDL;

                    List<object> estados = new List<object>();
                    estados.Add(new { Value = "Levantado", Text = "Levantado" });
                    estados.Add(new { Value = "Entregado", Text = "Entregado" });
                    estados.Add(new { Value = "Extraviado", Text = "Extraviado" });

                    ViewBag.Estados = estados;

                    if (filtrados != null)
                    {
                        HttpContext.Session.Set<List<Paquete>>(SESSION_FILTRADOS, null);

                        return View(filtrados);
                    }
                    else
                    {
                        return View(paquetes);
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult ConsultarEstado()
        {
            try
            {
                if (ComprobarLogin())
                {
                    return View();
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
        

        public async Task<ActionResult> ConsultarEstadoPost(int numReferencia)
        {
            try
            {
                if (ComprobarLogin())
                {
                    IControladorConsultasPaquete controladorPaquete = FabricaApps.GetControladorConsultasPaquete();

                    Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);


                    Paquete paquete = await controladorPaquete.BuscarPaqueteIndividual(numReferencia, cliente.RUT);

                    if (paquete != null)
                    {
                        return View(paquete);
                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el paquete seleccionado");

                        return RedirectToAction("ConsultarEstado", "Paquetes", new { area = "" });
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudo cargar el Paquete");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }


        public ActionResult Filtrar(string estado, DateTime fechaSalida, int? local, string criterio)
        {
            try
            {
                if (ComprobarLogin())
                {
                    List<Paquete> paquetes = HttpContext.Session.Get<List<Paquete>>(SESSION_PAQUETES);

                    List<Paquete> filtradosResultado = new List<Paquete>();

                    if (criterio == "Estado")
                    {
                        filtradosResultado = paquetes.Where(x => x.Estado.ToUpper() == estado.ToUpper()).ToList();
                    }

                    if (criterio == "Fecha")
                    {
                        filtradosResultado = paquetes.Where(x => x.FechaSalida.ToShortDateString() == fechaSalida.ToShortDateString()).ToList();
                    }

                    if (criterio == "Local")
                    {
                        filtradosResultado = paquetes.Where(x => x.Entregas.LocalReceptor == local).ToList();
                    }

                    if (criterio == "Todos")
                    {
                        filtradosResultado = paquetes.Where(x => x.Estado.ToUpper() == estado.ToUpper() && x.FechaSalida.ToShortDateString() == fechaSalida.ToShortDateString() && x.Entregas.LocalReceptor == local).ToList();
                    }

                    HttpContext.Session.Set<List<Paquete>>(SESSION_FILTRADOS, filtradosResultado);

                    return RedirectToAction("Index", "Paquetes", new { area = "" });
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes filtrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
           
        }

        public ActionResult FiltrarRecibidos(string estado, DateTime fechaSalida, int? local, string criterio)
        {
            try
            {
                if (ComprobarLogin())
                {
                    List<Paquete> paquetes = HttpContext.Session.Get<List<Paquete>>(SESSION_PAQUETES);

                    List<Paquete> filtradosResultado = new List<Paquete>();

                    if (criterio == "Estado")
                    {
                        filtradosResultado = paquetes.Where(x => x.Estado.ToUpper() == estado.ToUpper()).ToList();
                    }

                    if (criterio == "Fecha")
                    {
                        filtradosResultado = paquetes.Where(x => x.FechaSalida.ToShortDateString() == fechaSalida.ToShortDateString()).ToList();
                    }

                    if (criterio == "Local")
                    {
                        filtradosResultado = paquetes.Where(x => x.Entregas.LocalEmisor == local).ToList();
                    }

                    if (criterio == "Todos")
                    {
                        filtradosResultado = paquetes.Where(x => x.Estado.ToUpper() == estado.ToUpper() && x.FechaSalida.ToShortDateString() == fechaSalida.ToShortDateString() && x.Entregas.LocalReceptor == local).ToList();
                    }

                    HttpContext.Session.Set<List<Paquete>>(SESSION_FILTRADOS, filtradosResultado);

                    return RedirectToAction("ListarRecibidos", "Paquetes", new { area = "" });
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes filtrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public async Task<ActionResult> Detalles(int numReferencia, string accion)
        {
            try
            {
                if (ComprobarLogin())
                {
                    IControladorConsultasPaquete controladorPaquete = FabricaApps.GetControladorConsultasPaquete();

                    Paquete paquete = await controladorPaquete.BuscarPaquete(numReferencia);

                    if (paquete != null)
                    {
                        return View(paquete);
                    }
                    else
                    {
                        if (accion == "Enviados")
                        {
                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el paquete seleccionado");

                            return RedirectToAction("Index", "Paquetes", new { area = "" });
                        }
                        else
                        {
                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el paquete seleccionado");

                            return RedirectToAction("ListarRecibidos", "Paquetes", new { area = "" });
                        }
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudo cargar el Paquete");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public ActionResult IniciarTrackeo()
        {
            try
            {
                if (ComprobarLogin())
                {
                    return View();
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Paquetes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public async Task<ActionResult> IniciarTrackeoPost(int numReferencia)
        {
            try
            {
                if (ComprobarLogin())
                {
                    IControladorPaquete controladorPaquete = FabricaApps.GetControladorPaquete();

                    Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                    Geolocalizacion geo = await controladorPaquete.LocalizarPaquete(numReferencia, cliente.RUT);

                    if (geo != null)
                    {
                        if (geo.Cadete.Nombre != null && geo.Paquete.NumReferencia != 0)
                        {
                            if (geo.Paquete.Estado == "Entregado")
                            {
                                ViewBag.Entregado = true;
                            }
                            else
                            {
                                ViewBag.Entregado = false;
                            }

                            return View(geo);
                        }
                        else
                        {

                            
                            HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay paquetes que trackear para el cliente logueado");

                            return RedirectToAction("IniciarTrackeo", "Paquetes", new { area = "" });
                        }
                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el paquete seleccionado");

                        return RedirectToAction("IniciarTrackeo", "Paquetes", new { area = "" });
                    }
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un Cliente logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudo cargar el Paquete");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public bool ComprobarLogin()
        {
            try
            {
                Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                if (cliente != null)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Error al comprobar el logueo.");
            }
        }
    }
}