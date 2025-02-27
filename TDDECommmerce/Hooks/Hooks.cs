using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDECommmerce.Reportes;

namespace TDDECommmerce.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitReport();
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ExtentReportManager.StartTest(scenarioContext.ScenarioInfo.Title);
        }
        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            var stepInfo = scenarioContext.StepContext.StepInfo.Text;
            var isSuccessfull = scenarioContext.StepContext.TestError == null;
            ExtentReportManager.LogStep(isSuccessfull, isSuccessfull ? $"Paso exitoso: {stepInfo}" : $"Error: {scenarioContext.TestError.Message}");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.EndTest();
        }



        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://go.reqnroll.net/doc-hooks#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
