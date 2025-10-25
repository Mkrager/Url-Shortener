using MediatR;

namespace UrlShortener.Application.Features.AboutPages.Commands.UpdateAboutPage
{
    public class UpdateAboutPageCommand : IRequest
    {
        public string Content { get; set; } = string.Empty;
    }
}
