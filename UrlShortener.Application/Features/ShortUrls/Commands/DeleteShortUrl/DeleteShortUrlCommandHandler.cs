using MediatR;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Exceptions;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Commands.DeleteShortUrl
{
    public class DeleteShortUrlCommandHandler : IRequestHandler<DeleteShortUrlCommand>
    {
        private readonly IAsyncRepository<ShortUrl> _shortUrlRepository;
        public DeleteShortUrlCommandHandler(IAsyncRepository<ShortUrl> shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }
        public async Task<Unit> Handle(DeleteShortUrlCommand request, CancellationToken cancellationToken)
        {
            var shortUrlToDelete = await _shortUrlRepository.GetByIdAsync(request.Id);

            if (shortUrlToDelete == null)
                throw new NotFoundException(nameof(ShortUrl), request.Id);

            await _shortUrlRepository.DeleteAsync(shortUrlToDelete);

            return Unit.Value;
        }
    }
}