using Microsoft.Extensions.DependencyInjection;

namespace PeopleManager.Sdk.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApi(this IServiceCollection services, string apiUrl)
        {
            services.AddHttpClient("PeopleManagerApi", configure =>
            {
                configure.BaseAddress = new Uri("https://localhost:7175");
            });

            // Register Api Services
            services.AddScoped<FunctionApiService>();
            services.AddScoped<PersonApiService>();

        }
    }
}
