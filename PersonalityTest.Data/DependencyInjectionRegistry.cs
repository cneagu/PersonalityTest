using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalityTest.Data.Repositories;
using PersonalityTest.Data.Repositories.Contract;

namespace PersonalityTest.Data
{
    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddDBServices(this IServiceCollection services)
        {
            services.AddDbContext<PersonalityTestContext>(options => options.UseInMemoryDatabase("items"));
            services.AddScoped<IPersonalityTestRepository, PersonalityTestRepository>();

            return services;
        }
    }
}
