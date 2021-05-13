using Microsoft.Extensions.DependencyInjection;
using unit_test_sample_app.core.BusinessServices.Implementations;
using unit_test_sample_app.core.BusinessServices.Interfaces;
using unit_test_sample_app.core.DataServices.Implementations;
using unit_test_sample_app.core.DataServices.Interfaces;

namespace unit_test_sample_app.core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Repository
            services.AddTransient<IStudentDataService, StudentDataService>();
            #endregion

            #region BusinessServices
            services.AddTransient<IStudentBusinessService, StudentBusinessService>();
            #endregion
            return services;
        }
    }
}
