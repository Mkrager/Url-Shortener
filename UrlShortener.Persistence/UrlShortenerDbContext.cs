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
        public DbSet<AboutPage> AboutPage { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableInterceptor);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutPage>().HasData(
                new AboutPage
                {
                    Id = Guid.Parse("cf140332-bddc-424e-8550-fd65bee52e78"),
                    Content = "Our URL Shortener allows you to quickly generate a short and easy-to-share link for any long URL. The shortening process works using a simple algorithm implemented in our CodeService. 1) Character Set: The service uses a set of 62 characters, including lowercase letters (a-z), uppercase letters (A-Z), and digits (0-9). 2) Random Generation: For each URL, the service generates a random string of a default length of 6 characters. This string serves as the unique short code. 3) Short URL Creation: The generated short code is appended to our domain, producing a short link like https://localhost:7018/shortUrl/s/dvYUXJ. 4) Redirection: When someone visits the short URL, our service looks up the original URL associated with the code and redirects the user automatically. This approach ensures that every short URL is unique and can be quickly generated without collisions in most cases. Admins can manage all short URLs and their associated original links."
                });
        }
    }
}