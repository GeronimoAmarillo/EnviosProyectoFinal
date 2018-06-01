using EntidadesCompartidas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.ViewComponents
{
    public class UsuarioLogueadoViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var usuarioLogueado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            return View(usuarioLogueado);
        }

    }
}
