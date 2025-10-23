using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Exceptions;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Queries.GetShortlUrlDetails
{
    public class ShortUrlDetailQueryHandler : IRequestHandler<ShortUrlDetailQuery, ShortUrlDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ShortUrl> _shortUrlRepository;
        public ShortUrlDetailQueryHandler(IAsyncRepository<ShortUrl> shortUrlRepository, IMapper mapper)
        {
            _mapper = mapper;
            _shortUrlRepository = shortUrlRepository;
        }
        public async Task<ShortUrlDetailVm> Handle(ShortUrlDetailQuery request, CancellationToken cancellationToken)
        {
            var shortUrl = await _shortUrlRepository.GetByIdAsync(request.Id);

            if (shortUrl == null)
                throw new NotFoundException(nameof(ShortUrl), request.Id);

            return _mapper.Map<ShortUrlDetailVm>(shortUrl);
        }
    }
}