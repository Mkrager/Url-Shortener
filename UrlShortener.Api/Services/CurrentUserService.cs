using System.Security.Claims;
using UrlShortener.Application.Contracts;

namespace UrlShortener.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string UserId =>
            _contextAccessor.HttpContext.User.FindFirst("uid")?.Value;

        public List<string> UserRoles =>
            _contextAccessor.HttpContext?.User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
    }
}