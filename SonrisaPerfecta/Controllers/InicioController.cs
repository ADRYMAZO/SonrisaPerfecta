using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonrisaPerfecta.Controllers
{
    public class InicioController : Controller
    {
        //
        // GET: /Inicio/
        public ActionResult Inicio()
        {
            ViewBag.Title = "Servicios";

            return View();
        }
	}
}