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

        
        public ActionResult Filtrar(string estado, DateTime fechaSalida, int? local, string criterio)
        {
            if (ComprobarLogin())
            {
                List<Paquete> paquetes = HttpContext.Session.Get<List<Paquete>>(SESSION_PAQUETES);

                List<Paquete> filtradosResultado = new List<Paquete>();

                if (criterio == "Estado")
                {
                    filtradosResultado = paquetes.Where(x => x.Estado.ToUpper() == estado).ToList();
                }

                if (criterio == "Fecha")
                {
                    filtradosResultado = paquetes.Where(x => x.FechaSalida == fechaSalida).ToList();
                }

                if (criterio == "Local")
                {
                    filtradosResultado = paquetes.Where(x => x.Entregas.LocalReceptor == local).ToList();
                }

                if (criterio == "Todos")
                {
                    filtradosResultado = paquetes.Where(x => x.Estado.ToUpper() == estado && x.FechaSalida == fechaSalida && x.Entregas.LocalReceptor == local).ToList();
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