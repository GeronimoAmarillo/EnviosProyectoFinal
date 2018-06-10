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
        
        public async Task<ActionResult> Index()
        {
            IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

            List<Local> locales = await controladorLocal.ListarLocales();
            
            return View(locales);
        }
        

        public ActionResult Alta()
        {
            IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

            controladorLocal.IniciarRegistroLocal();

            HttpContext.Session.Set<Local>(SESSSION_ALTA, controladorLocal.GetLocal());

            return View();
        }

        [HttpPost]
        public ActionResult Alta([FromForm]Local local)
        {
            try
            {

                Local localAlta = HttpContext.Session.Get<Local>(SESSSION_ALTA);

                localAlta.Direccion = local.Direccion;
                localAlta.Nombre = local.Nombre;

                IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

                controladorLocal.SetLocal(localAlta);

                if (ModelState.IsValid)
                {
                    bool exito = controladorLocal.AltaLocal();

                    if (exito)
                    {
                        controladorLocal.SetLocal(null);
                        ViewData["Mensaje"] = "El local se dio de alta con exito!.";
                    }
                    else
                    {
                        ViewData["Mensaje"] = "Se produjo un error al dar de alta el local!.";
                    }
                }

                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            
        }

        /*[HttpGet]
        public ActionResult Existe(string nombre, string direccion)
        {
            IControladorLocal controladorLocal = HttpContext.Session.Get<IControladorLocal>(SESSSION_ALTA);
            HttpContext.Session.Remove(SESSSION_ALTA);

            Local local = controladorLocal.GetLocal();

            if (!controladorLocal.ExisteLocal(nombre, direccion))
            {
                local.Nombre = nombre;
                local.Direccion = direccion;

                controladorLocal.SetLocal(local);

                HttpContext.Session.Set<IControladorLocal>(SESSSION_ALTA, controladorLocal);
            }
            else
            {
                ViewData["Mensaje"] = "El local que desea ingresar ya existe en el sistema!.";

                return View();
            }

            return View();
        }*/
    }
}