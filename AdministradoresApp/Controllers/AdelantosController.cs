using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<IActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    HttpContext.Session.Set<List<Vehiculo>>(SESSION_ADELANTOS, null);

                    List<Vehiculo> vehiculos = await controladorVehiculo.ListarVehiculos();

                    HttpContext.Session.Set<List<Vehiculo>>(SESSION_ADELANTOS, vehiculos);

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    List<Vehiculo> filtrados = HttpContext.Session.Get<List<Vehiculo>>(SESSION_FILTRADOS);

                    if (filtrados != null)
                    {
                        HttpContext.Session.Set<List<Vehiculo>>(SESSION_FILTRADOS, null);

                        return View(filtrados);
                    }
                    else
                    {
                        return View(vehiculos);
                    }
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