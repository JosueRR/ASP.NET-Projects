using System;
using System.Collections.Generic;
using laboratorio5.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;



namespace laboratorio5.Handlers
{
    public class PeliculasHandler
    {
        private SqlConnection conexion;
        private string rutaConexion;
        public PeliculasHandler()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Configuration.GetConnectionString("ContextoDePeliculas");
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
        public List<PeliculaModelo> ObtenerPeliculas()
        {
            List<PeliculaModelo> peliculas = new List<PeliculaModelo>( capacity: 10);
            string consulta = "SELECT * FROM Pelicula";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                peliculas.Add(
                new PeliculaModelo
                {
                    ID = Convert.ToInt32(columna["Id"]),
                    Nombre = Convert.ToString(columna["Nombre"]),
                    Anno = Convert.ToInt32(columna["An"]),
                });
            }
            return peliculas;
        }
    }
}