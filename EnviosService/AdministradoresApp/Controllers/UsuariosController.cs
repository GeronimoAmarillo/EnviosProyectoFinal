using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdministradoresApp.Models;
using EntidadesCompartidas;
using AutoMapper;

namespace EnviosService.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        public UsuariosController()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Usuarios, DTUsuario>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(u => u.Id))
                    .ForMember(d => d.NombreUsuario, opt => opt.MapFrom(u => u.NombreUsuario))
                    .ForMember(d => d.Contraseña, opt => opt.MapFrom(u => u.Contraseña))
                    .ForMember(d => d.Nombre, opt => opt.MapFrom(u => u.Nombre))
                    .ForMember(d => d.Telefono, opt => opt.MapFrom(u => u.Telefono))
                    .ForMember(d => d.Direccion, opt => opt.MapFrom(u => u.Direccion))
                    .ForMember(d => d.Email, opt => opt.MapFrom(u => u.Email))
                ;
            });
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Crear(DTUsuario unUsuario)
        {
            if (ModelState.IsValid)
            {
                Usuarios usuarioXAgregar = Mapper.Map<Usuarios>(unUsuario);
                //llamar a servicio
                return View("Index");
            }
            return View("Error");
        }
    }
}