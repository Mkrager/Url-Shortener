using MediatR;
using UrlShortener.Application.Common.Interfaces;

namespace UrlShortener.Application.Features.ShortUrls.Commands.DeleteShortUrl
{
    public class DeleteShortUrlCommand : IUserRequest, IRequest
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public List<string> UserRoles { get; set; } = new List<string>();
    }
}