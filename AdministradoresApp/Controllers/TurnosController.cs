﻿using System;
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
namespace AdministradoresApp.Controllers
{

    public class TurnosController : Controller
    {
        public static string SESSSION_ALTA = "AltaTurno";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorTurno controladorTurno = FabricaApps.GetControladorTurno();

                    List<Turno> turnos = await controladorTurno.ListarTurnos();

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }

                    return View(turnos);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

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

                    return View();
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }


        [HttpPost]
        public ActionResult Alta([FromForm]Turno turno)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {



                    if (ModelState.IsValid)
                    {
                        Turno turnoAlta = HttpContext.Session.Get<Turno>(SESSSION_ALTA);

                        turnoAlta.Codigo = "" + turno.Dia.Substring(0, 3).ToUpper() + turno.Hora.ToString().ToUpper() + "";
                        turnoAlta.Dia = turno.Dia;
                        turnoAlta.Hora = turno.Hora;

                        IControladorTurno controladorTurno = FabricaApps.GetControladorTurno();

                        controladorTurno.SetTurno(turnoAlta);

                        string mensaje = "";

                        bool exito = controladorTurno.RegistrarTurno();

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
                            HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);
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