using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        public void IngresarPaciente(Entidades.Paciente paciente)
        {
            using (SqlConnection conexion =
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SonrisaPerfecta"].ConnectionString))
            {
                conexion.Open();
                SqlTransaction tran = conexion.BeginTransaction();
                try
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexion;
                    comando.Transaction = tran;
                    comando.CommandText = "IngresarPaciente";
                    comando.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = paciente.NombreCompleto;
                    comando.Parameters.Add("@IdTipoIdentificacion", SqlDbType.SmallInt).Value = paciente.TipoIdentificacion.Id;
                    comando.Parameters.Add("@numeroIdentificacion", SqlDbType.VarChar).Value = paciente.numeroIdentificacion;
                    comando.Parameters.Add("@Genero", SqlDbType.SmallInt).Value = paciente.Genero.Id;
                    comando.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = paciente.FechaNacimiento;
                    comando.Parameters.Add("@Edad", SqlDbType.VarChar).Value = paciente.Edad;
                    comando.Parameters.Add("@EstadoCivil", SqlDbType.SmallInt).Value = paciente.EstadoCivil.Id;
                    comando.Parameters.Add("@DireccionResidencia", SqlDbType.VarChar).Value = paciente.DireccionRecidencia;
                    comando.Parameters.Add("@BarrioRecidencia", SqlDbType.SmallInt).Value = paciente.BarrioRecidencia.Id;
                    comando.Parameters.Add("@Telefono", SqlDbType.DateTime).Value = paciente.Telefono;
                    comando.Parameters.Add("@Ocupacion", SqlDbType.SmallInt).Value = paciente.Ocupacion;
                    comando.Parameters.Add("@NivelEscolaridad", SqlDbType.SmallInt).Value = paciente.NivelEscolaridad.Id;
                    comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = paciente.correoElectronico;
                    comando.Parameters.Add("@Eps", SqlDbType.SmallInt).Value = paciente.Eps.Id;
                    comando.Parameters.Add("@Regimen", SqlDbType.SmallInt).Value = paciente.Regimen.Id;
                    comando.Parameters.Add("@ContactoEmergencia", SqlDbType.VarChar).Value = paciente.ContactoEmergencia;
                    comando.Parameters.Add("@TratamientoRealizar", SqlDbType.SmallInt).Value = paciente.TratamientoRealizar.Id;
                    comando.Parameters.Add("@AntecedentesMedicos", SqlDbType.VarChar).Value = paciente.AntecedenteMedico;

                    comando.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public List<Entidades.Paciente> ObtenerPacientes(string nombreCompleto, string numeroIdentificacion, string genero, string nivelEscolaridad)
        {
            List<Entidades.Paciente> pacientes = new List<Entidades.Paciente>();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SonrisaPerfecta"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarPacientes";
                comando.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = nombreCompleto;
                comando.Parameters.Add("@NumeroIdentificacion", SqlDbType.BigInt).Value = numeroIdentificacion;
                comando.Parameters.Add("@Genero", SqlDbType.VarChar).Value = genero;
                comando.Parameters.Add("@NivelEscolaridad", SqlDbType.VarChar).Value = nivelEscolaridad;
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.Paciente paciente = new Entidades.Paciente();
                        paciente.Id = Convert.ToInt64(reader["IdPaciente"]);
                        paciente.NombreCompleto = reader["PrimerNombre"].ToString();
                        paciente.Genero = new Entidades.Genero();
                        paciente.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        paciente.Edad = reader["Edad"].ToString();
                        paciente.EstadoCivil = new Entidades.EstadoCivil();
                        paciente.DireccionRecidencia = reader["DireccionRecidencia"].ToString();
                        paciente.BarrioRecidencia = new Entidades.Barrio();
                        paciente.Telefono = reader["Telefono"].ToString();
                        paciente.Ocupacion = reader["Ocupacion"].ToString();
                        paciente.NivelEscolaridad = new Entidades.NivelEscolaridad();
                        paciente.correoElectronico = reader["correoElectronico"].ToString();
                        paciente.Eps = new Entidades.Eps();
                        paciente.Regimen = new Entidades.Regimen();
                        paciente.ContactoEmergencia = reader["ContactoEmergencia"].ToString();
                        paciente.TratamientoRealizar = new Entidades.Tratamiento();
                        paciente.AntecedenteMedico = reader["AntecedenteMedico"].ToString();
                        paciente.numeroIdentificacion = reader["numeroIdentificacion"].ToString();
                        paciente.TipoIdentificacion = new Entidades.TipoIdentificacion()
                        {
                            Id = Convert.ToInt32(reader["IdPaciente"]),
                            TipoIdentificacion = reader["TipoIdentificacion"].ToString()
                        };

                        pacientes.Add(paciente);
                    }
                }
            }
            return pacientes;
        }

        public DataTable ObtenerPacientes()
        {
            DataTable pacientes = new DataTable();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SonrisaPerfecta"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarPacientes";

                comando.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@Genero", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@NivelEscolaridad", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@NumeroIdentificacion", SqlDbType.BigInt).Value = string.Empty;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(pacientes);
            }

            return pacientes;
        }
    }
}