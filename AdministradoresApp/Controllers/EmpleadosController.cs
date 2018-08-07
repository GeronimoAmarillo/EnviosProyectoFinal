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

namespace AdministradoresApp.Controllers
{
   
    public class EmpleadosController : Controller
    {
        public static string SESSSION_ALTA = "AltaEmpleado";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";
        public static string EMPLEADO_SELECCIONADO = "EmpleadoSeleccionado";

        public async Task<ActionResult> Index()
        {
            try
            {
                ////if (ComprobarLogin() == "G")
                ////{
                IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                List<Empleado> empleados = await controladorEmpleado.ListarEmpleados();

                string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                if (mensaje != null && mensaje != "")
                {
                    ViewBag.Message = mensaje;
                }

                return View(empleados);
                //}
                //else
                //{
                //    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                //    return RedirectToAction("Index", "Home", new { area = "" });
                //}

            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Locales registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult Adelantos(int ci)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    HttpContext.Session.Set<int?>(EMPLEADO_SELECCIONADO, null);

                    HttpContext.Session.Set<int?>(EMPLEADO_SELECCIONADO, ci);

                    return RedirectToAction("Index", "Adelantos", new { area = "" });
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

        public ActionResult AltaAdministrador()
        {
            //if (ComprobarLogin() == "G")
            //{
                IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();
             
                HttpContext.Session.Set<Empleado>(SESSSION_ALTA, controladorEmpleado.GetEmpleado());

                return View();
            //}
            //else
            //{
            //    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}

        }
        public ActionResult AltaCadete()
        {
            //if (ComprobarLogin() == "G")
            //{
            IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

            HttpContext.Session.Set<Empleado>(SESSSION_ALTA, controladorEmpleado.GetEmpleado());

            return View();
            //}
            //else
            //{
            //    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}

        }
        [HttpPost]
        public ActionResult AltaAdministrador([FromForm]Administrador administrador)
        {
            try
            {
                //if (ComprobarLogin() == "G")
                //{

                    Administrador adm = HttpContext.Session.Get<Administrador>(SESSSION_ALTA);

                    adm.Ci = administrador.Ci;
                    adm.Id = administrador.Id;
                    adm.Nombre = administrador.Nombre;
                    adm.NombreUsuario = administrador.NombreUsuario;
                    adm.Sueldo = administrador.Sueldo;
                    adm.Telefono = administrador.Telefono;
                    adm.Tipo = administrador.Tipo;
                    adm.Email = administrador.Email;
                    adm.Direccion = administrador.Direccion;
                    adm.Contraseña = administrador.Contraseña;

                    IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                    controladorEmpleado.SetEmpleado(adm);

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorEmpleado.AltaEmpleadoAdministrador(adm);

                        if (exito)
                        {
                            controladorEmpleado.SetEmpleado(null);
                            mensaje = "El local se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el local!.";
                        }
                    }

                    if (mensaje != "")
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);
                    }

                    return RedirectToAction("Index");

                //}
                //else
                //{
                //    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                //    return RedirectToAction("Index", "Home", new { area = "" });
                //}


            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }
        [HttpPost]
        public ActionResult AltaCadete([FromForm]Cadete administrador)
        {
            try
            {
                //if (ComprobarLogin() == "G")
                //{

                Cadete adm = HttpContext.Session.Get<Cadete>(SESSSION_ALTA);

                adm.Ci = administrador.Ci;
                adm.Id = administrador.Id;
                adm.Nombre = administrador.Nombre;
                adm.NombreUsuario = administrador.NombreUsuario;
                adm.Sueldo = administrador.Sueldo;
                adm.Telefono = administrador.Telefono;
                adm.IdTelefono = administrador.IdTelefono;
                adm.TipoLibreta = administrador.TipoLibreta;
                adm.Email = administrador.Email;
                adm.Direccion = administrador.Direccion;
                adm.Contraseña = administrador.Contraseña;

                IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                controladorEmpleado.SetEmpleado(adm);

                string mensaje = "";

                if (ModelState.IsValid)
                {
                    bool exito = controladorEmpleado.AltaEmpleadoCadete(adm);

                    if (exito)
                    {
                        controladorEmpleado.SetEmpleado(null);
                        mensaje = "El local se dio de alta con exito!.";
                    }
                    else
                    {
                        mensaje = "Se produjo un error al dar de alta el local!.";
                    }
                }

                if (mensaje != "")
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, mensaje);
                }

                return RedirectToAction("Index");

                //}
                //else
                //{
                //    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                //    return RedirectToAction("Index", "Home", new { area = "" });
                //}


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