using BoDi;
using Foodbu.Testing.Common.Domain.Managers.Interface;
using Foodbu.Testing.Common.Model;
using Foodbu.Testing.UITest.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace Foodbu.Testing.UITest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void DependenciesRegistration()
        {
            TestDependencies.RegisterDependencies(_objectContainer);
        }

        [BeforeScenario(Order = 1)]
        public void initializeApplication(IDriverManager driverManager, TestConfiguration testConfiguration)
        {
            _driver = driverManager.CreateDriver(testConfiguration);
            _objectContainer.RegisterInstanceAs(_driver);
        }

        [AfterScenario]
        public void Cleanup(ScenarioContext _scenarioContext)
        {
            if (_scenarioContext.TestError != null)
            {
                // Capture screenshot
                string scenarioTitle = _scenarioContext.ScenarioInfo.Title;
                string screenshotRootFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
                string screenshotFolder = Path.Combine(screenshotRootFolder, DateTime.Now.ToString("yyyy-MM-dd"));

                Directory.CreateDirectory(screenshotFolder);

                string screenshotPath = Path.Combine(screenshotFolder, $"{scenarioTitle}_{DateTime.Now.ToString("HH-mm-ss")}.png");
                CaptureScreenshot(screenshotPath);
            }

            _driver?.Quit();
        }
        private void CaptureScreenshot(string filename)
        {
            WindowsDriver<WindowsElement> driver = (WindowsDriver<WindowsElement>)_driver;
            Screenshot screenshot = driver.GetScreenshot();
            screenshot.SaveAsFile(filename, OpenQA.Selenium.ScreenshotImageFormat.Png);
            Console.WriteLine("Screenshot captured: " + filename);
        }

        [AfterTestRun]
        public static void GenerateLivingDocAfterAllTests()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Dynamic path to the test assembly
            var testAssemblyPath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;

            // Get TestExecution.json path as it's in the same directory as the test assembly
            var testExecutionJsonPath = Path.Combine(Path.GetDirectoryName(testAssemblyPath), "TestExecution.json");

            // Setting Output HTML path for Foodbu Test Report 
            var outputHtmlPath = Path.Combine(baseDirectory, "Foodbu Test Report.html");
            // Check if the file exists and delete it if it does
            if (File.Exists(outputHtmlPath))
            {
                File.Delete(outputHtmlPath);
            }

            var command = $"livingdoc test-assembly '{testAssemblyPath}' -t '{testExecutionJsonPath}' -o '{outputHtmlPath}'";

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();
            // Log the output for debugging or confirmation purposes.
        }
    }
}
