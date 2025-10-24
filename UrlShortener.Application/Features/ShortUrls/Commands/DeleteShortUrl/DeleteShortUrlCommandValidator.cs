using FluentValidation;
using UrlShortener.Application.Contracts.Application;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Exceptions;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.ShortUrls.Commands.DeleteShortUrl
{
    public class DeleteShortUrlCommandValidator : AbstractValidator<DeleteShortUrlCommand>
    {
        private readonly IPermissionService _permissionService;
        private readonly IAsyncRepository<ShortUrl> _shortUrlRepository;
        public DeleteShortUrlCommandValidator(IPermissionService permissionService, IAsyncRepository<ShortUrl> shortUrlRepository)
        {
            _permissionService = permissionService;
            _shortUrlRepository = shortUrlRepository;

            RuleFor(e => e)
                .MustAsync(HasAccess)
                .WithMessage("User don't have access.");

        }

        private async Task<bool> HasAccess(DeleteShortUrlCommand command, CancellationToken token)
        {
            if (_permissionService.UserHasPrivilegedRole(command.UserRoles))
                return true;

            var shortUrl = await _shortUrlRepository.GetByIdAsync(command.Id);

            if (shortUrl is null)
                throw new NotFoundException(nameof(ShortUrl), command.Id);

            return _permissionService.IsCreatedByUser(shortUrl, command.UserId);
        }
    }
}