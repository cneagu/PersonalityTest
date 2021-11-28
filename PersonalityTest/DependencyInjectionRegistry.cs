using Microsoft.Extensions.DependencyInjection;
using PersonalityTest.Manager;
using PersonalityTest.Resource;
using PersonalityTest.Resource.Contract;

namespace PersonalityTest
{
    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ITestResource, TestResource>();
            services.AddScoped<Contract.ITestManager, TestManager>();
            return services;
        }
    }
}
