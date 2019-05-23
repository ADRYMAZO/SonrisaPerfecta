using Entidades;
using Repositorio;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class PacienteNegocio
    {
        IRepositorioPaciente repositorio;
        public PacienteNegocio()
        {
            repositorio = new RepositorioPacienteMock();
        }

        public void IngresarDeportista(Paciente paciente)
        {
            repositorio.IngresarPaciente(paciente);
        }

        public List<Paciente> ObtenerDeportistas(string nombreCompleto, string tipoIdentificacion, string numeroIdentificacion, string nivelEscolaridad)
        {
            return repositorio.ObtenerPacientes(nombreCompleto, tipoIdentificacion, numeroIdentificacion, nivelEscolaridad);
        }

        public DataTable ObtenerPacientes()
        {
            return repositorio.ObtenerPacientes();
        }
    }
}