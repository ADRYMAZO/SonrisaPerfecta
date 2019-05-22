using Entidades;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data;

namespace Repositorio
{
    public class RepositorioPacienteMock : IRepositorioPaciente
    {
        public static List<Paciente> pacientes = new List<Paciente>();

        public void EliminarPaciente(long idPaciente)
        {
            var paciente = pacientes.FirstOrDefault(d => d.Id == idPaciente);
            if (paciente != null)
            {
                pacientes.Remove(paciente);
            }
        }

        public void IngresarPaciente(Paciente paciente)
        {
            paciente.Id = new Random().Next(1, 1000000000);
            pacientes.Add(paciente);
        }

        public List<Paciente> ObtenerPacientes(string nombreCompleto, string numeroIdentificacion, string edad, string telefono, string antecedenteMedico)
        {
            return pacientes.Where(p => (numeroIdentificacion == "" || p.numeroIdentificacion == numeroIdentificacion) &&
            (nombreCompleto == "" || p.NombreCompleto.Contains(nombreCompleto)) &&
            (edad == "" || p.Edad.Contains(edad)) &&
            (telefono == "" || p.Telefono.Contains(telefono)) &&
            (antecedenteMedico == "" || p.AntecedenteMedico.Contains(antecedenteMedico))
            ).ToList();
        }

        public DataTable ObtenerPacientes()
        {
            List<Paciente> listado = new List<Paciente>();
            var table = new DataTable();

            table.Columns.Add("NombreCompleto", typeof(string));
            table.Columns.Add("Edad", typeof(string));
            table.Columns.Add("Telefono", typeof(string));
            table.Columns.Add("AntecedenteMedico", typeof(string));
            table.Columns.Add("numeroIdentificacion", typeof(string));
            table.Columns.Add("FechaNacimiento", typeof(DateTime));

            foreach (var paciente in pacientes)
            {
                var row = table.NewRow();

                row["NombreCompleto"] = paciente.numeroIdentificacion;
                row["Edad"] = paciente.Edad;
                row["Telefono"] = paciente.Telefono;
                row["AntecedenteMedico"] = paciente.AntecedenteMedico;
                row["numeroIdentificacion"] = paciente.numeroIdentificacion;
                row["FechaNacimiento"] = paciente.FechaNacimiento;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}