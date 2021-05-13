using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Xunit;

namespace unit_test_sample_app.intergration_test
{
    public class BaseControllerTest : IClassFixture<FakeApplicationFactory<FakeStartup>>
    {
        private readonly WebApplicationFactory<FakeStartup> _factory;

        public BaseControllerTest(FakeApplicationFactory<FakeStartup> factory)
        {
            _factory = factory;
        }

        protected WebApplicationFactory<FakeStartup> GetFactory(bool hasUser = false)
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.test.json");

            return _factory.WithWebHostBuilder(builder =>
                {
                    builder.UseSolutionRelativeContentRoot("unit_test_sample_app");

                    builder.ConfigureAppConfiguration((builderContext, config) =>
                    {
                        config.AddJsonFile(configPath);
                    });

                    builder.ConfigureTestServices(services =>
                    {
                        services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
                    });
                });
        }
    }
}
