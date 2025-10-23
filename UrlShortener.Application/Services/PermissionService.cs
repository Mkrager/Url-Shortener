using UrlShortener.Application.Contracts.Application;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Services
{
    public class PermissionService : IPermissionService
    {
        public bool IsCreatedByUser(ShortUrl shortUrl, string userId)
        {
            if (shortUrl is null)
                return false;

            return shortUrl.CreatedBy == userId;
        }
        public bool UserHasPrivilegedRole(List<string> roles)
        {
            if (roles == null || roles.Count == 0)
                return false;

            return roles.Contains("Admin");
        }
    }
}