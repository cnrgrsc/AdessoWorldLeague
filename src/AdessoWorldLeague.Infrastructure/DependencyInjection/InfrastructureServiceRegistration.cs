
using AdessoWorldLeague.Domain.Repositories;
using AdessoWorldLeague.Infrastructure.Context;
using AdessoWorldLeague.Infrastructure.Repositories;
using AdessoWorldLeague.Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdessoWorldLeague.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext eklenmesi
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repository implementasyonlarının enjekte edilmesi
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IDrawRepository, DrawRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();


            // Veritabanı ilk verilerinin yüklenmesi için DataSeeder eklenmesi
            services.AddTransient<DataSeeder>();

            return services;
        }
    }
}
