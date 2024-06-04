

using JustWatch.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace JustWatch.Infrastructure.Extension
{
    public static class ServiceExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}
