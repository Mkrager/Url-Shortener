using MediatR;

namespace UrlShortener.Application.Features.ShortUrls.Commands.DeleteShortUrl
{
    public class DeleteShortUrlCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}