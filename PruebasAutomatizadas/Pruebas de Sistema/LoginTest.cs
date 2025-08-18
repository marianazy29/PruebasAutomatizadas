using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace PruebasAutomatizadas
{
    [TestClass]
    public sealed class LoginTest
    {
        private IWebDriver driver;
        private string url = "https://practicesoftwaretesting.com/login";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }
        [TestMethod]

        /**
        Prueba LoginExitoso_UsuarioValido por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void LoginExitoso_UsuarioValido()
        {
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Name("email")).SendKeys("admin@practicesoftwaretesting.com");
            driver.FindElement(By.Name("password")).SendKeys("welcome01");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verificar redirección al dashboard
            var dashboard = driver.FindElement(By.XPath("//*[contains(text(),'Dashboard')]"));
            Assert.IsNotNull(dashboard, "El dashboard no se cargó correctamente");
        }

        /**
        Prueba LoginFallido_ContrasenaIncorrecta por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void LoginFallido_ContrasenaIncorrecta()
        {
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Name("email")).SendKeys("admin@practicesoftwaretesting.com");
            driver.FindElement(By.Name("password")).SendKeys("welcome01");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verificar mensaje de error
            var errorMsg = driver.FindElement(By.XPath("//*[contains(text(),'Invalid email or password')]"));
            Assert.IsNotNull(errorMsg, "No se mostró mensaje de contraseña incorrecta");
        }

        /**
        Prueba LoginFallido_UsuarioInexistente por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void LoginFallido_UsuarioInexistente()
        {
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Name("email")).SendKeys("userfake@test.com");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verificar mensaje de error
            var errorMsg = driver.FindElement(By.XPath("//*[contains(text(),'Invalid email or password')]"));
            Assert.IsNotNull(errorMsg, "No se mostró mensaje de usuario inexistente");
        }

        /**
        Prueba ValidacionCamposObligatorios por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void ValidacionCamposObligatorios()
        {
            driver.Navigate().GoToUrl(url);

            // Dejar campos vacíos
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verificar mensaje de campo requerido
            var emailRequired = driver.FindElement(By.XPath("//*[contains(text(),'Campo requerido')]"));
            var passwordRequired = driver.FindElement(By.XPath("//*[contains(text(),'Campo requerido')]"));
            Assert.IsNotNull(emailRequired, "No se mostró mensaje de email obligatorio");
            Assert.IsNotNull(passwordRequired, "No se mostró mensaje de password obligatorio");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
