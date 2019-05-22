using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        public string NombreCompleto { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }
        public Genero Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Edad { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public string DireccionRecidencia { get; set; }
        public Barrio BarrioRecidencia { get; set; }
        public string Telefono { get; set; }
        public string Ocupacion { get; set; }
        public NivelEscolaridad NivelEscolaridad { get; set; }
        public string correoElectronico { get; set; }
        public Eps Eps { get; set; }
        public Regimen Regimen { get; set; }
        public string ContactoEmergencia { get; set; }
        public Tratamiento TratamientoRealizar { get; set; }
        public string AntecedenteMedico { get; set; }
        public long Id { get; set; }
    }
}
