using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Identity
{
    public class UrlShortenerIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public UrlShortenerIdentityDbContext()
        {

        }

        public UrlShortenerIdentityDbContext(DbContextOptions<UrlShortenerIdentityDbContext> options) : base(options)
        {

        }
    }
}
