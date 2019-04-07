using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonrisaPerfecta.Controllers
{
    public class AgendarCitaController : Controller
    {
        //
        // GET: /AgendarCita/
        public ActionResult AgendarCita()
        {
            ViewBag.Title = "Agendar cita";

            return View();
        }
	}
}