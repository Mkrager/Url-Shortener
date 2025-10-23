namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlsList
{
    public class ShortUrlListVm
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}