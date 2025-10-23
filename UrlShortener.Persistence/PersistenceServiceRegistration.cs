using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Persistence.Interceptors;

namespace UrlShortener.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UrlShortenerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString
            ("UrlShortenerConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            return services;
        }
    }
}
