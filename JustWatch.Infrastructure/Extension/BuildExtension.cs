using JustWatch.Domain.SeedWork;
using JustWatch.Infrastructure.Context;
using JustWatch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace JustWatch.Infrastructure.Extension
{
    public static class BuildExtension
    {
        public static IServiceCollection RegisterMsSqlServices(this IServiceCollection services)
        {
            var conn = "ConnectionString";
            services.AddDbContext<JustWatchContext>(options =>
                options.UseSqlServer(conn), ServiceLifetime.Scoped);
            services.AddScoped(typeof(IJustWatchRepository<>), typeof(JustWatchRepository<>));
            return services;
        }
    }
}
