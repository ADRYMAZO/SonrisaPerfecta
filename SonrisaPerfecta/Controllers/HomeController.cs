using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonrisaPerfecta.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Inicio/
        public ActionResult Index()
        {
            ViewBag.Title = "Iniciar sesión";

            return View();
        }
    }
}
