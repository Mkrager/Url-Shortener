using MediatR;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails
{
    public class ShortUrlDetailQuery : IRequest<ShortUrlDetailVm>
    {
        public Guid Id { get; set; }
    }
}
