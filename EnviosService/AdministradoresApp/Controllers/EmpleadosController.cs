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
    [Route("api/Empleados")]
    public class EmpleadosController : Controller
    {

        public static string SESSSION_ALTA = "AltaEmpleado";


        public ActionResult Index()
        {
            IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

            //ViewData["Locales"] = controladorLocal.ListarLocales();

            return View();
        }

        public ActionResult Alta()
        {
            IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

            controladorEmpleado.SetEmpleado(new Empleado());

            HttpContext.Session.Set<IControladorEmpleado>(SESSSION_ALTA, controladorEmpleado);

            return View();
        }

        [HttpPost]
        public ActionResult Alta(Empleado empleado)
        {
            IControladorEmpleado controladorEmpleado = HttpContext.Session.Get<IControladorEmpleado>(SESSSION_ALTA);

            bool exito = controladorEmpleado.AltaEmpleado();

            if (exito)
            {
                controladorEmpleado.SetEmpleado(null);
                ViewData["Mensaje"] = "El empleado se dio de alta con exito!.";
            }
            else
            {
                ViewData["Mensaje"] = "Se produjo un error al dar de alta el empleado!.";
            }

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Existe(int ci)
        {
            IControladorEmpleado controladorEmpleado = HttpContext.Session.Get<IControladorEmpleado>(SESSSION_ALTA);
            HttpContext.Session.Remove(SESSSION_ALTA);

            Empleado empleado = controladorEmpleado.GetEmpleado();

            if (!controladorEmpleado.ExisteEmpleado(ci))
            {

                controladorEmpleado.SetCi(ci);

                HttpContext.Session.Set<IControladorEmpleado>(SESSSION_ALTA, controladorEmpleado);
            }
            else
            {
                ViewData["Mensaje"] = "El empleado que desea ingresar ya existe en el sistema!.";

                return View();
            }

            return View();
        }
    }
}