using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PruebasAutomatizadas
{
    [TestClass]
    public class LoginTestValidacionLongitudPassword
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

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        /**
        Prueba ValidacionLongitudPassword por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void ValidacionLongitudPassword()
        {
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("email")).SendKeys("admin@practicesoftwaretesting.com");
            driver.FindElement(By.Id("password")).SendKeys("12");
            driver.FindElement(By.ClassName("btnSubmit")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var passwordError = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.CssSelector("[data-test='password-error']")
                )
            );

            Assert.IsNotNull(passwordError, "No se mostró mensaje de error de longitud de password.");
            Assert.AreEqual("Password length is invalid", passwordError.Text.Trim());
        }
    }
}