using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<ShortUrl> _shortUrlRepository;

        public CreateShortUrlCommandHandler(IMapper mapper, IAsyncRepository<ShortUrl> shortUrlRepository)
        {
            _mapper = mapper;
            _shortUrlRepository = shortUrlRepository;
        }
        public async Task<Guid> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            var shortUrl = _mapper.Map<ShortUrl>(request);

            await _shortUrlRepository.AddAsync(shortUrl);

            return shortUrl.Id;
        }
    }
}