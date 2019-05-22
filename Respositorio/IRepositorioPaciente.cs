using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public interface IRepositorioPaciente
    {
        void IngresarPaciente(Paciente paciente);

        List<Paciente> ObtenerPacientes(string nombreCompleto, string numeroIdentificacion, string edad, string direccionRecidencia, string telefono, string ocupacion, string correoElectronico, string ContactoEmergencia, string AntecedenteMedico);
        DataTable ObtenerPacientes();

        List<Paciente> ObtenerPacientes(string nombreCompleto, string numeroIdentificacion, string genero, string nivelEscolaridad);
    }
}