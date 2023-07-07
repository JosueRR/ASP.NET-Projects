using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace FuntionalTests
{
    /* justificación: Operación CRUD UPDATE, se prueba el despliegue correcto de la pagina de inicio, la seleccion de 
    * la opcion del despliegue de las Schools y su posterior edicion. Con esto se prueba que se puedan editar objetos de forma correcta
    Resultado esperado: El resultado cumple ya que, se abre la app. y siguiendo los pasos se edita una escuela */
    [TestClass]
    public class Update
    {
        IWebDriver _driver;

        [TestMethod]
        public void AbleToUpdateSchools()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://localhost:7107/");

            var mainNavbar = By.Id("mainNavbar");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(
                ExpectedConditions.ElementIsVisible(mainNavbar));

            var schoolsButton = _driver.FindElement(By.Id("schoolMainDropdown"));
            schoolsButton.Click();
            var schoolList = _driver.FindElement(By.Id("indexListSchools"));
            schoolList.Click();
            var editButton = _driver.FindElement(By.Id("edit-2"));
            editButton.Click();


            Thread.Sleep(2000); // 2-second delay


            var NombreField = _driver.FindElement(By.Id("Nombre"));
            var EditSubmit = _driver.FindElement(By.Id("edit-submit"));

            Thread.Sleep(2000); // 2-second delay


            NombreField.Clear();
            NombreField.SendKeys("Escuela CRUD Norte");
            EditSubmit.Click();

            // CAMBIAR POR EL URL DEL LOCAL HOST QUE ESTE CORRIENDO
            var expectedUrl = "https://localhost:7107/School"; // redirige al index porque todo salio bien
            Assert.AreEqual(expectedUrl, _driver.Url);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
