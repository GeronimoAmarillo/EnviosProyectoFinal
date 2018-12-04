using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.AspNetCore.Mvc;


namespace ClientesApp.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var usuarioLogueado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            return View(usuarioLogueado);
        }
    }
}
