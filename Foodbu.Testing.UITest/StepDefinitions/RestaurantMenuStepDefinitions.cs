using FluentAssertions;
using Foodbu.Testing.Common.Model;
using Foodbu.Testing.UITest.PageObjects.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Foodbu.Testing.UITest.StepDefinitions
{
    public class RestaurantMenuStepDefinitions : BaseSteps
    {
        private readonly RestaurantMenuPage _restaurantMenuPage;
        private readonly MenuMealPage _menuMealPage;
        public RestaurantMenuStepDefinitions(IWebDriver driver,
            RestaurantMenuPage restaurantMenuPage, MenuMealPage menuMealPage) : base(driver)
        {
            _restaurantMenuPage = restaurantMenuPage;
            _menuMealPage = menuMealPage;
        }

        [Given(@"I have launched the FoodBu application")]
        public void GivenIHaveLaunchedTheFoodBuApplication()
        {
            _driver.Should().NotBeNull();
        }

        [When(@"I navigate to the MAINS section")]
        public void WhenINavigateToTheMAINSSection()
        {
            _restaurantMenuPage.MenuMains.Click();
        }

        [Then(@"The list of available dishes pane should be visible")]
        public void ThenTheListOfAvailableDishesPaneShouldBeVisible()
        {
            _menuMealPage.MenuItemsPane.Displayed.Should().BeTrue();

        }

        [Then(@"Dishes with their prices should be as follow")]
        public void ThenDishesWithTheirPricesShouldBeAsFollow(Table dishesTable)
        {
            var expectedDishes = dishesTable.CreateSet<Dish>();

            foreach (var dish in expectedDishes)
            {
                _menuMealPage.VerifyDish(dish);
            }
        }

    }
}
