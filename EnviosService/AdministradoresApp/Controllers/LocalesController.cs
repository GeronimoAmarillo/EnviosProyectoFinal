using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidas;
using LogicaDeApps;
using AdministradoresApp.Models;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace EnviosService.Controllers
{
    [Produces("application/json")]
    [Route("api/Locales")]
    public class LocalesController : Controller
    {
        public static string SESSSION_ALTA = "AltaLocal";


        public ActionResult Index()
        {
            IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

            //ViewData["Locales"] = controladorLocal.ListarLocales();

            return View();
        }

        public ActionResult Alta()
        {
            IControladorLocal controladorLocal = FabricaApps.GetControladorLocal();

            controladorLocal.SetLocal(new Local());

            HttpContext.Session.Set<IControladorLocal>(SESSSION_ALTA, controladorLocal);

            return View();
        }

        [HttpPost]
        public ActionResult Alta(Local local)
        {
            IControladorLocal controladorLocal = HttpContext.Session.Get<IControladorLocal>(SESSSION_ALTA);

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

            return Redirect("Index");
        }

        [HttpGet]
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
        }
    }
}