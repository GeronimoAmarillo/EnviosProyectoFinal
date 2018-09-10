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

    public class ReparacionesController : Controller
    {
        public static string SESSSION_SELECCIONADO = "VehiculoSeleccionado";
        public static string LOG_USER = "UsuarioLogueado";
        public static string SESSION_REGISTRAR = "ReparacionRegistrar";
        public static string SESSION_MENSAJE = "Mensaje";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorReparacion controladorReparacion = FabricaApps.GetControladorReparacion();

                    string matriculaSeleccionado = HttpContext.Session.Get<string>(SESSSION_SELECCIONADO);

                    Vehiculo vehiculoSeleccionado = await controladorReparacion.SeleccionarVehiculo(matriculaSeleccionado);
                    
                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    ViewBag.Vehiculo = vehiculoSeleccionado;

                    return View(vehiculoSeleccionado.Reparaciones);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Vehiculos registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult AltaReparacion(string matricula)
        {
            if (ComprobarLogin() == "G")
            {
                ViewBag.Matricula = matricula;
                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult AltaReparacion([FromForm]Reparacion reparacion)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    IControladorReparacion controladorReparacion = FabricaApps.GetControladorReparacion();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorReparacion.RegistrarReparacion(reparacion);

                        if (exito)
                        {
                            mensaje = "La reparación se registro exitosamente!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al registrar la reparación!.";
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