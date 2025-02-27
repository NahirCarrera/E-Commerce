using System;
using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using TDDECommmerce.Reportes;
using TDDECommmerce.Utilities;

namespace TDDECommmerce.StepDefinitions
{
    [Binding]
    public class InicioDeSesionStepDefinitions : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _baseUrl = "https://localhost:7002/";
        private readonly ScenarioContext _scenarioContext;

        public InicioDeSesionStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            string browser = "firefox";
            _driver = WebDriverManager.GetDriver(browser);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ExtentReportManager.StartTest(_scenarioContext.ScenarioInfo.Title);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Given("que el formulario de inicio de sesión está disponible")]
        public void GivenQueElFormularioDeInicioDeSesionEstaDisponible()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "Account/Login");
            ExtentReportManager.LogStep(true, "Se accedió al formulario de inicio de sesión");
        }

        [When(@"ingreso mi correo ""(.*)"" y contraseña ""(.*)""")]
        public void WhenIngresoMiCorreoYContrasena(string correo, string contrasena)
        {
            _driver.FindElement(By.Id("Email")).SendKeys(correo);
            _driver.FindElement(By.Id("Password")).SendKeys(contrasena);
            ExtentReportManager.LogStep(true, $"Se ingresaron las credenciales: {correo}, {contrasena}");
        }

        [When("inicio sesión")]
        public void WhenInicioSesion()
        {
            _driver.FindElement(By.CssSelector("input[type='submit'][value='Login']")).Click();
            ExtentReportManager.LogStep(true, "Se hizo clic en el botón de inicio de sesión");
        }

        [Then("el sistema debe autenticar al usuario")]
        public void ThenElSistemaDebeAutenticarAlUsuario()
        {
            _wait.Until(d => d.Url == _baseUrl);
            Assert.Equal(_baseUrl, _driver.Url);
            ExtentReportManager.LogStep(true, "El usuario fue autenticado y redirigido a la página de inicio");
        }

        [Then("el sistema no debe aceptar el inicio de sesión")]
        public void ThenElSistemaNoDebeAceptarElInicioDeSesion()
        {
            Assert.Contains("Login", _driver.Url); // Verifica que la URL aún esté en la página de inicio de sesión
            ExtentReportManager.LogStep(true, "El sistema no aceptó el inicio de sesión");
        }

        [Then(@"se debe mostrar un mensaje de advertencia indicando que la contraseña ingresada es incorrecta: ""(.*)""")]
        public void ThenSeDebeMostrarUnMensajeDeAdvertenciaPorContrasenaIncorrecta(string mensajeEsperado)
        {
            var mensajeError = _wait.Until(d => d.FindElement(By.CssSelector(".text-danger")).Text);
            Assert.Contains(mensajeEsperado, mensajeError);
            ExtentReportManager.LogStep(true, $"Mensaje de error mostrado: {mensajeEsperado}");
        }

        [Then(@"se debe mostrar un mensaje de advertencia indicando que el correo no ha sido registrado: ""(.*)""")]
        public void ThenSeDebeMostrarUnMensajeDeAdvertenciaPorCorreoNoRegistrado(string mensajeEsperado)
        {
            var mensajeError = _wait.Until(d => d.FindElement(By.CssSelector(".text-danger")).Text);
            Assert.Contains(mensajeEsperado, mensajeError);
            ExtentReportManager.LogStep(true, $"Mensaje de error mostrado: {mensajeEsperado}");
        }

        [When("envío el formulario de inicio de sesion sin llenar los datos")]
        public void WhenEnvioElFormularioSinLlenarLosDatos()
        {
            _driver.FindElement(By.CssSelector("input[type='submit'][value='Login']")).Click();
            ExtentReportManager.LogStep(true, "Se envió el formulario sin llenar los datos");
        }

        [Then(@"se debe mostrar un mensaje de advertencia indicando que los campos son obligatorios en el inicio de sesión:")]
        public void ThenSeDebeMostrarUnMensajeDeAdvertenciaPorCamposVacios(string mensajeEsperado)
        {
            var mensajesError = _wait.Until(d => d.FindElements(By.CssSelector(".text-danger")));
            var mensajesTexto = mensajesError.Select(e => e.Text.Trim()).ToList();
            var mensajesEsperados = mensajeEsperado.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(m => m.Trim())
                                                   .ToList();
            foreach (var mensaje in mensajesEsperados)
            {
                Assert.Contains(mensaje, mensajesTexto);
            }

            ExtentReportManager.LogStep(true, $"Se mostraron los mensajes de advertencia: {mensajeEsperado}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            ExtentReportManager.EndTest();
        }
    }
}
