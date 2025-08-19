using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace PruebasAutomatizadas
{
    [TestClass]
    public class LoginTestUsuarioValidoPlaywright
    {
        private IBrowser browser = null!;
        private IPage page = null!;
        private IBrowserContext context = null!;
        private IPlaywright playwright = null!;

        private readonly string url = "https://practicesoftwaretesting.com/auth/login";

        [TestInitialize]
        public async Task Setup()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,   // ver la UI
                SlowMo = 200
            });
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
        }

        [TestCleanup]
        public async Task TearDown()
        {
            if (page is not null)
                await page.CloseAsync();

            if (context is not null)
                await context.CloseAsync();

            if (browser is not null)
                await browser.CloseAsync();

            playwright?.Dispose();
        }

        /**
        Prueba LoginExitoso_UsuarioValido con Playwright por Edwin Ajahuanca Callisaya
        */
        [TestMethod]
        public async Task LoginExitoso_UsuarioValido()
        {
            if (page is null) Assert.Fail("La página no se inicializó");

            await page.GotoAsync(url);

            await page.FillAsync("#email", "admin@practicesoftwaretesting.com");
            await page.FillAsync("#password", "welcome01");
            
            var botonLogin = page.Locator("[data-test='login-submit']");
            await botonLogin.WaitForAsync(new LocatorWaitForOptions {
                State = WaitForSelectorState.Visible,
                Timeout = 10000
            });
            await botonLogin.ClickAsync();

            await page.WaitForURLAsync("**/admin/dashboard", new PageWaitForURLOptions
            {
                Timeout = 10000   // 10s para dar tiempo
            });

            var locator = page.Locator("text=Sales over the years");
            await locator.WaitForAsync();

            var texto = await locator.TextContentAsync();
            Assert.IsNotNull(texto, "El Dashboard no cargó correctamente.");
        }
    }
}
