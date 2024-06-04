using JustWatch.Domain.SeedWork;
using JustWatch.Infrastructure.Context;
using JustWatch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace JustWatch.Infrastructure.Extension
{
    public static class BuildExtension
    {
        public static IServiceCollection RegisterMsSqlServices(this IServiceCollection services)
        {
            var conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JustWatch;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            services.AddDbContext<JustWatchContext>(options =>
                options.UseSqlServer(conn), ServiceLifetime.Scoped);
            services.AddScoped(typeof(IJustWatchRepository<>), typeof(JustWatchRepository<>));
            return services;
        }
    }
}
