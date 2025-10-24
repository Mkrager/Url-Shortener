using MediatR;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails
{
    public class GetShortUrlDetailQuery : IRequest<ShortUrlDetailVm>
    {
        public Guid Id { get; set; }
    }
}
