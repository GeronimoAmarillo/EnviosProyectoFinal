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
        public static string SESSION_BAJA = "BajaVehiculo";
        public static string SESSSION_VEHICULOS = "Vehiculos";
        public static string SESSION_FILTRADOS = "Filtrados";
        public static string SESSSION_MODIFICAR = "ModificarVehiculo";
        public static string SESSSION_SELECCIONADO = "VehiculoSeleccionado";
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

                    descargarMensaje();

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

        public async Task<ActionResult> BajaVehiculo(string matricula)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    Vehiculo vehiculo = await controladorVehiculo.BuscarVehiculo(matricula);

                    HttpContext.Session.Set<Vehiculo>(SESSION_BAJA, vehiculo);
                    descargarMensaje();
                    return View(vehiculo);

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
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
            

        }

        [HttpPost]
        public ActionResult BajaVehiculoPost()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    Vehiculo vehiculoBaja = HttpContext.Session.Get<Vehiculo>(SESSION_BAJA);

                    HttpContext.Session.Set<Vehiculo>(SESSION_BAJA, null);

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";

                    if (ModelState.IsValid)
                    {
                        bool exito = controladorVehiculo.EliminarVehiculo(vehiculoBaja);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de baja con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de baja el vehiculo!.";
                        }
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

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }

        }



        public async Task<ActionResult> AltaAuto()
        {
            try
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
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
            

        }

        [HttpPost]
        public async Task<ActionResult> AltaAuto([FromForm]Automobil auto)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";


                    bool exito = await controladorVehiculo.AltaVehiculo(auto);

                    if (exito)
                    {
                        mensaje = "El vehiculo se dio de alta con exito!.";
                    }
                    else
                    {
                        mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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
                TempData["Mensaje"] = "Error: " + ex.Message ;

                return RedirectToAction("AltaAuto", "Vehiculos", new { area = "" });
            }

        }

        public ActionResult AltaCamion()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    HttpContext.Session.Set<Camion>(SESSSION_ALTA, new Camion());
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
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
            

        }

        [HttpPost]
        public async Task<ActionResult> AltaCamion([FromForm]Camion camion)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";

                    
                        bool exito = await controladorVehiculo.AltaVehiculo(camion);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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
                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("AltaCamion", "Vehiculos", new { area = "" });
            }

        }

        public ActionResult AltaCamioneta()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    HttpContext.Session.Set<Camioneta>(SESSSION_ALTA, new Camioneta());
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
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<ActionResult> AltaCamioneta([FromForm]Camioneta camioneta)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";
                    
                        bool exito = await controladorVehiculo.AltaVehiculo(camioneta);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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
                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("AltaCamioneta", "Vehiculos", new { area = "" });
            }

        }

        public ActionResult AltaMoto()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    HttpContext.Session.Set<Moto>(SESSSION_ALTA, new Moto());
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
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }

           

        }

        [HttpPost]
        public async Task<ActionResult> AltaMoto([FromForm]Moto moto)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {

                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    string mensaje = "";
                    
                        bool exito = await controladorVehiculo.AltaVehiculo(moto);

                        if (exito)
                        {
                            mensaje = "El vehiculo se dio de alta con exito!.";
                        }
                        else
                        {
                            mensaje = "Se produjo un error al dar de alta el vehiculo!.";
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
                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("AltaMoto", "Vehiculos", new { area = "" });
            }
        }

        public ActionResult Modificar(string matricula)
        {
            try
            {

                if (ComprobarLogin() == "G")
                {
                    List<Vehiculo> vehiculos = HttpContext.Session.Get<List<Vehiculo>>(SESSSION_VEHICULOS);
                    Vehiculo vehiculo = vehiculos.FirstOrDefault(x => x.Matricula == matricula);
                    DTVehiculo vehiculoaEditar = new DTVehiculo()
                    {
                        Matricula = vehiculo.Matricula,
                        Marca = vehiculo.Marca,
                        Modelo = vehiculo.Modelo,
                        Capacidad = vehiculo.Capacidad,
                        Estado = vehiculo.Estado,
                        Cadete = vehiculo.Cadete
                    };
                    if (vehiculo is Moto)
                    {
                        vehiculoaEditar.Cilindrada = ((Moto)vehiculo).Cilindrada;
                        vehiculoaEditar.Tipo = "Moto";
                    }
                    if (vehiculo is Camioneta)
                    {
                        vehiculoaEditar.Cabina = ((Camioneta)vehiculo).Cabina;
                        vehiculoaEditar.Tipo = "Camioneta";
                    }
                    if (vehiculo is Automobil)
                    {
                        vehiculoaEditar.Puertas = ((Automobil)vehiculo).Puertas;
                        vehiculoaEditar.Tipo = "Automobil";
                    }
                    if (vehiculo is Camion)
                    {
                        vehiculoaEditar.Altura = ((Camion)vehiculo).Altura;
                        vehiculoaEditar.Tipo = "Camion";
                    }
                    return View(vehiculoaEditar);
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
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }

        }

        [HttpPost]
        public ActionResult ModificarCamioneta([FromForm]DTVehiculo unVehiculo)
        {
            try
            {
                string mensaje = "";
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    if (ModelState.IsValid)
                    {
                        Camioneta vehiculoaModificar = new Camioneta()
                        {
                            Matricula = unVehiculo.Matricula,
                            Marca = unVehiculo.Marca,
                            Modelo = unVehiculo.Modelo,
                            Capacidad = unVehiculo.Capacidad,
                            Estado = unVehiculo.Estado,
                            Cadete = unVehiculo.Cadete,
                            Cabina = unVehiculo.Cabina
                        };

                        bool exito = controladorVehiculo.ModificarVehiculo(vehiculoaModificar);

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

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult ModificarCamion([FromForm]DTVehiculo unVehiculo)
        {
            try
            {
                string mensaje = "";
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    if (ModelState.IsValid)
                    {
                        Camion vehiculoaModificar = new Camion()
                        {
                            Matricula = unVehiculo.Matricula,
                            Marca = unVehiculo.Marca,
                            Modelo = unVehiculo.Modelo,
                            Capacidad = unVehiculo.Capacidad,
                            Estado = unVehiculo.Estado,
                            Cadete = unVehiculo.Cadete,
                            Altura = unVehiculo.Altura
                        };

                        bool exito = controladorVehiculo.ModificarVehiculo(vehiculoaModificar);

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
                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult ModificarMoto([FromForm]DTVehiculo unVehiculo)
        {
            try
            {
                string mensaje = "";
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    if (ModelState.IsValid)
                    {
                        Moto vehiculoaModificar = new Moto()
                        {
                            Matricula = unVehiculo.Matricula,
                            Marca = unVehiculo.Marca,
                            Modelo = unVehiculo.Modelo,
                            Capacidad = unVehiculo.Capacidad,
                            Estado = unVehiculo.Estado,
                            Cadete = unVehiculo.Cadete,
                            Cilindrada = unVehiculo.Cilindrada
                        };

                        bool exito = controladorVehiculo.ModificarVehiculo(vehiculoaModificar);

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
                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult ModificarAutomobil([FromForm]DTVehiculo unVehiculo)
        {
            try
            {
                string mensaje = "";
                if (ComprobarLogin() == "G")
                {
                    IControladorVehiculo controladorVehiculo = FabricaApps.GetControladorVehiculo();

                    if (ModelState.IsValid)
                    {
                        Automobil vehiculoaModificar = new Automobil()
                        {
                            Matricula = unVehiculo.Matricula,
                            Marca = unVehiculo.Marca,
                            Modelo = unVehiculo.Modelo,
                            Capacidad = unVehiculo.Capacidad,
                            Estado = unVehiculo.Estado,
                            Cadete = unVehiculo.Cadete,
                            Puertas = unVehiculo.Puertas
                        };

                        bool exito = controladorVehiculo.ModificarVehiculo(vehiculoaModificar);

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
                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
        }

        public ActionResult ListarAutos()
        {
            try
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
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }


        }
        public ActionResult ListarCamiones()
        {
            try
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
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }
        }



        public ActionResult ListarCamionetas()
        {
            try
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
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }

        }

        public ActionResult ListarMotos()
        {
            try
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
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch
            {
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }

            
        }

        public ActionResult IrReparaciones(string matricula)
        {
            try
            {

                if (ComprobarLogin() == "G")
                {

                    HttpContext.Session.Set<string>(SESSSION_SELECCIONADO, null);

                    HttpContext.Session.Set<string>(SESSSION_SELECCIONADO, matricula);

                    return RedirectToAction("Index", "Reparaciones", new { area = "" });
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
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
            }

        }

        public ActionResult IrMultas(string matricula)
        {
            try
            {

                if (ComprobarLogin() == "G")
                {

                    HttpContext.Session.Set<string>(SESSSION_SELECCIONADO, null);

                    HttpContext.Session.Set<string>(SESSSION_SELECCIONADO, matricula);

                    return RedirectToAction("Index", "Multas", new { area = "" });
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
                TempData["Mensaje"] = "Error al mostrar el formulario";

                return RedirectToAction("Index", "Vehiculos", new { area = "" });
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