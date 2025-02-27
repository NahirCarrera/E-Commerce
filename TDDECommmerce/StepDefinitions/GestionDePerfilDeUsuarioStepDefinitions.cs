using System;
using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using TDDECommmerce.Reportes;
using System.Linq;
using TDDECommmerce.Utilities;

namespace TDDECommmerce.StepDefinitions
{
    [Binding]
    public class GestionDePerfilDeUsuarioStepDefinitions : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _baseUrl = "https://localhost:7002/";
        private readonly ScenarioContext _scenarioContext;

        public GestionDePerfilDeUsuarioStepDefinitions(ScenarioContext scenarioContext)
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

        [Given("que he iniciado sesión en el sistema")]
        public void GivenQueHeIniciadoSesionEnElSistema()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "Account/Login");
            _driver.FindElement(By.Id("Email")).SendKeys("admin@example.com");
            _driver.FindElement(By.Id("Password")).SendKeys("Admin1234*");
            _driver.FindElement(By.CssSelector("input[type='submit'][value='Login']")).Click();
            ExtentReportManager.LogStep(true, "Se inició sesión con admin@example.com");
        }

        [Given("accedo a la sección de perfil")]
        public void GivenAccedoALaSeccionDePerfil()
        {
            // Busca un elemento que contenga el texto "Hello" (por ejemplo, "Hello admin")
            var helloElement = _wait.Until(d => d.FindElement(By.XPath("//a[contains(text(), 'Hello')]")));

            // Haz clic en el elemento
            helloElement.Click();
            ExtentReportManager.LogStep(true, "Se accedió a la sección de perfil");
        }

        [When("edito el campo username con {string}")]
        public void WhenEditoElCampoUsernameCon(string username)
        {
            var usernameField = _driver.FindElement(By.Id("Username"));
            usernameField.Clear();
            usernameField.SendKeys(username);
            ExtentReportManager.LogStep(true, $"Se editó el campo username con: {username}");
        }

        [When("guardo los cambios")]
        public void WhenGuardoLosCambios()
        {
            // Usa un selector más específico para el botón "Update"
            _driver.FindElement(By.CssSelector("button.btn.btn-primary.mt-3")).Click();
            ExtentReportManager.LogStep(true, "Se guardaron los cambios");
        }


        [Then("el perfil debe mostrarse con los nuevos datos")]
        public void ThenElPerfilDebeMostrarseConLosNuevosDatos()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            var helloElement = _wait.Until(d => d.FindElement(By.XPath("//a[contains(text(), 'Hello')]")));
            helloElement.Click();
            // Espera a que el campo "Username" esté presente en la página
            var usernameField = _wait.Until(d => d.FindElement(By.Id("Username")));

            // Obtén el valor del campo usando la propiedad "Value"
            var usernameValue = usernameField.GetAttribute("value");

            // Verifica que el valor sea el esperado
            Assert.Equal("TestUser", usernameValue);
            ExtentReportManager.LogStep(true, $"El campo username muestra el valor: {usernameValue}");
        }

        [When("elimino la información del campo username")]
        public void WhenEliminoLaInformacionDelCampoUsername()
        {
            var usernameField = _driver.FindElement(By.Id("Username"));
            usernameField.Clear();
            ExtentReportManager.LogStep(true, "Se eliminó la información del campo username");
        }

        [Then("se debe mostrar un mensaje de advertencia indicando que el campo es requerido: {string}")]
        public void ThenSeDebeMostrarUnMensajeDeAdvertenciaIndicandoQueElCampoEsRequerido(string mensajeEsperado)
        {
            // Busca el mensaje de error dentro del span con data-valmsg-for="Username"
            var mensajeError = _wait.Until(d => d.FindElement(By.CssSelector("span[data-valmsg-for='Username']")).Text);

            // Verifica que el mensaje de error contenga el texto esperado
            Assert.Contains(mensajeEsperado, mensajeError);
            ExtentReportManager.LogStep(true, $"Se mostró el mensaje de advertencia: {mensajeEsperado}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            ExtentReportManager.EndTest();
        }
    }
}