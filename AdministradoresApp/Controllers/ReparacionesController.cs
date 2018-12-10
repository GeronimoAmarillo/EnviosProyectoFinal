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

                    descargarMensaje();

                    ViewBag.Vehiculo = vehiculoSeleccionado;

                    return View(vehiculoSeleccionado.Reparaciones);
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
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Vehiculos registrados");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los Vehiculos registrados";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult AltaReparacion(string matricula)
        {
            if (ComprobarLogin() == "G")
            {
                ViewBag.Matricula = matricula;

                HttpContext.Session.Set<string>("Matricula", matricula);

                

                descargarMensaje();

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

                        HttpContext.Session.Set<string>("Matricula", null);

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
                    else
                    {
                        string matricula = HttpContext.Session.Get<string>("Matricula");


                        ViewBag.Matricula = matricula;

                        return View();
                    }

                    if (mensaje != "")
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);

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
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Turnos", new { area = "" });
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

        public void cargarMensaje(string mensaje)
        {
            try
            {
                TempData["Mensaje"] = mensaje;
            }
            catch
            {
                throw new Exception("Error al cargar el mensaje.");
            }
        }

        public void descargarMensaje()
        {
            try
            {
                if (TempData["Mensaje"] != null)
                {
                    string mensaje = TempData["Mensaje"].ToString();
                    TempData["Mensaje"] = mensaje;
                }
            }
            catch
            {
                throw new Exception("Error al descargar el mensaje.");
            }
        }
    }
}