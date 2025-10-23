using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence.Interceptors;

namespace UrlShortener.Persistence
{
    public class UrlShortenerDbContext : DbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor;
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options, AuditableEntitySaveChangesInterceptor auditableInterceptor)
            : base(options)
        {
            _auditableInterceptor = auditableInterceptor;
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}