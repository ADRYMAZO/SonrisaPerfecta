using SonrisaPerfecta.Models;
using Negocio;
using Entidades;
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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegistrarPaciente()
        {
            var tiposIdentificacion = new List<SelectListItem>();
            tiposIdentificacion.Add(new SelectListItem()
            {
                Text = "Cédula de Ciudadanía",
                Value = "1"
            });
            tiposIdentificacion.Add(new SelectListItem()
            {
                Text = "Tarjeta de Identidad",
                Value = "2"
            });
            ViewBag.tiposIdentificacion = tiposIdentificacion;

            return View(new Paciente());
        }

        [HttpPost]
        public ActionResult Crear(Paciente paciente)
        {
            var tiposIdentificacion = new List<SelectListItem>();
            tiposIdentificacion.Add(new SelectListItem()
            {
                Text = "Cédula de Ciudadanía",
                Value = "1"
            });
            tiposIdentificacion.Add(new SelectListItem()
            {
                Text = "Tarjeta de Identidad",
                Value = "2"
            });
            ViewBag.TiposIdentificacion = tiposIdentificacion;

            PacienteNegocio PacienteNegocio = new PacienteNegocio();
            Entidades.Paciente nuevoPaciente = new Entidades.Paciente()
            {
                FechaNacimiento = paciente.FechaNacimiento,
                NombreCompleto = paciente.NombreCompleto,
                TipoIdentificacion = paciente.TipoIdentificacion,
                numeroIdentificacion = paciente.numeroIdentificacion,
                Genero = paciente.Genero,
                Edad = paciente.Edad,
                EstadoCivil = paciente.EstadoCivil,
                DireccionResidencia = paciente.DireccionResidencia,

                BarrioResidencia = paciente.BarrioResidencia,
                Telefono = paciente.Telefono,
                Ocupacion = paciente.Ocupacion,
                NivelEscolaridad = paciente.NivelEscolaridad,
                correoElectronico = paciente.correoElectronico,
                Eps = paciente.Eps,
                Regimen = paciente.Regimen,
                ContactoEmergencia = paciente.ContactoEmergencia,
                TratamientoRealizar = paciente.TratamientoRealizar,
                AntecedenteMedico = paciente.AntecedenteMedico,
            };
            try
            {
                P+acienteNegocio.IngresarDeportista(nuevoPaciente);
                ViewBag.Mensaje = "Se ingresó el deportista";
            }
            catch (Exception exc)
            {
                ViewBag.Mensaje = "No se pudo ingresar el deportista";
                //Log.Error(exc);
            }
            return View();
        }
	}
}