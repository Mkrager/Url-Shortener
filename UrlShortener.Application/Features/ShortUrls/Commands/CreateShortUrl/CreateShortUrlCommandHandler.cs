using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts.Infrastructure;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IShortUrlRepository _shortUrlRepository;
        private readonly ICodeService _codeService;

        public CreateShortUrlCommandHandler(IMapper mapper, IShortUrlRepository shortUrlRepository, ICodeService codeService)
        {
            _mapper = mapper;
            _shortUrlRepository = shortUrlRepository;
            _codeService = codeService;
        }
        public async Task<Guid> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            request.OriginalUrl = request.OriginalUrl.Trim();

            var shortUrl = _mapper.Map<ShortUrl>(request);

            string code;

            while (true)
            {
                code = _codeService.GenerateShortCode();
                var existing = await _shortUrlRepository.GetShortUrlByCodeAsync(code);

                if (existing == null)
                    break;
            }

            shortUrl.ShortCode = code;

            await _shortUrlRepository.AddAsync(shortUrl);

            return shortUrl.Id;
        }
    }
}