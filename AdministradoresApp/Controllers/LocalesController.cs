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
    public class LocalesController : Controller
    {
        public static string SESSSION_ALTA = "AltaLocal";
        public static string SESSSION_MODIFICAR = "ModificarLocal";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                //if (ComprobarLogin() == "G")
                //{
                    IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                    List<Local> locales = await controladorLocal.ListarLocales();

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    return View(locales);
                //}
                //else
                //{
                //    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                //    return RedirectToAction("Index", "Home", new { area = "" });
                //}
                
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }
        

        public ActionResult Alta()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                controladorLocal.IniciarRegistroLocal();

                HttpContext.Session.Set<Local>(SESSSION_ALTA, controladorLocal.GetLocal());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }

        [HttpPost]
        public ActionResult Alta([FromForm]Local local)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Local localAlta = HttpContext.Session.Get<Local>(SESSSION_ALTA);

                    localAlta.Direccion = local.Direccion;
                    localAlta.Nombre = local.Nombre;

                    IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                    controladorLocal.SetLocal(localAlta);

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorLocal.AltaLocal();

                        if (exito)
                        {
                            controladorLocal.SetLocal(null);
                            mensaje = "El local se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el local!.";
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
            catch(Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            
        }

        public async Task<ActionResult> Modificar(int id)
        {
            if (ComprobarLogin() == "G")
            {
                IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                Local local = await controladorLocal.BuscarLocal(id);

                if (local != null)
                {
                    HttpContext.Session.Set<Local>(SESSSION_MODIFICAR, local);

                    return View(local);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el local que desea modificar");

                    return RedirectToAction("Index", "Locales", new { area = "" });
                }
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult Modificar([FromForm]Local local)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Local localModificar = HttpContext.Session.Get<Local>(SESSSION_MODIFICAR);

                    localModificar.Id = local.Id;
                    localModificar.Direccion = local.Direccion;
                    localModificar.Nombre = local.Nombre;

                    IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorLocal.ModificarLocal(localModificar);

                        if (exito)
                        {
                            controladorLocal.SetLocal(null);
                            mensaje = "El local se modifico con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el local!.";
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