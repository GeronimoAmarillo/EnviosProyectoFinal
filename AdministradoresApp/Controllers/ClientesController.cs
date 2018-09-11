using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;
using EntidadesCompartidasCore;

namespace AdministradoresApp.Controllers
{
    
    public class ClientesController : Controller
    {
        public static string SESSION_MENSAJE = "Mensaje";
        public static string SESSSION_ALTA = "AltaCliente";
        public static string SESSSION_MODIFICAR = "ModificarCliente";
        public static string LOG_USER = "UsuarioLogueado";

        public async Task<ActionResult> Index()
        {
            try
            {

                IControladorCliente controladorCliente = FabricaApps.GetControladorCliente();

                List<Cliente> clientes = await controladorCliente.ListarClientes();

                string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);

                HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                if (mensaje != null && mensaje != "")
                {
                    ViewBag.Message = mensaje;
                }

                return View(clientes);

            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los clientes registrados");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult Alta()
        {
            try
            {
                string mensaje = HttpContext.Session.Get<string>(SESSION_MENSAJE);
                HttpContext.Session.Set<string>(SESSION_MENSAJE, null);

                if (mensaje != null && mensaje != "")
                {
                    ViewBag.Message = mensaje;
                }

                return View();
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Alta de Cliente.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Alta([FromForm] Cliente unCliente)
        {
            try
            {
                IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();
                bool exito = await controladorUsuario.AltaUsuario(unCliente);
                if (exito)
                {
                    ViewBag.Message = "Cliente agregado exitosamente";
                    return View("Index");
                }
                else
                {
                    ViewBag.Message = "Error al intentar dar de alta el cliente";
                    return View();
                }
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar dar de alta el cliente.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public IActionResult Modificar(int id)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorCliente controladorCliente = FabricaApps.GetControladorCliente();

                    Cliente unCliente = controladorCliente.BuscarCliente(id);

                    if (unCliente != null)
                    {
                        HttpContext.Session.Set<Cliente>(SESSSION_MODIFICAR, unCliente);

                        return View(unCliente);
                    }
                    else
                    {
                        HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el cliente que desea modificar");

                        return RedirectToAction("Index", "Clientes", new { area = "" });
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
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de modificacion de Cliente.");

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Modificar([FromForm] Cliente unCliente)
        {
            try
            {
                IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();
                bool exito = await controladorUsuario.ModificarUsuario(unCliente);
                if (exito)
                {
                    ViewBag.Message = "Cliente modificado exitosamente";
                    return View("Index");
                }
                else
                {
                    ViewBag.Message = "Error al intentar modificar el cliente";
                    return View();
                }
            }
            catch
            {
                HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar modificar el cliente.");

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