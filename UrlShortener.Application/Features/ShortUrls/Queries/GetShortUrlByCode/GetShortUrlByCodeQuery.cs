using MediatR;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlByCode
{
    public class GetShortUrlByCodeQuery : IRequest<string>
    {
        public string Code { get; set; } = string.Empty;
    }
}
