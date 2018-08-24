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
    public class VehiculosController : Controller
    {

        public static string SESSSION_ALTA = "AltaVehiculo";
        public static string SESSSION_VEHICULOS = "Vehiculos";
        public static string SESSION_FILTRADOS = "Filtrados";
        public static string SESSSION_MODIFICAR = "ModificarVehiculo";
        public static string SESSION_MENSAJE = "Mensaje";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    HttpContext.Session.Set<List<Vehiculo>>(SESSSION_VEHICULOS, null);

                    List<Vehiculo> vehiculos = await controladorVehiculo.ListarVehiculos();

                    HttpContext.Session.Set<List<Vehiculo>>(SESSSION_VEHICULOS, vehiculos);

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
            catch(Exception ex)
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los Vehiculos registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }


        public async Task<ActionResult> AltaAuto()
        {
            if (ComprobarLogin() == "G")
            {
                HttpContext.Session.Set<Automobil>(SESSSION_ALTA, new Automobil());

                IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                List<Cadete> cadetes = await controladorVehiculo.ListarCadetesDisponibles();

                List<SelectListItem> items = new List<SelectListItem>();

                foreach (Cadete c in cadetes)
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = "Nombre: " + c.Nombre + " - Cedula: " + c.Ci + ".";
                    item.Value = c.CiEmpleado.ToString();

                    items.Add(item);
                }

                ViewBag.Cadetes = items;

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult AltaAuto([FromForm]Automobil auto, int cadete)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Automobil autoAlta = HttpContext.Session.Get<Automobil>(SESSSION_ALTA);

                    autoAlta.Matricula = auto.Vehiculos.Matricula;
                    autoAlta.Marca = auto.Vehiculos.Marca;
                    autoAlta.Modelo = auto.Vehiculos.Modelo;
                    autoAlta.Capacidad = auto.Vehiculos.Capacidad;
                    autoAlta.Cadete = cadete;
                    autoAlta.Estado = auto.Vehiculos.Estado;
                    autoAlta.Puertas = auto.Puertas;
                    autoAlta.MatriculaAuto = auto.MatriculaAuto;

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorVehiculo.AltaVehiculo(autoAlta);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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

        public ActionResult AltaCamion()
        {
            if (ComprobarLogin() == "G")
            {
                HttpContext.Session.Set<Camion>(SESSSION_ALTA, new Camion());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult AltaCamion([FromForm]Camion camion)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Camion camionAlta = HttpContext.Session.Get<Camion>(SESSSION_ALTA);

                    camionAlta.Matricula = camion.Vehiculos.Matricula;
                    camionAlta.Marca = camion.Vehiculos.Marca;
                    camionAlta.Modelo = camion.Vehiculos.Modelo;
                    camionAlta.Capacidad = camion.Vehiculos.Capacidad;
                    camionAlta.Cadete = camion.Vehiculos.Cadete;
                    camionAlta.Estado = camion.Vehiculos.Estado;
                    camionAlta.Altura = camion.Altura;
                    camionAlta.MatriculaCamion = camion.MatriculaCamion;

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorVehiculo.AltaVehiculo(camionAlta);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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

        public ActionResult AltaCamioneta()
        {
            if (ComprobarLogin() == "G")
            {
                HttpContext.Session.Set<Camioneta>(SESSSION_ALTA, new Camioneta());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult AltaCamioneta([FromForm]Camioneta camioneta)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Camioneta camionetaAlta = HttpContext.Session.Get<Camioneta>(SESSSION_ALTA);

                    camionetaAlta.Matricula = camioneta.Vehiculos.Matricula;
                    camionetaAlta.Marca = camioneta.Vehiculos.Marca;
                    camionetaAlta.Modelo = camioneta.Vehiculos.Modelo;
                    camionetaAlta.Capacidad = camioneta.Vehiculos.Capacidad;
                    camionetaAlta.Cadete = camioneta.Vehiculos.Cadete;
                    camionetaAlta.Estado = camioneta.Vehiculos.Estado;
                    camionetaAlta.Cabina = camioneta.Cabina;
                    camionetaAlta.MatriculaCamioneta = camioneta.MatriculaCamioneta;

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorVehiculo.AltaVehiculo(camionetaAlta);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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

        public ActionResult AltaMoto()
        {
            if (ComprobarLogin() == "G")
            {
                HttpContext.Session.Set<Moto>(SESSSION_ALTA, new Moto());

                return View();
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult AltaMoto([FromForm]Moto moto)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    Moto motoAlta = HttpContext.Session.Get<Moto>(SESSSION_ALTA);

                    motoAlta.Matricula = moto.Vehiculos.Matricula;
                    motoAlta.Marca = moto.Vehiculos.Marca;
                    motoAlta.Modelo = moto.Vehiculos.Modelo;
                    motoAlta.Capacidad = moto.Vehiculos.Capacidad;
                    motoAlta.Cadete = moto.Vehiculos.Cadete;
                    motoAlta.Estado = moto.Vehiculos.Estado;
                    motoAlta.Cilindrada = moto.Cilindrada;
                    motoAlta.MatriculaMoto = moto.MatriculaMoto;

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorVehiculo.AltaVehiculo(motoAlta);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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

        public ActionResult Modificar(Vehiculo vehiculo)
        {
            if (ComprobarLogin() == "G")
            {
                return View(vehiculo);
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult ModificarPost([FromForm]Vehiculo unVehiculo)
        {
            try
            {
                string mensaje = "";
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorVehiculo.ModificarVehiculo(unVehiculo);

                        if (exito)
                        {
                            mensaje = "El vehiculo se modificó con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al modificar el vehiculo!.";
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

            public ActionResult ListarAutos()
        {
            if (ComprobarLogin() == "G")
            {
                List<Vehiculo> autos = new List<Vehiculo>();
                List<Vehiculo> vehiculos = HttpContext.Session.Get<List<Vehiculo>>(SESSSION_VEHICULOS);

                foreach (Vehiculo v in vehiculos)
                {
                    if (v is Automobil)
                    {
                        autos.Add((Automobil)v);
                    }
                }

                HttpContext.Session.Set<List<Vehiculo>>(SESSION_FILTRADOS, autos);

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
        public ActionResult ListarCamiones()
        {
            if (ComprobarLogin() == "G")
            {
                List<Vehiculo> camiones = new List<Vehiculo>();
                List<Vehiculo> vehiculos = HttpContext.Session.Get<List<Vehiculo>>(SESSSION_VEHICULOS);

                foreach (Vehiculo v in vehiculos)
                {
                    if (v is Camion)
                    {
                        camiones.Add((Camion)v);
                    }
                }

                HttpContext.Session.Set<List<Vehiculo>>(SESSION_FILTRADOS, camiones);

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }



        public ActionResult ListarCamionetas()
        {
            if (ComprobarLogin() == "G")
            {
                List<Vehiculo> camionetas = new List<Vehiculo>();
                List<Vehiculo> vehiculos = HttpContext.Session.Get<List<Vehiculo>>(SESSSION_VEHICULOS);

                foreach (Vehiculo v in vehiculos)
                {
                    if (v is Camioneta)
                    {
                        camionetas.Add((Camioneta)v);
                    }
                }

                HttpContext.Session.Set<List<Vehiculo>>(SESSION_FILTRADOS, camionetas);

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public ActionResult ListarMotos()
        {
            if (ComprobarLogin() == "G")
            {
                List<Vehiculo> motos = new List<Vehiculo>();
                List<Vehiculo> vehiculos = HttpContext.Session.Get<List<Vehiculo>>(SESSSION_VEHICULOS);

                foreach (Vehiculo v in vehiculos)
                {
                    if (v is Moto)
                    {
                        motos.Add((Moto)v);
                    }
                }

                HttpContext.Session.Set<List<Vehiculo>>(SESSION_FILTRADOS, motos);

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
            else
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

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