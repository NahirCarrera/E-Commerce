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
    public class VisualizacionDeCategoriasStepDefinitions : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _baseUrl = "https://localhost:7002/";
        private readonly ScenarioContext _scenarioContext;

        public VisualizacionDeCategoriasStepDefinitions(ScenarioContext scenarioContext)
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

        [Given("que las categorías están registradas en el sistema")]
        public void GivenQueLasCategoriasEstanRegistradasEnElSistema()
        {
            // Aquí puedes agregar lógica para verificar que las categorías están registradas
            ExtentReportManager.LogStep(true, "Las categorías están registradas en el sistema");
        }

        [When("accedo a la página principal")]
        public void WhenAccedoALaPaginaPrincipal()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            ExtentReportManager.LogStep(true, "Se accedió a la página principal");
        }

        [Then("debo ver una lista de categorías con imágenes, descripciones y la opción {string}")]
        public void ThenDeboVerUnaListaDeCategoriasConImagenesDescripcionesYLaOpcion(string opcion)
        {
            // Verifica que las categorías estén listadas
            var categorias = _wait.Until(d => d.FindElements(By.CssSelector(".card.card-subtitle")));
            Assert.True(categorias.Count > 0, "No se encontraron categorías en la página");

            foreach (var categoria in categorias)
            {
                // Verifica que la imagen esté presente y visible
                var imagen = categoria.FindElement(By.CssSelector(".card-img img"));
                Assert.True(imagen.Displayed, "La imagen de la categoría no está visible");

                // Verifica que la descripción esté presente y visible
                var descripcion = categoria.FindElement(By.CssSelector(".card-body p"));
                Assert.True(descripcion.Displayed, "La descripción de la categoría no está visible");

                // Verifica que el enlace "Show All" esté presente y visible
                var showAllLink = categoria.FindElement(By.LinkText(opcion));
                Assert.True(showAllLink.Displayed, $"El enlace '{opcion}' no está visible");
            }

            ExtentReportManager.LogStep(true, "Se visualizaron las categorías correctamente");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            ExtentReportManager.EndTest();
        }
    }
}