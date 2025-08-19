using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PruebasAutomatizadas
{
    [TestClass]
    public sealed class LoginTestValidacionCamposObligatorios
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
        Prueba ValidacionCamposObligatorios por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void ValidacionCamposObligatorios()
        {
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.ClassName("btnSubmit")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            var emailRequired = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.CssSelector("[data-test='email-error']")
                )
            );

            var passwordRequired = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.CssSelector("[data-test='password-error']")
                )
            );

            Assert.IsNotNull(emailRequired, "No se mostró mensaje de email obligatorio");
            Assert.IsNotNull(passwordRequired, "No se mostró mensaje de password obligatorio");

            Assert.AreEqual("Email is required", emailRequired.Text.Trim());
            Assert.AreEqual("Password is required", passwordRequired.Text.Trim());
        }

        [TestCleanup]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}
