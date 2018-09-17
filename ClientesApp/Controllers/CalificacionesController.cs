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
    public class CalificacionesController : Controller
    {
        public static string LOG_USER = "UsuarioLogueado";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string CLIENTE_SELECCIONADO = "ClienteSeleccionado";

        public ActionResult Calificar()
        {
            if (ComprobarLogin() == "G")
            {
                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult Calificar([FromForm] Calificacion calificacion)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorCalificacion controladorCalificacion = FabricaApps.GetControladorCalificacion();
                    string mensaje = "";
                    if (ModelState.IsValid)
                    {
                        bool exito = controladorCalificacion.Calificar(calificacion.Puntaje, calificacion.Comentario, calificacion.RutCliente);
                        if (exito)
                        {
                            mensaje = "La calificacion se registro exitosamente!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al registrar la calificacion.";
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
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario. ");

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