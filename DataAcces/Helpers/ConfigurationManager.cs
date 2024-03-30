using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Helpers
{
    public static class ConfigurationManager
    {
        private static IConfiguration _configuration;

        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                    IConfigurationBuilder builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);


                    _configuration = builder.Build();
                }
                return _configuration;
            }
            set => _configuration = value;
        }
    }
}
