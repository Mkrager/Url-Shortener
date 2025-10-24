using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.Contracts.Infrastructure;

namespace UrlShortener.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ICodeService, CodeService>();

            return services;
        }
    }
}
