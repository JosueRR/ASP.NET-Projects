using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace FuntionalTests
{
    /* justificaci�n: Operaci�n CRUD READ, se prueba el despliegue correcto de la lista de escuelas 
    Resultado esperado: El resultado cumple ya que, se abre la app. se ingresa en la opci�n de lista de escuelas
    y se despliegan las escuelas, realizando as� la operaci�n READ */
    [TestClass]
    public class Read
    {
        IWebDriver _driver;

        [TestMethod]
        public void AbleToReadSchools()
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

            Thread.Sleep(2000); // 2-second delay to observe the webpage before the assertd

            Assert.IsTrue(_driver.Url.Contains("School"));
        }

        [TestCleanup]
        public void Cleanup() 
        {
            _driver.Quit();
        }
    }
}