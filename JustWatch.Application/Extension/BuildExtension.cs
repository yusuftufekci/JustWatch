using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace JustWatch.Application.Extension
{
    public static class BuildExtension
    {
        public static IServiceCollection MediatorServices(this IServiceCollection services)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var assembly = Directory.GetFiles(path,"JustWatch.Application.dll",SearchOption.TopDirectoryOnly)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                .FirstOrDefault();
            services.AddMediatR(x=> x.RegisterServicesFromAssemblies(assembly));
            return services;
         
        }
    }
}
