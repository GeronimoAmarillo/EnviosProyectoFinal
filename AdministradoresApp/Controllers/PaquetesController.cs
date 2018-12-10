using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using AdministradoresApp.Models;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using System.Diagnostics;
namespace AdministradoresApp.Controllers
{
   
    public class PaquetesController : Controller
    {
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";
        public static string SESSSION_RECLAMOS = "Reclamos";
        public static string SESSION_FILTRADOS = "Filtrados";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorPaquete controladorPaquete = FabricaApps.GetControladorPaquete();

                    List<EntidadesCompartidasCore.Reclamo> reclamos = await controladorPaquete.ListarReclamos();
                    
                    descargarMensaje();
                    
                    return View(reclamos);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch(Exception ex)
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los reclamos");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los reclamos";

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
        public ActionResult ListarReclamoporPaquete(int numReferencia,string Buscar)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    switch (Buscar)
                    {
                        case "Buscar Reclamo":
                            List<Reclamo> reclamosF = new List<Reclamo>();
                            List<Reclamo> reclamos = HttpContext.Session.Get<List<Reclamo>>(SESSSION_RECLAMOS);

                            foreach (Reclamo r in reclamos)
                            {
                                if (r.Paquete == numReferencia)
                                {
                                    reclamosF.Add(r);
                                }
                            }

                            HttpContext.Session.Set<List<Reclamo>>(SESSION_FILTRADOS, reclamosF);

                            return RedirectToAction("Index", "Paquetes", new { area = "" });

                        case "Volver":
                            HttpContext.Session.Set<List<Reclamo>>(SESSION_FILTRADOS, null);
                            return RedirectToAction("Index", "Paquetes", new { area = "" });
                    }
                    return RedirectToAction("Index", "Paquetes", new { area = "" });
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
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Paquetes", new { area = "" });
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