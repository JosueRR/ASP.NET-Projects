using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using app.Models;
using System;

namespace app.Handlers
{
    /* Class that manages interaction with database*/
    public class SchoolHandler
    {
        // SQL connection
        private SqlConnection conexion;
        private string rutaConexion;

        // Constructor of class
        public SchoolHandler()
        {
            var builder = WebApplication.CreateBuilder();
            rutaConexion =
            builder.Configuration.GetConnectionString("ContextoDeSchool");
            conexion = new SqlConnection(rutaConexion);
        }

        // Creates a data table
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

        // Retrieves a list of all Schools from the database
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

        // Retrieves a specific School from the database based on ID
        public SchoolModel ObtenerSchool(int id)
        {
            string consulta = $"SELECT * FROM Escuelas WHERE Id = {id}";
            DataTable tablaResultado = CrearTablaConsulta(consulta);

            if (tablaResultado.Rows.Count > 0)
            {
                DataRow columna = tablaResultado.Rows[0];

                return new SchoolModel
                {
                    Id = Convert.ToInt32(columna["Id"]),
                    Nombre = Convert.ToString(columna["Nombre"]),
                    Provincia = Convert.ToString(columna["Provincia"]),
                    Estado = Convert.ToString(columna["Estado"]),
                    NumeroAulas = Convert.ToInt32(columna["NumeroAulas"]),
                    EsPublica = Convert.ToBoolean(columna["EsPublica"])
                };
            }

            return null; // Return null if the school with the specified ID is not found
        }

        // Inserts a new school into the database
        public bool CrearSchool(SchoolModel school)
        {
            try
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
            catch
            { 
                return false;
            }
        }

        // Updates an existing school in the database
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

        // Deletes a school from the database
        public bool BorrarSchool(SchoolModel school)
        {
            try
            {
                var consulta = @"DELETE [dbo].[Escuelas] WHERE Id=@Id";

                var cmdParaConsulta = new SqlCommand(consulta, conexion);
                cmdParaConsulta.Parameters.AddWithValue("@Id", school.Id);

                conexion.Open();
                bool exito = cmdParaConsulta.ExecuteNonQuery() >= 1;
                conexion.Close();

                return exito;
            }
            catch 
            {
                return false;
            }
        }
    }
}
