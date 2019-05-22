using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonrisaPerfecta.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Resporte/
        public ActionResult Reporte()
        {
            PacienteNegocio control = new PacienteNegocio();
            List<Paciente> pacientes = control.ObtenerPacientes(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            return View(pacientes);
        }

        public ActionResult GraficoPacientes()
        {
            PacienteNegocio control = new PacienteNegocio();
            List<Paciente> deportistas = control.ObtenerPacientes(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            var pacientesPorAnyo = pacientes.GroupBy(p => p.FechaNacimiento.Year).Select(p => new { Year = p.Key, Cantidad = p.Count() });
            var datosGrafico = "[";
            if (pacientesPorAnyo.Count() > 0)
            {
                foreach (var valor in pacientesPorAnyo)
                {
                    datosGrafico += "['" + valor.Year + "', " + valor.Cantidad + "],";
                }
                datosGrafico = datosGrafico.Substring(0, datosGrafico.Length - 1);
                datosGrafico += "]";
            }
            else
            {
                datosGrafico = "[]";
            }

            ViewBag.DatosGrafico = datosGrafico;
            return View();
        }

        public ActionResult ReportePacientes()
        {
            return View();
        }
	}
}