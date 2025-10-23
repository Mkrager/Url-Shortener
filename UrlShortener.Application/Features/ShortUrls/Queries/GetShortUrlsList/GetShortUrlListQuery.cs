using MediatR;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlsList
{
    public class GetShortUrlListQuery : IRequest<List<ShortUrlListVm>>
    {
    }
}
