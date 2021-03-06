﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                Administrador adminLogueado = HttpContext.Session.Get<Administrador>(LOG_USER);
                if (adminLogueado != null)
                {
                    if (adminLogueado.Tipo == "C")
                    {
                        if (TempData["Mensaje"] != null)
                        {
                            string mensaje = TempData["Mensaje"].ToString();
                            TempData["Mensaje"] = mensaje;
                        }

                        return View();
                    }
                    else
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Para consultar balances el tipo de administrador debe ser contable.");

                        TempData["Mensaje"] = "Para consultar balances el tipo de administrador debe ser contable.";

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No estas logueado en el sistema.");

                    TempData["Mensaje"] = "No estas logueado en el sistema.";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }

        [HttpPost("ConsultarBalanceMensual")]
        public async Task<ActionResult> ConsultarBalanceMensual([FromForm]String mes, int anio)
        {
            try
            {
                IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();
                Balance balanceARetornar = await controladorBalance.ConsultarBalanceMensual(mes, anio);
                if (balanceARetornar != null)
                {
                    if (TempData["Mensaje"] != null)
                    {
                        string mensaje = TempData["Mensaje"].ToString();
                        TempData["Mensaje"] = mensaje;
                    }

                    return View(balanceARetornar);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                    TempData["Mensaje"] = "Error al consultar el balance.";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                TempData["Mensaje"] = "Error al consultar el balance.";

                return RedirectToAction("ConsultarBalance", "Balances", new { area = "" });
            }
        }

        [HttpPost("ConsultarBalanceAnual")]
        public async Task<ActionResult> ConsultarBalanceAnual([FromForm]DateTime fDesde, DateTime fHasta)
        {
            try
            {

                IControladorBalance controladorBalance = FabricaApps.GetControladorBalance();
                Balance balanceARetornar = await controladorBalance.ObtenerBalanceAnual(fDesde, fHasta);

                if (balanceARetornar != null)
                {
                    if (TempData["Mensaje"] != null)
                    {
                        string mensaje = TempData["Mensaje"].ToString();
                        TempData["Mensaje"] = mensaje;
                    }

                    return View(balanceARetornar);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                    TempData["Mensaje"] = "Error al consultar el balance.";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al consultar el balance.");

                TempData["Mensaje"] = "Error al consultar el balance.";

                return RedirectToAction("ConsultarBalance", "Balances", new { area = "" });
            }
        }

    }
}