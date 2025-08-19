using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PruebasAutomatizadas
{
    [TestClass]
    public class LoginTestValidacionEmail
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
        Prueba ValidacionFormatoEmail por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void ValidacionFormatoEmail()
        {
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("email")).SendKeys("edwin.ajahuanca");
            driver.FindElement(By.Id("password")).SendKeys("welcome01");
            driver.FindElement(By.ClassName("btnSubmit")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var emailError = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.CssSelector("[data-test='email-error']")
                )
            );

            Assert.IsNotNull(emailError, "No se mostró mensaje de error de formato de email.");
            Assert.AreEqual("Email format is invalid", emailError.Text.Trim());
        }
    }
}