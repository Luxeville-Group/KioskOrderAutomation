using Foodbu.Testing.UITest.PageObjects.ObjectRepository;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using Foodbu.Testing.Common.Model;
using FluentAssertions;
using System.Linq;

namespace Foodbu.Testing.UITest.PageObjects.Pages
{
    public class MenuMealPage
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public MenuMealPage(IWebDriver driver)
        {
            _driver = (WindowsDriver<WindowsElement>)driver;
        }

        public WindowsElement MenuItemsPane => _driver.FindElementByAccessibilityId(OR.MENU_ITEMS_PANE_ID);

        public void VerifyDish(Dish expectedDish)
        {
            var parentElements = MenuItemsPane.FindElementsByAccessibilityId(OR.ITEMS_MEAL_PAGE_ID);

            var dishElement = parentElements.FirstOrDefault(element =>
            {
                var dishNameLabel = element.FindElementByAccessibilityId(OR.MEAL_NAME_ID);
                return dishNameLabel.Text == expectedDish.DishName;
            });

            dishElement.Should().NotBeNull("Dish should be found");

            var dishNameLabel = dishElement.FindElementByAccessibilityId(OR.MEAL_NAME_ID);
            var dishPriceLabel = dishElement.FindElementByAccessibilityId(OR.MEAL_PRICE_ID);
            var dishButton = dishElement.FindElementByAccessibilityId(OR.MEAL_BUTTON_ID);

            dishElement.Displayed.Should().Be(expectedDish.Visibility, "Dish Visibility should match");
            dishNameLabel.Text.Should().Be(expectedDish.DishName, "Dish Name should match");
            dishPriceLabel.Text.Should().Be(expectedDish.DishPrice, "Dish Price should match");
            dishButton.Enabled.Should().Be(expectedDish.Visibility, "Dish Button Clickable should be as Dish Visibility");
        }
    }
}
