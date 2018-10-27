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

                    HttpContext.Session.Set<List<Reclamo>>(SESSSION_RECLAMOS, null);

                    List<EntidadesCompartidasCore.Reclamo> reclamos = await controladorPaquete.ListarReclamos();

                    HttpContext.Session.Set<List<Reclamo>>(SESSSION_RECLAMOS, reclamos);

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }
                    List<Reclamo> filtrados = HttpContext.Session.Get<List<Reclamo>>(SESSION_FILTRADOS);

                    if (filtrados != null)
                    {
                        HttpContext.Session.Set<List<Reclamo>>(SESSION_FILTRADOS, null);

                        return View(filtrados);
                    }
                    else
                    {
                        return View(reclamos);
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
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los reclamos");

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
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
    }
}