using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace PruebasAutomatizadas
{
    [TestClass]
    public sealed class LoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }

    }
}
