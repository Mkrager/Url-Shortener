using UrlShortener.App.Infrastructure.Api;
using UrlShortener.App.ViewModels;

namespace UrlShortener.App.Contracts
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> Authenticate(AuthenticateRequest request);
        Task<ApiResponse> Register(RegistrationRequest request);
        Task Logout();
    }
}
