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
    public class AdelantosController : Controller
    {

        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";
        public static string SESSION_ADELANTOS = "Adelantos";
        public static string SESSION_FILTRADOS = "Filtrados";
        public static string EMPLEADO_SELECCIONADO = "EmpleadoSeleccionado";


        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    
                    IControladorAdelanto controladorAdelanto = FabricaApps.GetControladorAdelanto();

                    int ci = HttpContext.Session.Get<int>(EMPLEADO_SELECCIONADO);
                   

                    List<Adelanto> adelantos = await controladorAdelanto.ListarAdelantosXEmpleado(ci);

                    if (adelantos == null)
                    {
                        adelantos = new List<Adelanto>();
                    }

                    //---------------------------------
                    //---------------------------------

                    bool habilitado = await controladorAdelanto.verificarAdelantoSaldado(ci);

                    ViewBag.Habilitado = habilitado;

                    //---------------------------------
                    //---------------------------------


                    if (TempData["Mensaje"] != null)
                    {
                        string mensaje = TempData["Mensaje"].ToString();
                        TempData["Mensaje"] = mensaje;
                    }


                    return View(adelantos);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Adelantos registrados");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los Adelantos registrados";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public ActionResult Alta()
        {
            if (ComprobarLogin() == "G")
            {
                int ci = HttpContext.Session.Get<int>(EMPLEADO_SELECCIONADO);

                ViewBag.Empleado = ci;

                if (TempData["Mensaje"] != null)
                {
                    string mensaje = TempData["Mensaje"].ToString();
                    TempData["Mensaje"] = mensaje;
                }

                return View();
            }
            else
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult Alta([FromForm]Adelanto adelanto)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    IControladorAdelanto controladorAdelanto = FabricaApps.GetControladorAdelanto();
                    
                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorAdelanto.RealizarAdelanto(adelanto);

                        if (exito)
                        {
                            mensaje = "El adelanto se registro exitosamente con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al registrar el adelanto!.";
                        }
                    }

                    if (mensaje != "")
                    {
                        TempData["Mensaje"] = mensaje;
                    }

                    return RedirectToAction("Index");

                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

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