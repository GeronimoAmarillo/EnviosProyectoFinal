using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdministradoresApp.Models;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministradoresApp.Controllers
{

    public class ValoresController : Controller
    {
        public static string SESSSION_ALTA = "AltaGasto";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorGasto controladorGasto = FabricaApps.GetControladorGasto();

                    List<Gasto> gastos = await controladorGasto.ListarGastos();

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    return View(gastos);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los gastos registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }


        public ActionResult RegistrarGasto()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorGasto controladorGasto = FabricaApps.GetControladorGasto();

                controladorGasto.IniciarRegistroGasto();

                HttpContext.Session.Set<Gasto>(SESSSION_ALTA, controladorGasto.GetGasto());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult RegistrarGasto([FromForm]Gasto gasto)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Gasto gastoAlta = HttpContext.Session.Get<Gasto>(SESSSION_ALTA);

                    gastoAlta.Suma = gasto.Suma;
                    gastoAlta.Descripcion = gasto.Descripcion;
                    gastoAlta.Id = 0;

                    IControladorGasto controladorGasto = FabricaApps.GetControladorGasto();

                    controladorGasto.SetGasto(gastoAlta);

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorGasto.RegistrarGasto(gastoAlta);

                        if (exito)
                        {
                            controladorGasto.SetGasto(null);
                            mensaje = "El gasto se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el gasto!.";
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