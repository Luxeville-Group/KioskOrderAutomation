using Foodbu.Testing.UITest.PageObjects.ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace Foodbu.Testing.UITest.PageObjects.Pages
{
    public class RestaurantMenuPage
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        // Constructor
        public RestaurantMenuPage(IWebDriver driver)
        {
            _driver = (WindowsDriver<WindowsElement>)driver;
        }

        public WindowsElement MenuMains => _driver.FindElementByAccessibilityId(OR.MENU_MAINS_ID);
        public WindowsElement MenuToppings => _driver.FindElementByAccessibilityId(OR.MENU_TOPPINGS_ID);
        public WindowsElement MenuGreens => _driver.FindElementByAccessibilityId(OR.MENU_GREENS_ID);
        public WindowsElement MenuDipsSpreads => _driver.FindElementByAccessibilityId(OR.MENU_DIPS_SPREADS_ID);
        public WindowsElement MenuDrinks => _driver.FindElementByAccessibilityId(OR.MENU_DRINKS_ID);
        public WindowsElement MenuDemo => _driver.FindElementByAccessibilityId(OR.MENU_DEMO_ID);

    }
}
