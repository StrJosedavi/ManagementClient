using WassamaraManagement.Repository;
using WassamaraManagement.Repository.Interfaces;
using WassamaraManagement.Repository.UnitOfWork;
using WassamaraManagement.Services;
using WassamaraManagement.Services.Interfaces;

namespace WassamaraManagement.Ioc
{
    public class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<IAuthenticateService, AuthenticateService>();

            return services;
        }
    }
}
