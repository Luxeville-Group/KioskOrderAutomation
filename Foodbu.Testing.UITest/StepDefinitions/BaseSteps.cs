using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace Foodbu.Testing.UITest.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        protected readonly ScenarioContext scenarioContext;
        protected readonly FeatureContext featureContext;
        protected readonly WindowsDriver<WindowsElement> _driver;

        public BaseSteps()
        {
        }

        public BaseSteps(IWebDriver driver)
        {
            _driver = (WindowsDriver<WindowsElement>)driver;
        }

        public BaseSteps(IWebDriver driver,ScenarioContext scenarioContext)
        {
            _driver = (WindowsDriver<WindowsElement>)driver;
            this.scenarioContext = scenarioContext;
        }

        public BaseSteps(IWebDriver driver, FeatureContext featureContext)
        {
            _driver = (WindowsDriver<WindowsElement>)driver;
            this.featureContext = featureContext;
        }

        public BaseSteps(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _driver = (WindowsDriver<WindowsElement>)driver;
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }
    }
}
