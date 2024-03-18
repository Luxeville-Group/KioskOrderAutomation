using BoDi;
using Foodbu.Testing.Common.Domain.Managers;
using Foodbu.Testing.Common.Domain.Managers.Interface;
using Foodbu.Testing.Common.Model;
using Foodbu.Testing.UITest.PageObjects.Pages;

namespace Foodbu.Testing.UITest.Framework
{
    public class TestDependencies
    {
        public static IObjectContainer RegisterDependencies(IObjectContainer _objectContainer)
        {
            // Register Domain Services
            _objectContainer.RegisterInstanceAs(WinConfigurationManager.LoadWinConfigurations<TestConfiguration>());

            // Register driver manager
            _objectContainer.RegisterTypeAs<WinDriverManager, IDriverManager>();

            // Register Page Object
            _objectContainer.RegisterTypeAs<RestaurantMenuPage, RestaurantMenuPage>();
            _objectContainer.RegisterTypeAs<MenuMealPage, MenuMealPage>();

            return _objectContainer;
        }
    }
}
