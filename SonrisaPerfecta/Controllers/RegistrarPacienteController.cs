using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonrisaPerfecta.Controllers
{
    public class RegistrarPacienteController : Controller
    {
        //
        // GET: /RegistrarPaciente/
        public ActionResult RegistrarPaciente()
        {
            ViewBag.Title = "Registrar paciente";

            return View();
        }
	}
}