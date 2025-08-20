using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PruebasAutomatizadas
{
    [TestClass]
    public sealed class LoginTestFallidoContrasenaIncorrecta
    {
        private IWebDriver driver = null!;
        private readonly string url = "https://practicesoftwaretesting.com/auth/login";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        /**
        Prueba LoginFallido_ContrasenaIncorrecta por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void LoginFallido_ContrasenaIncorrecta()
        {
            driver?.Navigate().GoToUrl(url);

            driver?.FindElement(By.Id("email")).SendKeys("admin@practicesoftwaretesting.com");
            driver?.FindElement(By.Id("password")).SendKeys("passwordIncorrecto");
            driver?.FindElement(By.ClassName("btnSubmit")).Click();

            WebDriverWait wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(10));
            var errorMsg = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.CssSelector("[data-test='login-error']")
                )
            );

            Assert.IsNotNull(errorMsg, "No se mostró mensaje de contraseña incorrecta.");
            Assert.AreEqual("Invalid email or password", errorMsg.Text.Trim());
        }

        [TestCleanup]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}
