using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebasAutomatizadas
{
    [TestClass]
    public sealed class ContactoTest
    {
        private IWebDriver driver = null!;

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
