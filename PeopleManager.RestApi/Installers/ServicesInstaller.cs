using PeopleManager.Services;

namespace PeopleManager.RestApi.Installers
{
    public static class ServicesInstaller
    {
        public static IServiceCollection InstallServices(this IServiceCollection services)
        {
            services.AddScoped<FunctionService>();
            services.AddScoped<PersonService>();

            return services;
        }
    }
}
