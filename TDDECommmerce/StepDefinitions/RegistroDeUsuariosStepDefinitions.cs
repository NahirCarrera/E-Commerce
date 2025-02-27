using System;
using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using TDDECommmerce.Reportes;
using System.Text.RegularExpressions;
using TDDECommmerce.Utilities;

namespace TDDECommmerce.StepDefinitions
{
    [Binding]
    public class RegistroDeUsuariosStepDefinitions : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _baseUrl = "https://localhost:7002/";
        private readonly ScenarioContext _scenarioContext;

        public RegistroDeUsuariosStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            string browser = "firefox";
            _driver = WebDriverManager.GetDriver(browser);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitReport(); // Inicializa el reporte
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ExtentReportManager.StartTest(_scenarioContext.ScenarioInfo.Title); // Inicia un nuevo test
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Given("que el formulario de registro está disponible")]
        public void GivenQueElFormularioDeRegistroEstaDisponible()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            _driver.FindElement(By.LinkText("Register")).Click();
            ExtentReportManager.LogStep(true, "Se accedió al formulario de registro");
        }

        [When(@"ingreso mi nombre ""(.*)"", apellido ""(.*)"", correo ""(.*)"", contraseña ""(.*)"" y confirmo la contraseña ""(.*)""")]
        public void WhenIngresoMiNombreApellidoCorreoContrasenaYConfirmoLaContrasena(string nombre, string apellido, string correo, string contrasena, string confirmarContrasena)
        {
            _driver.FindElement(By.Id("FirstName")).SendKeys(nombre);
            _driver.FindElement(By.Id("LastName")).SendKeys(apellido);
            _driver.FindElement(By.Id("Email")).SendKeys(correo);
            _driver.FindElement(By.Id("Password")).SendKeys(contrasena);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmarContrasena);
            ExtentReportManager.LogStep(true, $"Se ingresaron los datos: Nombre={nombre}, Apellido={apellido}, Correo={correo}, Contraseña={contrasena}, Confirmar Contraseña={confirmarContrasena}");
        }

        [When("envío el formulario")]
        public void WhenEnvioElFormulario()
        {
            _driver.FindElement(By.CssSelector("input[type='submit'][value='Sign Up']")).Click();
            ExtentReportManager.LogStep(true, "Se envió el formulario de registro");
        }

        [Then("el sistema debe aceptar el registro")]
        public void ThenElSistemaDebeAceptarElRegistro()
        {
            _wait.Until(d => d.Url == $"{_baseUrl}Account/Login"); // Espera a ser redirigido a la página de login
            Assert.Equal($"{_baseUrl}Account/Login", _driver.Url);
            ExtentReportManager.LogStep(true, "El sistema aceptó el registro y redirigió a la página de login");
        }

        [Then("el sistema no debe aceptar el registro")]
        public void ThenElSistemaNoDebeAceptarElRegistro()
        {
            Assert.True(_driver.Url == $"{_baseUrl}Account/Register"); // Verifica que no se redirigió
            ExtentReportManager.LogStep(true, "El sistema no aceptó el registro");
        }

        [Then(@"se debe mostrar un mensaje de advertencia indicando el formato esperado de contraseña:")]
        public void ThenSeDebeMostrarUnMensajeDeAdvertenciaIndicandoElFormatoEsperadoDeContrasena(string mensajeEsperado)
        {
            var mensajeErrores = _wait.Until(d => d.FindElements(By.CssSelector(".text-danger.validation-summary-errors ul li")));
            var mensajesTexto = mensajeErrores.Select(e => e.Text.Trim()).ToList();
            var mensajesEsperados = mensajeEsperado.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(m => m.Trim())
                                                   .ToList();
            foreach (var mensaje in mensajesEsperados)
            {
                Assert.True(mensajesTexto.Contains(mensaje), $"El mensaje '{mensaje}' no se encontró en los errores mostrados.");
            }

            ExtentReportManager.LogStep(true, $"Se mostraron los mensajes de advertencia: {mensajeEsperado}");
        }


        [Then(@"se debe mostrar un mensaje de advertencia indicando que las contraseñas no coinciden:")]
        public void ThenSeDebeMostrarUnMensajeDeAdvertenciaIndicandoQueLasContrasenasNoCoinciden(string mensajeEsperado)
        {
            var mensajeError = _wait.Until(d => d.FindElement(By.Id("ConfirmPassword-error"))).Text;
            Assert.Contains(mensajeEsperado, mensajeError);
            ExtentReportManager.LogStep(true, $"Se mostró el mensaje de advertencia: {mensajeEsperado}");
        }

        [When("envío el formulario sin llenar los datos")]
        public void WhenEnvioElFormularioSinLlenarLosDatos()
        {
            _driver.FindElement(By.CssSelector("input[type='submit'][value='Sign Up']")).Click();
            ExtentReportManager.LogStep(true, "Se envió el formulario sin llenar los datos");
        }

        [Then(@"se debe mostrar un mensaje de advertencia indicando que los campos son obligatorios:")]
        public void ThenSeDebeMostrarUnMensajeDeAdvertenciaIndicandoQueLosCamposSonObligatorios(string mensajeEsperado)
        {
            var mensajesError = _wait.Until(d => d.FindElements(By.CssSelector(".text-danger.field-validation-error")));
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
            ExtentReportManager.EndTest(); // Finaliza el test
        }
    }
}