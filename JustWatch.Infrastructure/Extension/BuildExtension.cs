using JustWatch.Domain.SeedWork;
using JustWatch.Infrastructure.Context;
using JustWatch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace JustWatch.Infrastructure.Extension
{
    public static class BuildExtension
    {

        public static IServiceCollection RegisterMsSqlServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionStr");
            services.AddDbContext<JustWatchContext>(options =>
                options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddScoped(typeof(IJustWatchRepository<>), typeof(JustWatchRepository<>));
            return services;
        }
    }
}
