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
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AdministradoresApp.Controllers
{

    public class EmpleadosController : Controller
    {

        public static string SESSSION_BAJA = "BajaEmpleado";
        public static string SESSSION_EMPLEADOS = "Empleados";
        public static string SESSION_FILTRADOS = "Filtrados";
        public static string SESSSION_ALTA = "AltaEmpleado";
        public static string SESSSION_MODIFICAR = "ModificarEmpleado";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";
        public static string EMPLEADO_SELECCIONADO = "EmpleadoSeleccionado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                    HttpContext.Session.Set<List<Empleado>>(SESSSION_EMPLEADOS, null);

                    List<Empleado> empleados = await controladorEmpleado.ListarEmpleados();

                    HttpContext.Session.Set<List<Empleado>>(SESSSION_EMPLEADOS, empleados);

                    string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                    HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                    if (mensaje != null && mensaje != "")
                    {
                        ViewBag.Message = mensaje;
                    }
                    List<Empleado> filtrados = HttpContext.Session.Get<List<Empleado>>(SESSION_FILTRADOS);

                    if (filtrados != null)
                    {
                        HttpContext.Session.Set<List<Empleado>>(SESSION_FILTRADOS, null);

                        return View(filtrados);
                    }
                    else
                    {
                        return View(empleados);
                    }
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
        public ActionResult Modificar(int ci)
        {
            if (ComprobarLogin() == "G")
            {
                IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                List<Empleado> empleados = HttpContext.Session.Get<List<Empleado>>(SESSSION_EMPLEADOS);

                Empleado emp = empleados.FirstOrDefault(x => x.Ci == ci);

                if (emp != null)
                {
                    HttpContext.Session.Set<Empleado>(EMPLEADO_SELECCIONADO, null);
                    HttpContext.Session.Set<Empleado>(EMPLEADO_SELECCIONADO, emp);

                    if (emp is Administrador)
                    {

                        return RedirectToAction("ModificarAdmin", "Empleados", new { area = "" });
                    }
                    else
                    {
                        return RedirectToAction("ModificarCadete", "Empleados", new { area = "" });
                    }

                    
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el empleado que desea modificar");

                    return RedirectToAction("Index", "Empleados", new { area = "" });
                }
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult ModificarAdmin()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                //List<Empleado> empleados = HttpContext.Session.Get<List<Empleado>>(SESSSION_EMPLEADOS);

                Empleado emp = HttpContext.Session.Get<Empleado>(EMPLEADO_SELECCIONADO);

                if (emp != null)
                {


                    return View(emp);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el empleado que desea modificar");

                    return RedirectToAction("Index", "Empleados", new { area = "" });
                }
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
        public ActionResult ModificarCadete()
        {
            if (ComprobarLogin() == "G")
            {
                IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                //List<Empleado> empleados = HttpContext.Session.Get<List<Empleado>>(SESSSION_EMPLEADOS);

                Empleado emp = HttpContext.Session.Get<Empleado>(EMPLEADO_SELECCIONADO);

                if (emp != null)
                {


                    return View(emp);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el empleado que desea modificar");

                    return RedirectToAction("Index", "Empleados", new { area = "" });
                }
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult ModificarAdmin([FromForm]Administrador empleado)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Administrador empModificar = new Administrador();


                    empModificar.Id = empleado.Id;
                    empModificar.IdUsuario = empleado.Id;
                    empModificar.Ci = empleado.Ci;
                    empModificar.Nombre = empleado.Nombre;
                    empModificar.NombreUsuario = empleado.NombreUsuario;
                    empModificar.Sueldo = empleado.Sueldo;
                    empModificar.Telefono = empleado.Telefono;
                    empModificar.Tipo = empleado.Tipo;
                    empModificar.Email = empleado.Email;
                    empModificar.Direccion = empleado.Direccion;
                    empModificar.Contraseña = empleado.Contraseña;




                    IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                    string mensaje = "";
                    
                        bool exito = controladorEmpleado.ModificarAdmnistrador(empModificar);

                        if (exito)
                        {
                            controladorEmpleado.SetEmpleado(null);
                            mensaje = "El administrador se modifico con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al modificar el administrador!.";
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

        [HttpPost]
        public ActionResult ModificarCadete([FromForm]Cadete empleado)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Cadete empModificar = new Cadete();


                    empModificar.Id = empleado.Id;
                    empModificar.IdUsuario = empleado.Id;
                    empModificar.NombreUsuario = empleado.NombreUsuario;
                    empModificar.Nombre = empleado.Nombre;
                    empModificar.Ci = empleado.Ci;
                    empModificar.Sueldo = empleado.Sueldo;
                    empModificar.Telefono = empleado.Telefono;
                    empModificar.TipoLibreta = empleado.TipoLibreta;
                    empModificar.Latitud = empleado.Latitud;
                    empModificar.Longitud = empleado.Longitud;
                    empModificar.Email = empleado.Email;
                    empModificar.Direccion = empleado.Direccion;
                    empModificar.Contraseña = empleado.Contraseña;




                    IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                    string mensaje = "";
                    
                        bool exito = controladorEmpleado.ModificarCadete(empModificar);

                        if (exito)
                        {
                            controladorEmpleado.SetEmpleado(null);
                            mensaje = "El cadete se modifico con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al modificar el cadete!.";
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
        public ActionResult AltaAdministrador()
        {
            
                if (ComprobarLogin() == "G")
                {
                    IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                    HttpContext.Session.Set<Administrador>(SESSSION_ALTA, controladorEmpleado.GetEmpleadoAdm());

                    return View();
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

           
        }    
        [HttpPost]
        public ActionResult AltaAdministrador([FromForm]Administrador administrador)
        {
            try
            {
                Administrador adm = new Administrador();

                if (ComprobarLogin() == "G")
                {

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

                    string mensaje = "";

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
        public ActionResult AltaCadete()
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
        public ActionResult ListarAdministrador()
        {
            if (ComprobarLogin() == "G")
            {
                List<Empleado> administradores = new List<Empleado>();
                List<Empleado> empleados = HttpContext.Session.Get<List<Empleado>>(SESSSION_EMPLEADOS);

                foreach (Empleado e in empleados)
                {
                    if (e is EntidadesCompartidasCore.Administrador)
                    {
                        administradores.Add((Administrador)e);
                    }
                }

                HttpContext.Session.Set<List<Empleado>>(SESSION_FILTRADOS, administradores);

                return RedirectToAction("Index", "Empleados", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
        public ActionResult ListarCadete()
        {
            if (ComprobarLogin() == "G")
            {
                List<Empleado> cadetes = new List<Empleado>();
                List<Empleado> empleados = HttpContext.Session.Get<List<Empleado>>(SESSSION_EMPLEADOS);

                foreach (Empleado e in empleados)
                {
                    if (e is Cadete)
                    {
                        cadetes.Add((Cadete)e);
                    }
                }

                HttpContext.Session.Set<List<Empleado>>(SESSION_FILTRADOS, cadetes);

                return RedirectToAction("Index", "Empleados", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }


        [HttpPost]
        public ActionResult AltaCadete([FromForm]Cadete administrador)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Cadete adm = new Cadete();

                    adm.Ci = administrador.Ci;
                    adm.Id = administrador.Id;
                    adm.Nombre = administrador.Nombre;
                    adm.NombreUsuario = administrador.NombreUsuario;
                    adm.Sueldo = administrador.Sueldo;
                    adm.Telefono = administrador.Telefono;
                    adm.Latitud = administrador.Latitud;
                    adm.Longitud = administrador.Longitud;
                    adm.TipoLibreta = administrador.TipoLibreta;
                    adm.Email = administrador.Email;
                    adm.Direccion = administrador.Direccion;
                    adm.Contraseña = administrador.Contraseña;

                    IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                    string mensaje = "";

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
        public async Task<ActionResult> EliminarEmpleado(int ci)
        {
            EntidadesCompartidasCore.Empleado empleado = new EntidadesCompartidasCore.Empleado();

            if (ComprobarLogin() == "G")
            {
                IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                empleado = await controladorEmpleado.BuscarEmpleado(ci);

                if (empleado != null)
                {
                    HttpContext.Session.Set<Empleado>(SESSSION_BAJA, empleado);

                    return View(empleado);
                }
                else
                {
                    HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el empleado que desea eliminar");

                    return RedirectToAction("Index", "Empleados", new { area = "" });
                }
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult EliminarEmpleado()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Empleado empEliminar = HttpContext.Session.Get<Empleado>(SESSSION_BAJA);



                    IControladorEmpleado controladorEmpleado = FabricaApps.GetControladorEmpleado();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorEmpleado.EliminarEmpleado(empEliminar);

                        if (exito)
                        {
                            controladorEmpleado.SetEmpleado(null);
                            mensaje = "El empleado se elimino con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al eliminar el empleado!.";
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