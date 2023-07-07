using System;
using System.Collections.Generic;
using laboratorio6.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using app.Models;

namespace app.Handlers
{
    public class SchoolHandler
    {
        private SqlConnection conexion;
        private string rutaConexion;
        public SchoolHandler()
        {
            var builder = WebApplication.CreateBuilder();
            rutaConexion =
            builder.Configuration.GetConnectionString("ContextoDeSchool");
            conexion = new SqlConnection(rutaConexion);
        }
        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta,
            conexion);
            SqlDataAdapter adaptadorParaTabla = new
            SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }
        public List<SchoolModel> ObtenerSchools()
        {
            List<SchoolModel> schools = new List<SchoolModel>();
            string consulta = "SELECT * FROM Escuelas";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                schools.Add(
                new SchoolModel
                {
                    Id = Convert.ToInt32(columna["Id"]),
                    Nombre = Convert.ToString(columna["Nombre"]),
                    Provincia = Convert.ToString(columna["Provincia"]),
                    Estado = Convert.ToString(columna["Estado"]),
                    NumeroAulas = Convert.ToInt32(columna["NumeroAulas"]),
                    EsPublica = Convert.ToBoolean(columna["EsPublica"])
                });
            }
            return schools;
        }

        public bool CrearSchool(SchoolModel school)
        {
            var consulta = @"INSERT INTO [dbo].[Escuelas] ([Nombre], [Provincia], [Estado], [NumeroAulas], [EsPublica])
                VALUES (@Nombre, @Provincia, @Estado, @NumeroAulas, @EsPublica)";
            var comandoParaConsulta = new SqlCommand(consulta, conexion);
            comandoParaConsulta.Parameters.AddWithValue("@Nombre", school.Nombre);
            comandoParaConsulta.Parameters.AddWithValue("@Provincia", school.Provincia);
            comandoParaConsulta.Parameters.AddWithValue("@Estado", school.Estado);
            comandoParaConsulta.Parameters.AddWithValue("@NumeroAulas", school.NumeroAulas);
            comandoParaConsulta.Parameters.AddWithValue("@EsPublica", school.EsPublica);

            conexion.Open();
            bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();

            return exito;
        }

        public bool EditarSchool(SchoolModel school)
        {
            var consulta = @"UPDATE [dbo].[Escuelas] SET
                            Nombre = @Nombre,
                            Provincia = @Provincia,
                            Estado = @Estado,
                            NumeroAulas = @NumeroAulas,
                            EsPublica = @EsPublica
                            WHERE Id = @Id";

            var cmdParaConsulta = new SqlCommand(consulta, conexion);
            cmdParaConsulta.Parameters.AddWithValue("@Nombre", school.Nombre);
            cmdParaConsulta.Parameters.AddWithValue("@Provincia", school.Provincia);
            cmdParaConsulta.Parameters.AddWithValue("@Estado", school.Estado);
            cmdParaConsulta.Parameters.AddWithValue("@NumeroAulas", school.NumeroAulas);
            cmdParaConsulta.Parameters.AddWithValue("@EsPublica", school.EsPublica);
            cmdParaConsulta.Parameters.AddWithValue("@Id", school.Id);

            conexion.Open();
            bool exito = cmdParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();

            return exito;
        }

        public bool BorrarSchool(SchoolModel school)
        {
            var consulta = @"DELETE [dbo].[Escuelas] WHERE Id=@Id";

            var cmdParaConsulta = new SqlCommand(consulta, conexion);
            cmdParaConsulta.Parameters.AddWithValue("@Id", school.Id);

            conexion.Open();
            bool exito = cmdParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();

            return exito;
        }
    }
}
