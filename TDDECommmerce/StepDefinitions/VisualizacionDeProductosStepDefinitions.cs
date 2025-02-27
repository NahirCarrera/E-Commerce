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
    public class VisualizacionDeProductosStepDefinitions : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _baseUrl = "https://localhost:7002/Product/ListByCategory?CategoryId=1";
        private readonly ScenarioContext _scenarioContext;

        public VisualizacionDeProductosStepDefinitions(ScenarioContext scenarioContext)
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

        [Given("que las categorías y productos están registrados en el sistema")]
        public void GivenQueLasCategoriasYProductosEstanRegistradosEnElSistema()
        {
            // Aquí puedes agregar lógica para verificar que las categorías y productos están registrados
            ExtentReportManager.LogStep(true, "Las categorías y productos están registrados en el sistema");
        }
        [When("accedo a la página de productos de una categoria")]
        public void WhenAccedoALaPaginaPrincipal()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            ExtentReportManager.LogStep(true, "Se accedió a la página principal");
        }

        [Then("debo ver una lista de productos con títulos, imágenes, descripciones, precios y la opción {string}")]
        public void ThenDeboVerUnaListaDeProductosConTitulosImagenesDescripcionesYLaOpcion(string opcion)
        {
            // Verifica que los productos estén listados
            var productos = _wait.Until(d => d.FindElements(By.CssSelector(".card")));
            Assert.True(productos.Count > 0, "No se encontraron productos en la página");

            foreach (var producto in productos)
            {
                // Verifica que la imagen esté presente y visible
                var imagen = producto.FindElement(By.CssSelector("img"));
                Assert.True(imagen.Displayed, "La imagen del producto no está visible");

                // Verifica que el título esté presente y visible
                var titulo = producto.FindElement(By.CssSelector("h1"));
                Assert.True(titulo.Displayed, "El título del producto no está visible");

                // Verifica que el precio esté presente y visible
                var precio = producto.FindElement(By.CssSelector(".price"));
                Assert.True(precio.Displayed, "El precio del producto no está visible");

                // Verifica que la descripción esté presente y visible
                var descripcion = producto.FindElement(By.XPath("p[not(@class='price')]"));
                Assert.True(descripcion.Displayed, "La descripción del producto no está visible");

                // Verifica que el botón "Add to Cart" esté presente y visible
                var addToCartButton = producto.FindElement(By.CssSelector(".btn.btn-success"));
                Assert.True(addToCartButton.Displayed, "El botón 'Add to Cart' no está visible");
            }

            ExtentReportManager.LogStep(true, "Se visualizaron los productos correctamente");
        }



        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            ExtentReportManager.EndTest();
        }
    }
}