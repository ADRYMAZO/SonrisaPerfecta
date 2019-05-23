using System;

namespace SonrisaPerfecta.Models
{
    public class Paciente
    {
        public string NombreCompleto { get; set; }
        public string TipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string DireccionResidencia { get; set; }
        public string BarrioResidencia { get; set; }
        public string Telefono { get; set; }
        public string Ocupacion { get; set; }
        public string NivelEscolaridad { get; set; }
        public string correoElectronico { get; set; }
        public string Eps { get; set; }
        public string Regimen { get; set; }
        public string ContactoEmergencia { get; set; }
        public string TratamientoRealizar { get; set; }
        public string AntecedenteMedico { get; set; }
        public long Id { get; set; }
    }
}