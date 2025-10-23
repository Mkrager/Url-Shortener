using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Entities
{
    public class ShortUrl : AuditableEntity
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
    }
}