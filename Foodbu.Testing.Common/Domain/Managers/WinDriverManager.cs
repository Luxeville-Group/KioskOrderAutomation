using Foodbu.Testing.Common.Domain.Managers.Interface;
using Foodbu.Testing.Common.Model;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Foodbu.Testing.Common.Domain.Managers
{
    public class WinDriverManager : IDriverManager
    {
        public IWebDriver CreateDriver(TestConfiguration settings)
        {
            // Start WinAppDriver process
            Process.Start(settings.WindowsAppDriver);

            // Wait for WinAppDriver server to start
            while (!IsWinAppDriverRunning())
            {
                Thread.Sleep(1000);
            }

            string pathToExecutable = Path.Combine(settings.ApplicationWorkingDirectory, settings.Application);
            string executableDirectory = Path.GetDirectoryName(pathToExecutable);

            // Create Appium options
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", pathToExecutable);
            options.AddAdditionalCapability("platformName", settings.PlatformName);
            options.AddAdditionalCapability("deviceName", settings.DeviceName);

            // Set the working directory for the application
            options.AddAdditionalCapability("appWorkingDir", executableDirectory);

            // Create WindowsDriver instance
            var driver = new WindowsDriver<WindowsElement>(new Uri(settings.WindowsApplicationDriverUrl), options);

            return driver;
        }

        private bool IsWinAppDriverRunning()
        {
            // Check if WinAppDriver process is running
            Process[] processes = Process.GetProcessesByName("WinAppDriver");
            return processes.Length > 0;
        }
    }
}
