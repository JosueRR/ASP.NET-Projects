using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace FuntionalTests
{
    /* justificación: Operación CRUD CREATE, se prueba el despliegue correcto de la pagina de inicio, la seleccion de 
    * la opcion Create School y su posterior creacion. Con esto se prueba que se puedan crear objetos de forma correcta
    Resultado esperado: El resultado cumple ya que, se abre la app. y siguiendo los pasos se crea una escuela */
    [TestClass]
    public class Create
    {
        IWebDriver _driver;

        [TestMethod]
        public void AbleToCreateSchools()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://localhost:7107/");

            var mainNavbar = By.Id("mainNavbar");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(
                ExpectedConditions.ElementIsVisible(mainNavbar));

            var schoolsButton = _driver.FindElement(By.Id("schoolMainDropdown"));
            schoolsButton.Click();
            var schoolCreate = _driver.FindElement(By.Id("indexCreateSchool"));
            schoolCreate.Click();

            Thread.Sleep(2000); // 2-second delay


            var NombreField = _driver.FindElement(By.Id("Nombre"));
            var ProvinciaField = _driver.FindElement(By.Id("Provincia"));
            var EstadoField = _driver.FindElement(By.Id("Estado"));
            var NumeroAulasField = _driver.FindElement(By.Id("NumeroAulas"));
            var EsPublicaField = _driver.FindElement(By.Id("EsPublica"));
            var CrearSubmit = _driver.FindElement(By.Id("create-submit"));

            Thread.Sleep(2000); // 2-second delay


            NombreField.SendKeys("CRUD");
            ProvinciaField.SendKeys("CRUD");
            EstadoField.SendKeys("CRUD");
            NumeroAulasField.SendKeys("3");
            EsPublicaField.SendKeys("False");
            CrearSubmit.Click();

            Thread.Sleep(2000); // 2-second delay

            Assert.IsTrue(_driver.Url.Contains("CrearSchool"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
