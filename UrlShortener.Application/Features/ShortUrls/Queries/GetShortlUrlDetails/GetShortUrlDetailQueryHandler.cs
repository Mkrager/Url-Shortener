using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Exceptions;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails
{
    public class GetShortUrlDetailQueryHandler : IRequestHandler<GetShortUrlDetailQuery, ShortUrlDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ShortUrl> _shortUrlRepository;
        public GetShortUrlDetailQueryHandler(IAsyncRepository<ShortUrl> shortUrlRepository, IMapper mapper)
        {
            _mapper = mapper;
            _shortUrlRepository = shortUrlRepository;
        }
        public async Task<ShortUrlDetailVm> Handle(GetShortUrlDetailQuery request, CancellationToken cancellationToken)
        {
            var shortUrl = await _shortUrlRepository.GetByIdAsync(request.Id);

            if (shortUrl == null)
                throw new NotFoundException(nameof(ShortUrl), request.Id);

            return _mapper.Map<ShortUrlDetailVm>(shortUrl);
        }
    }
}