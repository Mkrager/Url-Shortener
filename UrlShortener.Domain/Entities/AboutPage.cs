using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Entities
{
    public class AboutPage : AuditableEntity
    {
        public string Content { get; set; } = string.Empty;
    }
}