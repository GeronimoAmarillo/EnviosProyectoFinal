using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using AdministradoresApp.Models;
using System.Diagnostics;

namespace AdministradoresApp.Controllers
{
    
    public class MultasController : Controller
    {
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";
        public static string SESSSION_VEHICULOS = "Vehiculos";
        public static string SESSSION_SELECCIONADO = "VehiculoSeleccionado";

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

                    return View(vehiculoSeleccionado.Multas);
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

        public ActionResult Registrar(string matricula)
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
        public ActionResult Registrar([FromForm]Multa multa)
        {
            try
            {
                if(ComprobarLogin() == "G")
                {
                    IControladorMulta controladorMulta = FabricaApps.GetControladorMulta();
                    string mensaje = "";

                    if (ModelState.IsValid)
                    {

                        bool exito = controladorMulta.RegistrarMulta(multa);

                        if (exito)
                        {
                            mensaje = "La multa se registró con exito!";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al registrar la multa.";
                        }
                    }
                    else
                    {
                        return View();
                    }

                    if (mensaje != "")
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);
                        ViewBag.Message = mensaje;
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