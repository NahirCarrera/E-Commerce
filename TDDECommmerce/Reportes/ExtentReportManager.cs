using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDECommmerce.Reportes
{
    internal class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportPath = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", "ExtentReport.html");

        public static void InitReport()
        {
            _extent = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(_reportPath);
            _extent.AttachReporter(sparkReporter);
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogStep(bool isSuccessfull, string stepDetails)
        {
            if (isSuccessfull)
            {
                _test.Log(Status.Pass, stepDetails);
            }
            else
            {
                _test.Log(Status.Fail, stepDetails);
            }
        }

        public static void EndTest()
        {
            _extent.Flush();
        }

    }
}
