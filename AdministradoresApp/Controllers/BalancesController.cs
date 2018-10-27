using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;

namespace AdministradoresApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Balances")]
    public class BalancesController : Controller
    {
        public static string LOG_USER = "UsuarioLogueado";

        public static string SESSION_MENSAJE = "Mensaje";

        [HttpGet]
        public ActionResult ConsultarBalance()
        {
            Administrador adminLogueado = HttpContext.Session.Get<Administrador>(LOG_USER);
            if (adminLogueado != null)
            {
                if (adminLogueado.Tipo == "C")
                {
                    return View();
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Para consultar balances el tipo de administrador debe ser contable.");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No estas logueado en el sistema.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult ConsultarBalanceMensual(String mes, int anio)
        {
            try
            {
                IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();
                Balance balanceARetornar = controladorBalance.ConsultarBalanceMensual(mes, anio);
                if (balanceARetornar != null)
                {
                    return View(balanceARetornar);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult ConsultarBalanceAnual(int anio)
        {
            try
            {
                IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();
                List<Balance> balancesARetornar = controladorBalance.ConsultarBalanceAnual(anio);
                if (balancesARetornar != null)
                {
                    return View(balancesARetornar);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

    }
}