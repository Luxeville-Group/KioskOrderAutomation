using Foodbu.Testing.Common.Model;
using OpenQA.Selenium;

namespace Foodbu.Testing.Common.Domain.Managers.Interface
{
    public interface IDriverManager
    {
        IWebDriver CreateDriver(TestConfiguration settings);
    }
}
