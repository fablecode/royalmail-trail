using System;
using Microsoft.Extensions.DependencyInjection;

namespace royalmail.trail.application
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
