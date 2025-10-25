using AutoMapper;
using MediatR;
using UrlShortener.Application.Constants;
using UrlShortener.Application.Contracts.Persistance;
using UrlShortener.Application.Exceptions;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Features.AboutPages.Commands.UpdateAboutPage
{
    public class UpdateAboutPageCommandHandler : IRequestHandler<UpdateAboutPageCommand>
    {
        private readonly IAsyncRepository<AboutPage> _aboutPagerepository;
        private readonly IMapper _mapper;

        public UpdateAboutPageCommandHandler(IAsyncRepository<AboutPage> aboutPagerepository, IMapper mapper)
        {
            _aboutPagerepository = aboutPagerepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAboutPageCommand request, CancellationToken cancellationToken)
        {
            var aboutPageToUpdate = await _aboutPagerepository.GetByIdAsync(SystemGuids.AboutPageId);

            if (aboutPageToUpdate == null)
                throw new NotFoundException(nameof(AboutPage), SystemGuids.AboutPageId);

            _mapper.Map(request, aboutPageToUpdate, typeof(UpdateAboutPageCommand), typeof(AboutPage));

            await _aboutPagerepository.UpdateAsync(aboutPageToUpdate);

            return Unit.Value;

        }
    }
}