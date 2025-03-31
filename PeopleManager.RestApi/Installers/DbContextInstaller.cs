using Microsoft.EntityFrameworkCore;
using PeopleManager.Repository;

namespace PeopleManager.RestApi.Installers
{
    public static class DbContextInstaller
    {
        public static IServiceCollection InstallDbContext(this IServiceCollection services)
        {
            //var connectionString = builder.Configuration.GetConnectionString(nameof(PeopleManagerDbContext));
            services.AddDbContext<PeopleManagerDbContext>(options =>
            {
                //options.UseSqlServer(connectionString);
                options.UseInMemoryDatabase(nameof(PeopleManagerDbContext));
            });

            return services;
        }

    }
}
