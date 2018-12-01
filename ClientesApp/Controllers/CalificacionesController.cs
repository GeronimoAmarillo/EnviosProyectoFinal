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
        public static string SESSION_CALIFICACIONES = "Calificaciones";
        public static string CLIENTE_SELECCIONADO = "ClienteSeleccionado";

        public ActionResult Calificar()
        {
            if (ComprobarLogin())
            {

                Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                ViewBag.Cliente = cliente.RUT;

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

                TempData["Mensaje"] = "No hay un usuario de tipo Cliente logueado en el sistema";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult Calificar([FromForm] Calificacion calificacion)
        {
            try
            {
                if (ComprobarLogin())
                {
                    IControladorCalificacion controladorCalificacion = FabricaApps.GetControladorCalificacion();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorCalificacion.Calificar(calificacion);
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
                        TempData["Mensaje"] = mensaje;
                    }

                    return RedirectToAction("Index", "Home", new { area = "" });
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
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario. ");

                TempData["Mensaje"] = "Error al mostrar el formulario.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public async  Task<ActionResult> CalificarNuevo([FromForm] int calificacion, [FromForm] string comentario)
        {
            try
            {
                if (ComprobarLogin())
                {

                    Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                    if (cliente != null)
                    {
                        IControladorCalificacion controladorCalificacion = FabricaApps.GetControladorCalificacion();
                        string mensaje = "";

                        Calificacion calificacionNueva = new Calificacion();
                        calificacionNueva.Id = 0;
                        calificacionNueva.Puntaje = calificacion;
                        calificacionNueva.RutCliente = cliente.RUT;
                        calificacionNueva.Comentario = comentario;

                        if (ModelState.IsValid)
                        {
                            bool exito = controladorCalificacion.Calificar(calificacionNueva);
                            if (exito)
                            {

                                List<Calificacion> calificaciones = await controladorCalificacion.ListarCalificaciones();

                                HttpContext.Session.Set<List<Calificacion>>(SESSION_CALIFICACIONES, calificaciones);

                                mensaje = "La calificacion se registro exitosamente!.";
                            }
                            else
                            {
                                mensaje = "Se produjo un error al registrar la calificacion.";
                            }
                        }

                        if (mensaje != "")
                        {
                            TempData["Mensaje"] = mensaje;
                        }

                        return RedirectToAction("Index", "Home", new { area = "" });

                    }
                    else
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario logueado en el sistema");

                        TempData["Mensaje"] = "No hay un usuario logueado en el sistema";

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception ex)
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario. ");

                TempData["Mensaje"] = "Error al mostrar el formulario.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public bool ComprobarLogin()
        {
            try
            {
                Cliente cliente = HttpContext.Session.Get<Cliente>(LOG_USER);

                if (cliente != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Error al comprobar el logueo.");
            }
        }
    }
}