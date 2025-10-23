using MediatR;

namespace UrlShortener.Application.Features.Account.Commands.Registration
{
    public class RegistrationCommand : IRequest<string>
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
