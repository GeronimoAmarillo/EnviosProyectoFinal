using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaDeAppsCore;
using EntidadesCompartidasCore;
using System.Net.Mail;

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
                if (ComprobarLogin() == "G")
                {
                    IControladorCliente controladorCliente = FabricaApps.GetControladorCliente();

                    List<Cliente> clientes = await controladorCliente.ListarClientes();

                    if (TempData["Mensaje"] != null)
                    {
                        string mensaje = TempData["Mensaje"].ToString();
                        TempData["Mensaje"] = mensaje;
                    }

                    return View(clientes);
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
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario: No se pudieron listar los clientes registrados");

                TempData["Mensaje"] = "Error al mostrar el formulario: No se pudieron listar los clientes registrados";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public IActionResult Alta()
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
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

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                
            }
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de Alta de Cliente.");

                TempData["Mensaje"] = "Error al mostrar el formulario de Alta de Cliente.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Alta([FromForm] Cliente unCliente)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorUsuario controladorUsuario = FabricaApps.GetControladorUsuario();

                    unCliente.Contraseña = controladorUsuario.CrearContrasenia();

                    if (ModelState.IsValid)
                    {
                        bool exito = await controladorUsuario.AltaUsuario(unCliente);


                        if (exito)
                        {

                            try
                            {
                                MailMessage mail = new MailMessage();
                                mail.From = new MailAddress("enviosservice2018@gmail.com");
                                mail.To.Add(unCliente.Email);
                                mail.Subject = "Ha sido registrado en - EnviosService";
                                mail.Body = "Hola " + unCliente.Nombre + ", Le hemos registrado en el sistema como solicitó! \n " +
                                    "Sus credenciales de acceso al sistema son: - user: " + unCliente.Email + ", - pass: " + unCliente.Contraseña;
                                mail.IsBodyHtml = true;
                                mail.Priority = MailPriority.Normal;

                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.Port = 25;
                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = true;
                                string correoPropio = "enviosservice2018@gmail.com";
                                string contraseñaCorreo = "MatiasPabloGero";
                                smtp.Credentials = new System.Net.NetworkCredential(correoPropio, contraseñaCorreo);

                                smtp.Send(mail);
                            }
                            catch (Exception ex)
                            {
                                //ViewBag.Message = "A pesar de que el alta se dio de forma exitosa, fallo el envio del mail al Cliente con sus credenciales de acceso al sistema!.";

                                TempData["Mensaje"] = "A pesar de que el alta se dio de forma exitosa, fallo el envio del mail al Cliente con sus credenciales de acceso al sistema!.";

                                return RedirectToAction("Index");
                            }

                            //ViewBag.Message = "Cliente agregado exitosamente";

                            TempData["Mensaje"] = "Cliente agregado exitosamente";

                            return RedirectToAction("Index");

                        }
                        else
                        {
                            //ViewBag.Message = "Datos incorrectos!.";

                            TempData["Mensaje"] = "Verifique que no esta ingresando datos de un Cliente ya registrado!.";

                            return View();
                        }
                    }
                    else
                    {

                        if (TempData["Mensaje"] != null)
                        {
                            string mensaje = TempData["Mensaje"].ToString();
                            TempData["Mensaje"] = mensaje;
                        }


                        return View();
                    }

                    
                }
                else
                {
                    //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No hay un usuario de tipo Administrador General logueado en el sistema");

                    TempData["Mensaje"] = "No hay un usuario de tipo Administrador General logueado en el sistema";

                    return RedirectToAction("Index", "Clientes", new { area = "" });
                }
                
            }
            catch(Exception ex)
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar dar de alta el cliente." + ex.Message);

                TempData["Mensaje"] = "Error: " + ex.Message;

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public async Task<IActionResult> Modificar(int rut)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    IControladorCliente controladorCliente = FabricaApps.GetControladorCliente();

                    Cliente unCliente = await controladorCliente.BuscarCliente(rut);

                    if (unCliente != null)
                    {
                        if (TempData["Mensaje"] != null)
                        {
                            string mensaje = TempData["Mensaje"].ToString();
                            TempData["Mensaje"] = mensaje;
                        }

                        return View(unCliente);
                    }
                    else
                    {
                        //HttpContext.Session.Set<string>(SESSION_MENSAJE, "No existe el cliente que desea modificar");

                        TempData["Mensaje"] = "No existe el cliente que desea modificar";

                        return RedirectToAction("Index", "Clientes", new { area = "" });
                    }
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
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al mostrar el formulario de modificacion de Cliente.");

                TempData["Mensaje"] = "Error al mostrar el formulario de modificacion de Cliente.";

                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public IActionResult Modificar([FromForm] Cliente unCliente)
        {
            try
            {
                if (ComprobarLogin() == "G")
                {
                    if (ModelState.IsValid)
                    {
                        IControladorCliente controladorUsuario = FabricaApps.GetControladorCliente();
                        bool exito = controladorUsuario.ModificarCliente(unCliente);
                        if (exito)
                        {
                            //ViewBag.Message = "Cliente modificado exitosamente";

                            TempData["Mensaje"] = "Cliente modificado exitosamente";

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            //ViewBag.Message = "Error al intentar modificar el cliente";

                            TempData["Mensaje"] = "Error al intentar modificar el cliente";

                            return View();
                        }
                    }
                    else
                    {
                        if (TempData["Mensaje"] != null)
                        {
                            string mensaje = TempData["Mensaje"].ToString();
                            TempData["Mensaje"] = mensaje;
                        }

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
            catch
            {
                //HttpContext.Session.Set<string>(SESSION_MENSAJE, "Error al intentar modificar el cliente.");

                TempData["Mensaje"] = "Error al intentar modificar el cliente.";

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