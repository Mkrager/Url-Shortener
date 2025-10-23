using MediatR;

namespace UrlShortener.Application.Features.ShortUrls.Commands.DeleteShortUrl
{
    public class DeleteShortUrlCommand : IRequest
    {
        public Guid Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public List<string>? UserRoles { get; set; }
    }
}