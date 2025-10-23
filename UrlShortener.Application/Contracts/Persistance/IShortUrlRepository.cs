using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Contracts.Persistance
{
    public interface IShortUrlRepository : IAsyncRepository<ShortUrl>
    {
        Task<bool> IsUrlUniqueAsync(string originalUrl);
        Task<ShortUrl?> GetShortUrlByCodeAsync(string code);
    }
}
