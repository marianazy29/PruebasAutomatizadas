using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PruebasAutomatizadas.Pruebas_de_Sistema.RF_CT_001
{
    [TestClass]
    public sealed class ModuloContactoTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }


        /// <summary>
        /// Prueba automatizada que verifica que el formulario de contacto del sitio web
        /// "https://practicesoftwaretesting.com/contact" funcione correctamente cuando se ingresan datos válidos 
        /// y se adjunta un archivo válido. Mostrará el mensaje de exito después de enviar el formulario.
        /// </summary>

        /// Desarollado por Mariana Zúñiga Yáñez       
          [TestMethod]
          public void Contacto_DatosYAdjuntoValidos_MuestraMensajeExitoso()
          {
              /// 1. Navega a la página de contacto.
              driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/contact");

              /// 2. Completa los campos del formulario: nombre, apellido, correo, asunto y mensaje.
              var firstName = driver.FindElement(By.Id("first_name"));
              firstName.SendKeys("Mariana");

              var lastName = driver.FindElement(By.Id("last_name"));
              lastName.SendKeys("Zúñiga");

              var email = driver.FindElement(By.Id("email"));
              email.SendKeys("correoprueba@ubc.com");

              var subject = driver.FindElement(By.Id("subject"));
              subject.SendKeys("Payments");

              var message = driver.FindElement(By.Id("message"));
              message.SendKeys("Por favor quisiera información sobre el tiempo de los pagos.");

              // 3.Adjunta un archivo txt desde la ruta especificada.
              var fileInput = driver.FindElement(By.Id("attachment"));
              fileInput.SendKeys(@"C:\Users\Mariana\Documents\archivoVacio.txt");

              //4.Envía el formulario.
              var loginButton = driver.FindElement(By.CssSelector("input[type='submit']"));
              loginButton.Click();

              // 5. Verifica que se muestre el mensaje de éxito "Thanks for your message! We will contact you shortly."
              var messageSuccess = driver.FindElement(By.CssSelector("div.alert.alert-success.mt-3"));
              Assert.IsTrue(messageSuccess.Text.Contains("Thanks for your message! We will contact you shortly."));
          }

        /// <summary>
        /// Prueba automatizada que verifica que el módulo de contacto del sitio web
        /// "https://practicesoftwaretesting.com/contact" no dejará enviar el formulario cuando
        /// se adjunta un archivo no válido (pdf). Mostrará un mensaje de error, indicando que el formato del
        /// adjunto no es válido.
        /// </summary>

        /// Desarollado por Mariana Zúñiga Yáñez       
        [TestMethod]
        public void Contacto_DatosVálidosYAdjuntoInValidos_MuestraMensajeDeError()
        {
            /// 1. Navega a la página de contacto.
            driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/contact");

            /// 2. Completa los campos del formulario: nombre, apellido, correo, asunto y mensaje.
            var firstName = driver.FindElement(By.Id("first_name"));
            firstName.SendKeys("Mariana");

            var lastName = driver.FindElement(By.Id("last_name"));
            lastName.SendKeys("Zúñiga");

            var email = driver.FindElement(By.Id("email"));
            email.SendKeys("correoprueba@ubc.com");

            var subject = driver.FindElement(By.Id("subject"));
            subject.SendKeys("Payments");

            var message = driver.FindElement(By.Id("message"));
            message.SendKeys("Por favor quisiera información sobre el tiempo de los pagos.");

            // 3.Adjunta un archivo pdf desde la ruta especificada.
            var fileInput = driver.FindElement(By.Id("attachment"));
            fileInput.SendKeys(@"C:\Users\Mariana\Documents\archivoPdf.pdf");

            //4.Envía el formulario.
             var loginButton = driver.FindElement(By.CssSelector("input[type='submit']"));
             loginButton.Click();

             // 5. Verifica que se muestre el mensaje de error "File should have a txt extension."
             var messageError = driver.FindElement(By.XPath("//div[text()='File should have a txt extension.']"));
             Assert.IsTrue(messageError.Displayed);
        }

        
    }
}
