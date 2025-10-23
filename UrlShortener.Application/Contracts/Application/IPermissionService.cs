using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Contracts.Application
{
    public interface IPermissionService
    {
        bool IsCreatedByUser(ShortUrl shortUrl, string userId);
        bool UserHasPrivilegedRole(List<string> roles);
    }
}