using FluentValidation;
using UrlShortener.Application.Contracts.Persistance;

namespace UrlShortener.Application.Features.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandValidator : AbstractValidator<CreateShortUrlCommand>
    {
        private readonly IShortUrlRepository _shortUrlRepository;
        public CreateShortUrlCommandValidator(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;

            RuleFor(e => e.OriginalUrl)
                .MustAsync(OriginalUrlUnique)
                .WithMessage("The same url already exists.");
        }

        private async Task<bool> OriginalUrlUnique(string originalUrl, CancellationToken token)
        {
            return await _shortUrlRepository.IsUrlUniqueAsync(originalUrl);
        }
    }
}