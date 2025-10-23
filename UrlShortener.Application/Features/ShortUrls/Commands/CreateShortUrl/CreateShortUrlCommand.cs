using MediatR;

namespace UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommand : IRequest<Guid>
    {
        public string OriginalUrl { get; set; } = string.Empty;
    }
}