using Microsoft.VisualStudio.TestTools.UnitTesting;
using app.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Models;

namespace app.Handlers.Tests
{
    /* Debido a su gran importancia se deciden hacer tests sobre el handler de escuelas. Ya que basicamente equivalen a las operaciones CRUD */
    /* Se testean los metodos: EditarSchool,  CrearSchool, ObtenerSchools, BorrarSchool */
    [TestClass()]
    public class SchoolHandlerTests
    {

        /* Por qué este método: este método se encarga de editar una escuela, una funcionalidad base de la app.
         Valores de entrada: en este caso el valor de entrada en una escuela, se opera sobre una ya existente en la base de datos
        Resultado Esperado: se espera que la funcion retorne true, esto significa que la operacion de edicion sobre una escuela fue exitosa */
        [TestMethod()]
        public void EditarSchoolTest_ReturnsTrue()
        {
            // Arrange
            SchoolModel school = new SchoolModel
            {
                Id = 3, // Escuela que existe en BD
                Nombre = "Escuela Manuel Antonio",
                Provincia = "Puntarenas",
                Estado = "Quepos",
                NumeroAulas = 6,
                EsPublica = true
            };
            SchoolHandler schoolHandler = new SchoolHandler();

            // Act
            bool result = schoolHandler.EditarSchool(school);

            // Assert
            Assert.IsTrue(result);
        }

        /* Valores de entrada: en este caso el valor de entrada en una escuela que no EXISTE, es decir un input erroneo
        Resultado Esperado: se espera que la funcion retorne false, esto significa que la operacion de edicion fue fallida 
        (pero correcta porque así debe actuar) debido a que la escuela no existe */
        [TestMethod]
        public void EditarSchoolTest_ReturnsFalse()
        {
            // Arrange
            SchoolModel school = new SchoolModel
            {
                Id = -1, // Escuela que NO existe en BD
                Nombre = "EDIT_UNIT_TEST",
                Provincia = "EDIT_UNIT_TEST",
                Estado = "EDIT_UNIT_TEST",
                NumeroAulas = 10,
                EsPublica = true
            };
            SchoolHandler schoolHandler = new SchoolHandler();

            // Act
            bool result = schoolHandler.EditarSchool(school);

            // Assert
            Assert.IsFalse(result);
        }

        /* Por qué este método: este método se encarga de crear una escuela, es lo mas basico que se puede esperar de la app.
         Valores de entrada: en este caso el valor de entrada en una escuela ficticia creada, con valores validos 
        Resultado Esperado: se espera que la funcion retorne true, esto significa que se creo de forma exitosa la escuela en la app */
        [TestMethod]
        public void CrearSchool_ReturnsTrue()
        {
            // Arrange
            SchoolModel school = new SchoolModel
            {
                Nombre = "CREATE_UNIT_TEST",
                Provincia = "CREATE_UNIT_TEST",
                Estado = "CREATE_UNIT_TEST",
                NumeroAulas = 5,
                EsPublica = false
            };
            SchoolHandler schoolHandler = new SchoolHandler();

            // Act
            bool result = schoolHandler.CrearSchool(school);

            // Assert
            Assert.IsTrue(result);
        }

        /* Valores de entrada: en este caso el valor de entrada en una escuela ficticia creada, pero le FALTA UN VALOR 
        Resultado Esperado: se espera que la funcion retorne false, porque le falta un argumento requerido para crear la escuela */
        [TestMethod]
        public void CrearSchool_ReturnsFalse_Missing_Input()
        {
            // Arrange
            SchoolModel school = new SchoolModel
            {
                // FALTA NOMBRE
                Provincia = "CREATE_UNIT_TEST",
                Estado = "CREATE_UNIT_TEST",
                NumeroAulas = 5,
                EsPublica = false
            };
            SchoolHandler schoolHandler = new SchoolHandler();

            // Act
            bool result = schoolHandler.CrearSchool(school);

            // Assert
            Assert.IsFalse(result);
        }

        /* Por qué este método: este método se encarga obtener todas las escuelas que hay en la app, algo basico para la funcionalidad de la app.
         Valores de entrada: en este caso se llama al metodo, no hay params, de entrada
        Resultado Esperado: se espera que la funcion retorne todas las escuelas que existen. En caso de existan en la hayan en la bd*/
        [TestMethod]
        public void ObtenerSchools_ReturnsListOfSchools_WhenSchoolsExist()
        {
            // Arrange
            SchoolHandler schoolHandler = new SchoolHandler();

            // Act
            List<SchoolModel> schools = schoolHandler.ObtenerSchools();

            // Assert
            Assert.IsNotNull(schools);
            Assert.IsTrue(schools.Count > 0);
        }

        /* Por qué este método: este método se encarga de borrar una escuela, algo muy util para mantener los parametros de la app actualizados.
         Valores de entrada: el param de entrada corresponde a una escuela que NO existe en la bd
        Resultado Esperado: se espera retorne false, porque no exite esa escuela en la bd */
        [TestMethod]
        public void BorrarSchool_ReturnsFalse()
        {
            // Arrange
            // Creates data sample
            SchoolHandler schoolHandler = new SchoolHandler();
            SchoolModel deleteSchool = new SchoolModel
            {
                Id = -1,
                Nombre = "Test School",
                Provincia = "Test Province",
                Estado = "Test State",
                NumeroAulas = 5,
                EsPublica = true
            };

            // Act
            bool success = schoolHandler.BorrarSchool(deleteSchool);

            // Assert
            Assert.IsFalse(success);
        }

        /* Por qué este método: este método se encarga encontrar una escuela en especifico, algo util para editar algo en especifico.
        Valores de entrada: ID de una escuela que EXISTA EN LA BD
        Resultado Esperado: se espera retorne true, porque existe en la bd */
        [TestMethod]
        public void ObtenerSchool_ReturnsTrue()
        {
            // Arrange
            int schoolId = 1;
            SchoolHandler schoolHandler = new SchoolHandler();

            // Act
            SchoolModel school = schoolHandler.ObtenerSchool(schoolId);

            // Assert
            Assert.IsNotNull(school);
            Assert.AreEqual(schoolId, school.Id);
        }

        /*
        Valores de entrada: ID de una escuela que NO EXISTA EN LA BD
        Resultado Esperado: se espera retorne true, porque existe en la bd */
        [TestMethod]
        public void ObtenerSchool_ReturnsFalse()
        {
            // Arrange
            int schoolId = -1;
            SchoolHandler schoolHandler = new SchoolHandler();

            // Act
            SchoolModel school = schoolHandler.ObtenerSchool(schoolId);

            // Assert
            Assert.IsNull(school);
        }

    }
}