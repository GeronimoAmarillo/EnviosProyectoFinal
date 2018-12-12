using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesCompartidasCore;
using LogicaDeAppsCore;
using AdministradoresApp.Models;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministradoresApp.Controllers
{

    public class TurnosController : Controller
    {
        public static string SESSSION_ALTA = "AltaTurno";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string SESSSION_MODIFICAR = "ModificarTurno";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorTurno controladorTurno = FabricaApps.GetControladorTurno();

                    List<Turno> turnos = await controladorTurno.ListarTurnos();

                    descargarMensaje();

                    return View(turnos);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los turnos");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los turnos";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }



        public ActionResult Alta()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorTurno controladorTurno = FabricaApps.GetControladorTurno();

                    controladorTurno.IniciarRegistroTurno();

                    HttpContext.Session.Set<Turno>(SESSSION_ALTA, controladorTurno.GetTurno());

                    List<SelectListItem> dias = new List<SelectListItem>();

                    //A, B, C, D, E, F, G1, G2, G3 y H

                    dias.Add(new SelectListItem() { Text = "Lunes", Value = "Lunes" });
                    dias.Add(new SelectListItem() { Text = "Martes", Value = "Martes" });
                    dias.Add(new SelectListItem() { Text = "Miercoles", Value = "Miercoles" });
                    dias.Add(new SelectListItem() { Text = "Jueves", Value = "Jueves" });
                    dias.Add(new SelectListItem() { Text = "Viernes", Value = "Viernes" });
                    dias.Add(new SelectListItem() { Text = "Sabado", Value = "Sabado" });
                    dias.Add(new SelectListItem() { Text = "Domingo", Value = "Domingo" });

                    ViewBag.Dias = dias;

                    return View();
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Turnos", new { area = "" });
                }

            }
            catch
            {

                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Turnos", new { area = "" });
            }
        }


        [HttpPost]
        public async Task<ActionResult> Alta([FromForm]Turno turno, [FromForm] string dia)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    if (ModelState.IsValid)
                    {

                        int hora = 0;

                        Turno turnoAlta = HttpContext.Session.Get<Turno>(SESSSION_ALTA);

                        turnoAlta.Codigo = "" + dia.Substring(0, 3).ToUpper() + turno.Hora.ToString().ToUpper() + "";
                        turnoAlta.Dia = dia;
                        turnoAlta.Hora = turno.Hora;
                        turnoAlta.Eliminado = false;

                        IControladorTurno controladorTurno = FabricaApps.GetControladorTurno();

                        controladorTurno.SetTurno(turnoAlta);

                        string mensaje = "";

                        bool exito = await controladorTurno.RegistrarTurno();

                        if (exito)
                        {
                            controladorTurno.SetTurno(null);

                            mensaje = "El turno se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el turno!.";
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
                        return View();
                    }
                    
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
                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("Index", "Turnos", new { area = "" });
            }

        }
        public async Task<ActionResult> Eliminar(string codigo)
        {
            if (ComprobarLogin() == "G")
            {
                IControladorTurno controladorTurno = FabricaApps.GetControladorTurno();

                Turno turno = await controladorTurno.BuscarTurno(codigo);

                if (turno != null)
                {
                    HttpContext.Session.Set<Turno>(SESSSION_MODIFICAR, turno);

                    descargarMensaje();

                    return View(turno);
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el turno que desea eliminar");

                    TempData["Mensaje"] = "No existe el turno que desea eliminar";

                    return RedirectToAction("Index", "Turnos", new { area = "" });
                }
            }
            else
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult Eliminar([FromForm]Turno turno)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Turno turnomodificar = HttpContext.Session.Get<Turno>(SESSSION_MODIFICAR);
                    
                    
                    IControladorTurno controladorTurno = FabricaApps.GetControladorTurno();

                    string mensaje = "";
                    
                        bool exito = controladorTurno.Eliminar(turnomodificar);

                        if (exito)
                        {
                            controladorTurno.SetTurno(null);
                            mensaje = "El turno se elimino con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de baja el turno!.";
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

                return RedirectToAction("Index", "Locales", new { area = "" });
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