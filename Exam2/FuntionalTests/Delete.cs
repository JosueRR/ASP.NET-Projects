using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuntionalTests
{
    /* justificación: Operación CRUD DELETE, se prueba el despliegue correcto de la pagina de inicio, la seleccion de 
   * la opcion lista de escuelas, despues se selecciona una y se elimina. Con esto se prueba que se puedan eliminar objetos de forma correcta
   Resultado esperado: El resultado cumple ya que, se abre la app. y siguiendo los pasos se elimina una escuela */
    [TestClass]
    public class Delete
    {
        IWebDriver _driver;

        [TestMethod]
        public void AbleToDeleteSchools()
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
            Thread.Sleep(6000); // 2-second delay

            var deletetButton = _driver.FindElement(By.Id("delete-12")); // OJO CAMBIAR POR ALGUNO QUE EXISTA SI LO VAN A PROBAR
            deletetButton.Click();


            Thread.Sleep(2000); // 2-second delay


            var DeleteBotton = _driver.FindElement(By.Id("delete-btn"));

            Thread.Sleep(2000); // 2-second delay


            DeleteBotton.Click();

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
