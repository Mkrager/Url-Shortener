using UrlShortener.Application.DTOs.Authentication;

namespace UrlShortener.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> RegisterAsync(RegistrationRequest request);
    }
}