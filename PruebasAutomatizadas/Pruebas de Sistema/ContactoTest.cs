using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebasAutomatizadas
{
    [TestClass]
    public sealed class ContactoTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }
        /*[TestMethod]
        public void TestMethod1()
        {
        }*/
        [TestMethod]
        public void Contacto_DatosYAdjuntoValidos_MuestraMensajeExitoso()
        {
            driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/contact");

            var firstName = driver.FindElement(By.Id("first_name"));
            firstName.SendKeys("Mariana");

            var lastName = driver.FindElement(By.Id("last_name"));
            lastName.SendKeys("Zúñiga");

            var email = driver.FindElement(By.Id("email"));
            email.SendKeys("correoprueba@ubc.com");

            var subject = driver.FindElement(By.Id("subject"));
            subject.SendKeys("Payments");

            var message = driver.FindElement(By.Id("message"));
            message.SendKeys("Por favor quisiera información sobre el tiempo de los pagos.");

            var fileInput = driver.FindElement(By.Id("attachment"));
            fileInput.SendKeys(@"C:\Users\admin\Documents\archivoVacio.txt");

            var loginButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            loginButton.Click();

            var messageSuccess = driver.FindElement(By.CssSelector("div.alert.alert-success.mt-3"));
            Assert.IsTrue(messageSuccess.Text.Contains("Thanks for your message! We will contact you shortly."));
        }
    }
}
