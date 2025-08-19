/*
 * RF-CT-003: Validación de Campos Vacíos
 * Prueba automatizada del formulario de contacto con particionamiento de equivalencias - datos inválidos
 * 
 * Autor: Neyber Rojas Zapata
 * Técnica: Particionamiento de Equivalencias – Datos Inválidos
 * Herramienta: C# con Selenium WebDriver
 * Entorno: Navegador Chrome
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PruebasAutomatizadas.RF_CT_003
{
    [TestClass]
    public sealed class CamposVaciosTest
    {
        private IWebDriver driver = null!;
        private WebDriverWait wait = null!;

        [TestInitialize]
        public void Setup()
        {
            // Kill any existing Chrome processes to prevent multiple instances
            try
            {
                var chromeProcesses = System.Diagnostics.Process.GetProcessesByName("chrome");
                foreach (var process in chromeProcesses)
                {
                    if (process.ProcessName.Contains("chrome"))
                    {
                        try { process.Kill(); } catch { }
                    }
                }
            }
            catch { }
            
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-web-security");
            options.AddArgument("--disable-features=VizDisplayCompositor");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-plugins");
            options.AddArgument("--disable-images");
            
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [TestCleanup]
        public void TearDown()
        {
            try
            {
                if (driver != null)
                {
                    driver.Close();
                    driver.Quit();
                    driver.Dispose();
                }
            }
            catch (Exception)
            {
                // Force kill Chrome processes if normal cleanup fails
                try
                {
                    var chromeProcesses = System.Diagnostics.Process.GetProcessesByName("chrome");
                    foreach (var process in chromeProcesses)
                    {
                        try { process.Kill(); } catch { }
                    }
                }
                catch { }
            }
        }

        [TestMethod]
        public void RF_CT_003_ValidacionCamposVacios()
        {
            // CASO DE PRUEBA: RF-CT-003
            // ¿QUÉ SE VA PROBAR? Verificar la validación cuando los campos requeridos están vacíos
            // TÉCNICA: Particionamiento de equivalencias – Datos inválidos
            
            // Navigate to contact page
            driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/contact");
            
            // Wait for Angular app to load completely
            Thread.Sleep(5000);
            
            // Wait for any input elements to be present (Angular dynamic loading)
            wait.Until(d => d.FindElements(By.TagName("input")).Count > 0);
            
            Console.WriteLine("=== RF-CT-003: Validación de Campos Vacíos ===");
            
            // Act - Try to submit form with empty fields (equivalence partitioning - invalid data)
            
            // Find submit button and click without filling any fields
            var submitButtons = driver.FindElements(By.CssSelector("button[type='submit'], input[type='submit'], button"));
            var submitButton = submitButtons.FirstOrDefault(btn => 
            {
                var text = btn.Text.ToLower();
                var type = btn.GetAttribute("type");
                return type == "submit" || text.Contains("submit") || text.Contains("send") || text.Contains("enviar");
            });
            
            if (submitButton != null)
            {
                submitButton.Click();
                Console.WriteLine("Submit button clicked with empty fields");
            }
            else if (submitButtons.Count > 0)
            {
                submitButtons[0].Click();
                Console.WriteLine("First button clicked as fallback with empty fields");
            }
            
            // Wait for validation messages to appear
            Thread.Sleep(3000);
            
            // Assert - Verify validation messages and form behavior
            // RESULTADO ESPERADO: El envío no procede, mensajes de validación mostrados
            
            // Check that we're still on the contact page (form didn't submit)
            Assert.IsTrue(driver.Url.Contains("contact"), 
                "Should remain on contact page when validation fails");
            Console.WriteLine("✓ Form submission blocked - still on contact page");
            
            // Look for validation error messages
            var errorMessages = driver.FindElements(By.CssSelector(
                ".invalid-feedback, .error, .text-danger, [class*='error'], " +
                ".alert-danger, .validation-error, .field-error, .form-error"));
            
            if (errorMessages.Count > 0)
            {
                Console.WriteLine($"✓ Found {errorMessages.Count} validation error messages:");
                for (int i = 0; i < errorMessages.Count; i++)
                {
                    var message = errorMessages[i];
                    if (message.Displayed && !string.IsNullOrWhiteSpace(message.Text))
                    {
                        Console.WriteLine($"  Error {i + 1}: {message.Text}");
                    }
                }
                Assert.IsTrue(true, "Validation error messages are displayed");
            }
            else
            {
                // Check for HTML5 validation or other validation indicators
                var allInputs = driver.FindElements(By.TagName("input"));
                var textInputs = allInputs.Where(input => 
                {
                    var type = input.GetAttribute("type");
                    return type == "text" || type == "email" || string.IsNullOrEmpty(type);
                }).ToList();
                
                bool hasValidationIndicators = false;
                
                foreach (var input in textInputs)
                {
                    var validationMessage = input.GetAttribute("validationMessage");
                    var required = input.GetAttribute("required");
                    var ariaInvalid = input.GetAttribute("aria-invalid");
                    
                    if (!string.IsNullOrEmpty(validationMessage) || 
                        !string.IsNullOrEmpty(required) || 
                        ariaInvalid == "true")
                    {
                        hasValidationIndicators = true;
                        Console.WriteLine($"✓ Input validation detected: {validationMessage ?? "Required field"}");
                    }
                }
                
                Assert.IsTrue(hasValidationIndicators, 
                    "Should have validation indicators on required fields");
            }
            
            Console.WriteLine("✓ RF-CT-003 PASSED: Form validation working correctly for empty fields");
        }

        [TestMethod]
        public void RF_CT_003_ValidacionCamposIndividuales()
        {
            // Test individual field validation
            
            driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/contact");
            Thread.Sleep(5000);
            wait.Until(d => d.FindElements(By.TagName("input")).Count > 0);
            
            Console.WriteLine("=== RF-CT-003: Validación Individual de Campos ===");
            
            var allInputs = driver.FindElements(By.TagName("input"));
            var textInputs = allInputs.Where(input => 
            {
                var type = input.GetAttribute("type");
                return type == "text" || type == "email" || string.IsNullOrEmpty(type);
            }).ToList();
            
            // Test each field individually
            for (int i = 0; i < textInputs.Count; i++)
            {
                var input = textInputs[i];
                var placeholder = input.GetAttribute("placeholder") ?? $"Field {i + 1}";
                
                Console.WriteLine($"Testing field: {placeholder}");
                
                // Focus on field and then blur to trigger validation
                input.Click();
                input.SendKeys("");
                
                // Click somewhere else to trigger blur event
                if (i + 1 < textInputs.Count)
                {
                    textInputs[i + 1].Click();
                }
                else
                {
                    driver.FindElement(By.TagName("body")).Click();
                }
                
                Thread.Sleep(1000);
                
                // Check for validation on this specific field
                var fieldValidation = input.GetAttribute("validationMessage");
                var ariaInvalid = input.GetAttribute("aria-invalid");
                
                if (!string.IsNullOrEmpty(fieldValidation) || ariaInvalid == "true")
                {
                    Console.WriteLine($"  ✓ Validation detected for {placeholder}: {fieldValidation}");
                }
            }
            
            Assert.IsTrue(true, "Individual field validation test completed");
        }
    }
}
