using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdministradoresApp.Controllers
{
    public class PaletsController : Controller
    {
        public static string SESSSION_PALETS = "Palets";
        public static string SESSION_FILTRADOS = "FiltradosP";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    IControladorPalet controladorPalet = FabricaApps.GetControladorPalet();

                    List<Palet> palets = await controladorPalet.ListarPalets();

                    descargarMensaje();

                    string paletsStr = JsonConvert.SerializeObject(palets);

                    HttpContext.Session.Set<string>(SESSSION_PALETS, null);
                    HttpContext.Session.Set<string>(SESSSION_PALETS, paletsStr);

                    string paletsFiltrados = HttpContext.Session.Get<string>(SESSION_FILTRADOS);

                    List<Palet> filtrados = JsonConvert.DeserializeObject<List<Palet>>(paletsFiltrados);

                    if (filtrados != null)
                    {
                        HttpContext.Session.Set<string>(SESSION_FILTRADOS, null);
                        return View(filtrados);
                    }
                    else
                    {
                        return View(palets);
                    }
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los Locales registrados";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult EnAlmacenamiento()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    string paletsStr = HttpContext.Session.Get<string>(SESSSION_PALETS);

                    List<Palet> palets = JsonConvert.DeserializeObject<List<Palet>>(paletsStr);

                    List<Palet> paletsR = palets.Where(x => x.fechaSalida == null).ToList();
                    
                    string paletsFiltrados = JsonConvert.SerializeObject(paletsR);

                    HttpContext.Session.Set<string>(SESSION_FILTRADOS, paletsFiltrados);

                    return RedirectToAction("Index", "Palets", new { area = "" });
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los Locales registrados";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult Despachados()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    string paletsStr = HttpContext.Session.Get<string>(SESSSION_PALETS);

                    List<Palet> palets = JsonConvert.DeserializeObject<List<Palet>>(paletsStr);

                    List<Palet> paletsR = palets.Where(x => x.fechaSalida != null).ToList();

                    string paletsFiltrados = JsonConvert.SerializeObject(paletsR);

                    HttpContext.Session.Set<string>(SESSION_FILTRADOS, paletsFiltrados);

                    return RedirectToAction("Index", "Palets", new { area = "" });
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los Locales registrados";

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