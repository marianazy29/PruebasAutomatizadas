using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PruebasAutomatizadas
{
    [TestClass]
    public sealed class LoginTestExitoUsuarioValido
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
        Prueba LoginExitoso_UsuarioValido por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public void LoginExitoso_UsuarioValido()
        {
            driver?.Navigate().GoToUrl(url);

            driver?.FindElement(By.Id("email")).SendKeys("admin@practicesoftwaretesting.com");
            driver?.FindElement(By.Id("password")).SendKeys("welcome01");
            driver?.FindElement(By.ClassName("btnSubmit")).Click();

            WebDriverWait wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(15));

            wait.Until(d => d.Url.Contains("/admin/dashboard"));
            Assert.IsTrue(driver?.Url.Contains("/admin/dashboard"), "No se llegó al dashboard.");

            bool textoVisible = wait.Until(d =>
            {
                try
                {
                    return d.PageSource.Contains("Sales over the years");
                }
                catch
                {
                    return false;
                }
            });

            Assert.IsTrue(textoVisible, "El texto 'Sales over the years' no se encontró en el dashboard.");

            Console.WriteLine("URL actual: " + driver?.Url);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}
