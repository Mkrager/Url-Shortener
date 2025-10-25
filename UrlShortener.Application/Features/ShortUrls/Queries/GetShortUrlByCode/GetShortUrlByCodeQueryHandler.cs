using MediatR;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Exceptions;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortUrlByCode
{
    public class GetShortUrlByCodeQueryHandler : IRequestHandler<GetShortUrlByCodeQuery, string>
    {
        private readonly IShortUrlRepository _shortUrlRepository;
        public GetShortUrlByCodeQueryHandler(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }
        public async Task<string> Handle(GetShortUrlByCodeQuery request, CancellationToken cancellationToken)
        {
            var url = await _shortUrlRepository.GetShortUrlByCodeAsync(request.Code);

            if (url == null)
                throw new NotFoundException(nameof(ShortUrl), request.Code);

            return url.OriginalUrl;
        }
    }
}