using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace Foodbu.Testing.Common.Domain.Managers
{
    public class WinConfigurationManager
    {
        public static T LoadWinConfigurations<T>()
        {
            try
            {
                IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("testsettings.json")
                .Build();

                return Configuration.Get<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("testsettings.json file not found", ex);
            }
        }
    }
}
