using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministradoresApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Adelantos")]
    public class AdelantosController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<EntidadesCompartidasCore.Adelanto>());
        }
    }
}