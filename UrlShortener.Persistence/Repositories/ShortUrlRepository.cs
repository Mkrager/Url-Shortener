using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Persistence.Repositories
{
    public class ShortUrlRepository : BaseRepository<ShortUrl>, IShortUrlRepository
    {
        public ShortUrlRepository(UrlShortenerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsUrlUniqueAsync(string originalUrl)
        {
            var matches = await _dbContext.ShortUrls.AnyAsync(x => x.OriginalUrl.Equals(originalUrl));
            return !matches;
        }
    }
}